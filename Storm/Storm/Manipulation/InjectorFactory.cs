/*
    Copyright 2016 Cody R. (Demmonic)

    Storm is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    Storm is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with Storm.  If not, see <http://www.gnu.org/licenses/>.
 */

using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Newtonsoft.Json;
using Storm.Manipulation.Json;

namespace Storm.Manipulation
{
    public abstract class InjectorFactory
    {
        public InjectorFactory()
        {
        }

        public InjectorFactory(string path)
        {
            UpdatePath(path);
        }

        protected abstract void UpdatePath(string path);

        public abstract Injector CreateInterfaceInjector(InterfaceParams @params);

        public abstract Injector CreateFieldDetourInjector(FieldDetourParams @params);

        public abstract Injector CreateFieldAccessorInjector(FieldAccessorParams @params);

        public abstract Injector CreateFieldMutatorInjector(FieldMutatorParams @params);

        public abstract Injector CreateFieldAccessorMutatorInjector(FieldAccessorMutatorParams @params);

        public abstract Injector CreateInvokerInjector(InvokerParams @params);

        public abstract Injector CreateAbsoluteCallInjector(AbsoluteCallParams @params);

        public abstract Injector CreateEventCallbackInjector(EventCallbackParams @params);

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
                var start = s.IndexOf('@');
                var end = -1;
                if (s[start + 1] == '(')
                {
                    end = s.IndexOf(')', start);
                    if (end == -1) end = s.Length;
                    else end += 1;
                    var key = s.Substring(start + 2, end - start - 3);
                    s = s.Replace(s.Substring(start, end - start), map[key]);
                }
                else
                {
                    end = s.IndexOf(' ', start);
                    if (end == -1) end = s.Length;
                    else end += 1;
                    var key = s.Substring(start + 1, end - start - 1);
                    s = s.Replace(s.Substring(start, end - start), map[key]);
                }
            }
            return s;
        }

        private List<Injector> ParseJson(Stream @in)
        {
            var reader = new StreamReader(@in);
            var json = reader.ReadToEnd();
            reader.Close();

            var list = new List<Injector>();
            var container = JsonConvert.DeserializeObject<JsonParamContainer>(json);

            var nameMap = new Dictionary<string, string>();
            var accessorMap = new Dictionary<string, string>();

            foreach (var injector in container.InterfaceParams)
            {
                list.Add(CreateInterfaceInjector(new InterfaceParams
                {
                    OwnerType = injector.OwnerType,
                    InterfaceType = injector.InterfaceType
                }));
                nameMap.Add(injector.SimpleName, injector.OwnerType);
                accessorMap.Add(injector.InterfaceType, injector.OwnerType);
            }

            // FIXME - There has got to be a better way to do everything under this
            list.AddRange(container.FieldDetourParams.Select(injector => CreateFieldDetourInjector(new FieldDetourParams
            {
                OwnerType = FilterTags(nameMap, injector.OwnerAccessorType),
                OwnerFieldName = injector.OwnerFieldName,
                OwnerFieldType = FilterTags(nameMap, injector.OwnerFieldType),
                DetourType = FilterTags(nameMap, injector.DetourType),
                DetourMethodName = injector.DetourMethodName,
                DetourMethodDesc = injector.DetourMethodDesc
            })));

            list.AddRange(container.FieldAccessorParams.Select(injector => CreateFieldAccessorInjector(new FieldAccessorParams
            {
                OwnerType = FilterTags(nameMap, injector.OwnerAccessorType),
                OwnerFieldName = injector.OwnerFieldName,
                OwnerFieldType = FilterTags(nameMap, injector.OwnerFieldType),
                MethodName = injector.MethodName,
                ReturnType = FilterTags(nameMap, injector.ReturnType),
                IsStatic = injector.IsStatic,
                OwnerAccessorType = injector.OwnerAccessorType
            })));

            list.AddRange(container.FieldMutatorParams.Select(injector => CreateFieldMutatorInjector(new FieldMutatorParams
            {
                OwnerType = FilterTags(nameMap, injector.OwnerAccessorType),
                OwnerFieldName = injector.OwnerFieldName,
                OwnerFieldType = FilterTags(nameMap, injector.OwnerFieldType),
                MethodName = injector.MethodName,
                ParamType = FilterTags(nameMap, injector.ParamType),
                IsStatic = injector.IsStatic,
                OwnerAccessorType = injector.OwnerAccessorType
            })));

            list.AddRange(container.FieldAccessorMutatorParams.Select(injector => CreateFieldAccessorMutatorInjector(new FieldAccessorMutatorParams
            {
                OwnerType = FilterTags(nameMap, injector.OwnerAccessorType),
                OwnerFieldName = injector.OwnerFieldName,
                OwnerFieldType = FilterTags(nameMap, injector.OwnerFieldType),
                MethodName = injector.MethodName,
                Type = FilterTags(nameMap, injector.Type),
                IsStatic = injector.IsStatic,
                OwnerAccessorType = injector.OwnerAccessorType
            })));

            list.AddRange(container.InvokerParams.Select(injector => CreateInvokerInjector(new InvokerParams
            {
                OwnerType = FilterTags(nameMap, injector.OwnerAccessorType),
                OwnerMethodName = injector.OwnerMethodName,
                OwnerMethodDesc = FilterTags(nameMap, injector.OwnerMethodDesc),
                InvokerName = injector.InvokerName,
                InvokerReturnParams = injector.InvokerReturnParams,
                InvokerReturnType = injector.InvokerReturnType,
                IsStatic = injector.IsStatic
            })));

            list.AddRange(container.AbsoluteCallParams.Select(injector => CreateAbsoluteCallInjector(new AbsoluteCallParams
            {
                OwnerType = FilterTags(nameMap, injector.OwnerAccessorType),
                OwnerMethodName = injector.OwnerMethodName,
                OwnerMethodDesc = FilterTags(nameMap, injector.OwnerMethodDesc),
                DetourType = injector.DetourType,
                DetourMethodName = injector.DetourMethodName,
                DetourMethodDesc = FilterTags(nameMap, injector.DetourMethodDesc),
                InsertionType = injector.InsertionType,
                InsertionIndex = injector.InsertionIndex
            })));

            list.AddRange(container.FieldInfoParams.Select(injector => CreateFieldInfoInjector(new FieldInfoParams
            {
                OwnerType = FilterTags(nameMap, injector.OwnerAccessorType),
                FieldName = injector.FieldName,
                FieldType = FilterTags(nameMap, injector.FieldType),
                OwnerAccessorType = injector.OwnerAccessorType,
                RefactoredName = injector.RefactoredName
            })));

            list.AddRange(container.MethodInfoParams.Select(injector => CreateMethodInfoInjector(new MethodInfoParams
            {
                OwnerType = FilterTags(nameMap, injector.OwnerAccessorType),
                MethodName = injector.MethodName,
                MethodDesc = FilterTags(nameMap, injector.MethodDesc),
                OwnerAccessorType = injector.OwnerAccessorType,
                RefactoredName = injector.RefactoredName
            })));

            list.AddRange(container.EventCallbackParams.Select(injector => CreateEventCallbackInjector(new EventCallbackParams
            {
                OwnerType = FilterTags(nameMap, injector.OwnerAccessorType),
                OwnerMethodName = injector.OwnerMethodName,
                OwnerMethodDesc = FilterTags(nameMap, injector.OwnerMethodDesc),
                CallbackType = injector.CallbackType,
                InstanceCallbackName = injector.InstanceCallbackName,
                InstanceCallbackDesc = injector.InstanceCallbackDesc,
                StaticCallbackName = injector.StaticCallbackName,
                StaticCallbackDesc = injector.StaticCallbackDesc,
                InsertionIndex = injector.InsertionIndex,
                InsertionType = injector.InsertionType,
                PushParams = injector.PushParams
            })));

            return list;
        }
    }
}