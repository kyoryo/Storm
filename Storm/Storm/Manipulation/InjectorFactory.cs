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

        public InjectionFactoryContext ParseOfType(DataFormat format, string path)
        {
            var ctx = new InjectionFactoryContext();
            ctx.Injectors = new List<Injector>();

            switch (format)
            {
                case DataFormat.Json:
                    ctx.Injectors = ParseJson(path);
                    break;
            }

            ctx.GetConcreteAssembly = () => ToConcrete();
            return ctx;
        }

        private List<Injector> ParseJson(string path)
        {
            var list = new List<Injector>();
            var nameMap = new Dictionary<string, string>();
            var accessorMap = new Dictionary<string, string>();

            var primary = Path.Combine(path, "interface_injectors.json");
            ParseJson(new FileStream(primary, FileMode.Open, FileAccess.Read), list, nameMap, accessorMap);

            var secondaryFolder = Path.Combine(path, "secondary\\");
            foreach (var child in Directory.GetFiles(secondaryFolder, "*"))
            {
                ParseJson(new FileStream(child, FileMode.Open, FileAccess.Read), list, nameMap, accessorMap);
            }

            Logging.DebugLogs("[{0}] Loaded {1} injectors.", GetType().Name, list.Count);
            return list;
        }

        private void ParseJson(Stream @in, List<Injector> list, Dictionary<string, string> nameMap, Dictionary<string, string> accessorMap)
        {
            var reader = new StreamReader(@in);
            var json = reader.ReadToEnd();
            reader.Close();

            var container = JsonConvert.DeserializeObject<JsonParamContainer>(json);
            if (container == null) return;

            foreach (var injector in container.InterfaceParams)
            {
                list.Add(CreateInterfaceInjector(new InterfaceParams
                {
                    SimpleName = injector.SimpleName,
                    OwnerType = injector.OwnerType,
                    InterfaceType = injector.InterfaceType
                }));
                nameMap.Add(injector.SimpleName, injector.OwnerType);
                accessorMap.Add(injector.InterfaceType, injector.OwnerType);
            }

            // FIXME - There has got to be a better way to do everything under this
            list.AddRange(container.FieldDetourParams.Select(injector => CreateFieldDetourInjector(new FieldDetourParams
            {
                OwnerType = InjectorMetaData.FilterTags(nameMap, injector.OwnerAccessorType),
                OwnerFieldName = injector.OwnerFieldName,
                OwnerFieldType = InjectorMetaData.FilterTags(nameMap, injector.OwnerFieldType),
                DetourType = InjectorMetaData.FilterTags(nameMap, injector.DetourType),
                DetourMethodName = injector.DetourMethodName,
                DetourMethodDesc = injector.DetourMethodDesc
            })));

            list.AddRange(container.FieldAccessorParams.Select(injector => CreateFieldAccessorInjector(new FieldAccessorParams
            {
                OwnerType = InjectorMetaData.FilterTags(nameMap, injector.OwnerAccessorType),
                OwnerFieldName = injector.OwnerFieldName,
                OwnerFieldType = InjectorMetaData.FilterTags(nameMap, injector.OwnerFieldType),
                MethodName = injector.MethodName,
                ReturnType = InjectorMetaData.FilterTags(nameMap, injector.ReturnType),
                IsStatic = injector.IsStatic,
                OwnerAccessorType = injector.OwnerAccessorType
            })));

            list.AddRange(container.FieldMutatorParams.Select(injector => CreateFieldMutatorInjector(new FieldMutatorParams
            {
                OwnerType = InjectorMetaData.FilterTags(nameMap, injector.OwnerAccessorType),
                OwnerFieldName = injector.OwnerFieldName,
                OwnerFieldType = InjectorMetaData.FilterTags(nameMap, injector.OwnerFieldType),
                MethodName = injector.MethodName,
                ParamType = InjectorMetaData.FilterTags(nameMap, injector.ParamType),
                IsStatic = injector.IsStatic,
                OwnerAccessorType = injector.OwnerAccessorType
            })));

            list.AddRange(container.FieldAccessorMutatorParams.Select(injector => CreateFieldAccessorMutatorInjector(new FieldAccessorMutatorParams
            {
                OwnerType = InjectorMetaData.FilterTags(nameMap, injector.OwnerAccessorType),
                OwnerFieldName = injector.OwnerFieldName,
                OwnerFieldType = InjectorMetaData.FilterTags(nameMap, injector.OwnerFieldType),
                MethodName = injector.MethodName,
                Type = InjectorMetaData.FilterTags(nameMap, injector.Type),
                IsStatic = injector.IsStatic,
                OwnerAccessorType = injector.OwnerAccessorType
            })));

            list.AddRange(container.InvokerParams.Select(injector => CreateInvokerInjector(new InvokerParams
            {
                OwnerType = InjectorMetaData.FilterTags(nameMap, injector.OwnerAccessorType),
                OwnerMethodName = injector.OwnerMethodName,
                OwnerMethodDesc = InjectorMetaData.FilterTags(nameMap, injector.OwnerMethodDesc),
                InvokerType = injector.InvokerType == null ? null : InjectorMetaData.FilterTags(nameMap, injector.InvokerType),
                InvokerName = injector.InvokerName,
                InvokerReturnParams = injector.InvokerReturnParams,
                InvokerReturnType = injector.InvokerReturnType,
                IsStatic = injector.IsStatic
            })));

            list.AddRange(container.AbsoluteCallParams.Select(injector => CreateAbsoluteCallInjector(new AbsoluteCallParams
            {
                OwnerType = InjectorMetaData.FilterTags(nameMap, injector.OwnerAccessorType),
                OwnerMethodName = injector.OwnerMethodName,
                OwnerMethodDesc = InjectorMetaData.FilterTags(nameMap, injector.OwnerMethodDesc),
                DetourType = injector.DetourType,
                DetourMethodName = injector.DetourMethodName,
                DetourMethodDesc = InjectorMetaData.FilterTags(nameMap, injector.DetourMethodDesc),
                InsertionType = injector.InsertionType,
                InsertionIndex = injector.InsertionIndex
            })));

            list.AddRange(container.FieldInfoParams.Select(injector => CreateFieldInfoInjector(new FieldInfoParams
            {
                OwnerType = InjectorMetaData.FilterTags(nameMap, injector.OwnerAccessorType),
                FieldName = injector.FieldName,
                FieldType = InjectorMetaData.FilterTags(nameMap, injector.FieldType),
                OwnerAccessorType = injector.OwnerAccessorType,
                RefactoredName = injector.RefactoredName
            })));

            list.AddRange(container.MethodInfoParams.Select(injector => CreateMethodInfoInjector(new MethodInfoParams
            {
                OwnerType = InjectorMetaData.FilterTags(nameMap, injector.OwnerAccessorType),
                MethodName = injector.MethodName,
                MethodDesc = InjectorMetaData.FilterTags(nameMap, injector.MethodDesc),
                OwnerAccessorType = injector.OwnerAccessorType,
                RefactoredName = injector.RefactoredName
            })));

            list.AddRange(container.EventCallbackParams.Select(injector => CreateEventCallbackInjector(new EventCallbackParams
            {
                OwnerType = InjectorMetaData.FilterTags(nameMap, injector.OwnerAccessorType),
                OwnerMethodName = injector.OwnerMethodName,
                OwnerMethodDesc = InjectorMetaData.FilterTags(nameMap, injector.OwnerMethodDesc),
                CallbackType = injector.CallbackType,
                InstanceCallbackName = injector.InstanceCallbackName,
                InstanceCallbackDesc = injector.InstanceCallbackDesc,
                StaticCallbackName = injector.StaticCallbackName,
                StaticCallbackDesc = injector.StaticCallbackDesc,
                InsertionIndex = injector.InsertionIndex,
                InsertionType = injector.InsertionType,
                PushParams = injector.PushParams,
                JumpFix = injector.JumpFix
            })));
        }
    }
}