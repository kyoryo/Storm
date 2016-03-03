using Mono.Cecil;
using Mono.Cecil.Cil;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gAyPI.Manipulation.Cecil
{
    public class CecilEventCallbackInjector : Injector
    {
        private AssemblyDefinition self;
        private AssemblyDefinition def;
        private EventCallbackParams @params;

        public CecilEventCallbackInjector(AssemblyDefinition self, AssemblyDefinition def, EventCallbackParams @params)
        {
            this.self = self;
            this.def = def;
            this.@params = @params;
        }

        public void Inject()
        {
            var instancedRecv = self.MainModule.Types.
                Where(t => t.FullName.Equals(@params.CallbackType)).
                SelectMany(t => t.Methods).
                FirstOrDefault(m => m.Name.Equals(@params.InstanceCallbackName) && CecilUtils.DescriptionOf(m).Equals(@params.InstanceCallbackDesc));
            var instancedImport = def.MainModule.Import(instancedRecv);

            var staticRecv = self.MainModule.Types.
                Where(t => t.FullName.Equals(@params.CallbackType)).
                SelectMany(t => t.Methods).
                FirstOrDefault(m => m.Name.Equals(@params.StaticCallbackName) && CecilUtils.DescriptionOf(m).Equals(@params.StaticCallbackDesc));
            var staticImport = def.MainModule.Import(staticRecv);

            var injectee = def.MainModule.Types.
                Where(t => t.FullName.Equals(@params.OwnerType)).
                SelectMany(t => t.Methods).
                FirstOrDefault(m => m.Name.Equals(@params.OwnerMethodName) && CecilUtils.DescriptionOf(m).Equals(@params.OwnerMethodDesc));
            var returnName = injectee.ReturnType.FullName;

            var hasReturnValue = typeof(DetourEvent).GetProperty("ReturnEarly");
            var hasReturnValueImport = def.MainModule.Import(hasReturnValue.GetMethod);
            
            var eventReturnValue = typeof(DetourEvent).GetProperty("ReturnValue");
            var eventReturnValueImport = def.MainModule.Import(eventReturnValue.GetMethod);

            var body = injectee.Body;
            var processor = body.GetILProcessor();
            var ins = body.Instructions[@params.InsertionIndex];
            if (!injectee.IsStatic)
            {
                processor.InsertBefore(ins, processor.Create(OpCodes.Ldarg_0));
            }

            var jmpTarget = returnName.Equals(typeof(void).FullName) ? ins : processor.Create(OpCodes.Pop);

            processor.InsertBefore(ins, processor.Create(OpCodes.Call, injectee.IsStatic ? staticImport : instancedImport));
            if (!returnName.Equals(typeof(void).FullName))
            {
                processor.InsertBefore(ins, processor.Create(OpCodes.Dup));
            }
            processor.InsertBefore(ins, processor.Create(OpCodes.Call, hasReturnValueImport));
            processor.InsertBefore(ins, processor.Create(OpCodes.Brfalse_S, jmpTarget));
            
            if (returnName.Equals(typeof(Int32).FullName) || returnName.Equals(typeof(Boolean).FullName))
            {
                processor.InsertBefore(ins, processor.Create(OpCodes.Call, eventReturnValueImport));
                processor.InsertBefore(ins, processor.Create(OpCodes.Unbox_Any, injectee.ReturnType));
            }

            processor.InsertBefore(ins, processor.Create(OpCodes.Ret));
            if (!returnName.Equals(typeof(void).FullName))
            {
                processor.InsertBefore(ins, jmpTarget);
            }
        }

        public object GetParams()
        {
            return @params;
        }
    }
}