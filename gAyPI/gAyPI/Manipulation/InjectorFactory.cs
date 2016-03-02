using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace gAyPI.Manipulation
{
    public abstract class InjectorFactory
    {
        public InjectorFactory() { }

        public InjectorFactory(string path)
        {
            UpdatePath(path);
        }

        protected abstract void UpdatePath(string path);

        public abstract Injector CreateInterfaceInjector(InterfaceParams @params);

        public abstract Injector CreateFieldDetourInjector(FieldDetourParams @params);

        public abstract Injector CreateFieldAccessorInjector(FieldAccessorParams @params);

        public abstract Injector CreateFieldMutatorInjector(FieldMutatorParams @params);

        public abstract Injector CreateAbsoluteCallInjector(AbsoluteCallParams @params);

        public virtual Injector CreateFieldInfoInjector(FieldInfoParams @params)
        {
            return new FieldInfoInjector(@params);
        }

        public virtual Injector CreateMethodInfoInjector(MethodInfoParams @params)
        {
            return new MethodInfoInjector(@params);
        }

        public abstract Assembly ToConcrete();

        public InjectionFactoryContext ParseOfType(DataFormat format, Stream @in)
        {
            var ctx = new InjectionFactoryContext();
            ctx.Injectors = new List<Injector>();

            switch (format)
            {
                case DataFormat.Json:
                    ctx.Injectors = ParseJson(@in);
                    break;
            }

            ctx.GetConcreteAssembly = () => ToConcrete();
            return ctx;
        }

        private string FilterTags(Dictionary<string, string> map, string s)
        {
            while (s.IndexOf("@") != -1)
            {
                int start = s.IndexOf('@');
                int end = -1;
                if (s[start + 1] == '(')
                {
                    end = s.IndexOf(')', start);
                    if (end == -1) end = s.Length;
                    else end += 1;
                    string key = s.Substring(start + 2, end - start - 3);
                    s = s.Replace(s.Substring(start, end - start), map[key]);
                }
                else
                {
                    end = s.IndexOf(' ', start);
                    if (end == -1) end = s.Length;
                    else end += 1;
                    string key = s.Substring(start + 1, end - start - 1);
                    s = s.Replace(s.Substring(start, end - start), map[key]);
                }
            }
            return s;
        }

        private List<Injector> ParseJson(Stream @in)
        {
            var reader = new StreamReader(@in);
            var json = reader.ReadToEnd();

            var list = new List<Injector>();
            var container = JsonConvert.DeserializeObject<JsonParamContainer>(json);

            var nameMap = new Dictionary<string, string>();
            var accessorMap = new Dictionary<string, string>();

            if (container.InterfaceParams != null)
            {
                foreach (var injector in container.InterfaceParams)
                {
                    list.Add(CreateInterfaceInjector(new InterfaceParams
                    {
                        OwnerType = injector.OwnerType,
                        InterfaceType = injector.InterfaceType,
                    }));
                    nameMap.Add(injector.SimpleName, injector.OwnerType);
                    accessorMap.Add(injector.InterfaceType, injector.OwnerType);
                }
            }

            if (container.FieldDetourParams != null)
            {
                foreach (var injector in container.FieldDetourParams)
                {
                    list.Add(CreateFieldDetourInjector(new FieldDetourParams
                    {
                        OwnerType = FilterTags(nameMap, injector.OwnerAccessorType),
                        OwnerFieldName = injector.OwnerFieldName,
                        OwnerFieldType = FilterTags(nameMap, injector.OwnerFieldType),
                        DetourType = injector.DetourType,
                        DetourMethodName = injector.DetourMethodName,
                        DetourMethodDesc = injector.DetourMethodDesc
                    }));
                }
            }

            if (container.FieldAccessorParams != null)
            {
                foreach (var injector in container.FieldAccessorParams)
                {
                    list.Add(CreateFieldAccessorInjector(new FieldAccessorParams
                    {
                        OwnerType = FilterTags(nameMap, injector.OwnerAccessorType),
                        OwnerFieldName = injector.OwnerFieldName,
                        OwnerFieldType = FilterTags(nameMap, injector.OwnerFieldType),
                        MethodName = injector.MethodName,
                        ReturnType = FilterTags(nameMap, injector.ReturnType),
                        IsStatic = injector.IsStatic,
                        OwnerAccessorType = injector.OwnerAccessorType,
                    }));
                }
            }

            if (container.FieldMutatorParams != null)
            {
                foreach (var injector in container.FieldMutatorParams)
                {
                    list.Add(CreateFieldMutatorInjector(new FieldMutatorParams
                    {
                        OwnerType = FilterTags(nameMap, injector.OwnerAccessorType),
                        OwnerFieldName = injector.OwnerFieldName,
                        OwnerFieldType = FilterTags(nameMap, injector.OwnerFieldType),
                        MethodName = injector.MethodName,
                        ParamType = FilterTags(nameMap, injector.ParamType),
                        IsStatic = injector.IsStatic,
                        OwnerAccessorType = injector.OwnerAccessorType,
                    }));
                }
            }

            if (container.AbsoluteCallParams != null)
            {
                foreach (var injector in container.AbsoluteCallParams)
                {
                    list.Add(CreateAbsoluteCallInjector(new AbsoluteCallParams
                    {
                        OwnerType = FilterTags(nameMap, injector.OwnerAccessorType),
                        OwnerMethodName = injector.OwnerMethodName,
                        OwnerMethodDesc = FilterTags(nameMap, injector.OwnerMethodDesc),
                        DetourType = injector.DetourType,
                        DetourMethodName = injector.DetourMethodName,
                        DetourMethodDesc = FilterTags(nameMap, injector.DetourMethodDesc),
                        InsertionIndex = injector.InsertionIndex
                    }));
                }
            }

            if (container.FieldInfoParams != null)
            {
                foreach (var injector in container.FieldInfoParams)
                {
                    list.Add(CreateFieldInfoInjector(new FieldInfoParams
                    {
                        OwnerType = FilterTags(nameMap, injector.OwnerAccessorType),
                        FieldName = injector.FieldName,
                        FieldType = FilterTags(nameMap, injector.FieldType),
                        OwnerAccessorType = injector.OwnerAccessorType,
                        RefactoredName = injector.RefactoredName,
                    }));
                }
            }

            if (container.MethodInfoParams != null)
            {
                foreach (var injector in container.MethodInfoParams)
                {
                    list.Add(CreateMethodInfoInjector(new MethodInfoParams
                    {
                        OwnerType = FilterTags(nameMap, injector.OwnerAccessorType),
                        MethodName = injector.MethodName,
                        MethodDesc = FilterTags(nameMap, injector.MethodDesc),
                        OwnerAccessorType = injector.OwnerAccessorType,
                        RefactoredName = injector.RefactoredName,
                    }));
                }
            }
            return list;
        }
    }
}
