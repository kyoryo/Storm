using Mono.Cecil;
using Mono.Cecil.Cil;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gAyPI.Manipulation
{
    public class CecilInvokerInjector : Injector
    {
        private AssemblyDefinition self;
        private AssemblyDefinition def;
        private InvokerParams @params;

        public CecilInvokerInjector(AssemblyDefinition self, AssemblyDefinition def, InvokerParams @params)
        {
            this.self = self;
            this.def = def;
            this.@params = @params;
        }

        public void Inject()
        {
            var gameModule = def.MainModule;
            TypeReference returnType = gameModule.Types.FirstOrDefault(t => t.Resolve().FullName.Equals(@params.InvokerReturnType));
            if (returnType == null)
            {
                returnType = gameModule.Import(ReflectionUtils.DynamicResolve(@params.InvokerReturnType));
            }

            var paramTypes = new TypeReference[@params.InvokerReturnParams.Length];
            for (int i = 0; i < paramTypes.Length; i++)
            {
                paramTypes[i] = gameModule.Types.FirstOrDefault(t => t.Resolve().FullName.Equals(@params.InvokerReturnParams[i]));
                if (paramTypes[i] == null)
                {
                    paramTypes[i] = gameModule.Import(ReflectionUtils.DynamicResolve(@params.InvokerReturnParams[i]));
                }
            }

            var invoking = gameModule.Types.FirstOrDefault(t => t.Resolve().FullName.Equals(@params.OwnerType)).
                Methods.FirstOrDefault(m => m.Name.Equals(@params.OwnerMethodName) && CecilUtils.DescriptionOf(m).Equals(@params.OwnerMethodDesc));

            var method = new MethodDefinition(@params.InvokerName, MethodAttributes.Public | MethodAttributes.NewSlot | MethodAttributes.Virtual, returnType);
            foreach (var type in paramTypes)
            {
                method.Parameters.Add(new ParameterDefinition(type));
            }

            var instructions = method.Body.Instructions;
            var processor = method.Body.GetILProcessor();
            if (!@params.IsStatic)
            {
                instructions.Add(processor.Create(OpCodes.Ldarg_0));
            }
            for (int i = 0; i < paramTypes.Length; i++) {
                switch (i)
                {
                    case 0:
                        instructions.Add(processor.Create(OpCodes.Ldarg_1));
                        break;
                    case 1:
                        instructions.Add(processor.Create(OpCodes.Ldarg_2));
                        break;
                    case 2:
                        instructions.Add(processor.Create(OpCodes.Ldarg_3));
                        break;
                    default:
                        instructions.Add(processor.Create(OpCodes.Ldarg, i));
                        break;
                }
            }
            instructions.Add(processor.Create(OpCodes.Call, invoking));
            instructions.Add(processor.Create(OpCodes.Ret));
            invoking.DeclaringType.Methods.Add(method);
        }

        public object GetParams()
        {
            return @params;
        }
    }
}
