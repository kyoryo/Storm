using Mono.Cecil;
using Mono.Cecil.Cil;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gAyPI.Manipulation.Cecil
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
            if (returnType == null) returnType = gameModule.Import(ReflectionUtils.DynamicResolve(@params.InvokerReturnType));

            var invoking = gameModule.Types.
                FirstOrDefault(t => t.Resolve().FullName.Equals(@params.OwnerType)).
                Methods.FirstOrDefault(m => m.Name.Equals(@params.OwnerMethodName) && CecilUtils.DescriptionOf(m).Equals(@params.OwnerMethodDesc));
            var invokingParent = invoking.DeclaringType;

            var invoker = new MethodDefinition(@params.InvokerName, MethodAttributes.Public | MethodAttributes.NewSlot | MethodAttributes.Virtual, returnType);
            var paramTypes = new TypeReference[@params.InvokerReturnParams.Length];
            for (int i = 0; i < paramTypes.Length; i++)
            {
                TypeReference paramType = gameModule.Types.FirstOrDefault(t => t.Resolve().FullName.Equals(@params.InvokerReturnParams[i]));
                if (paramType == null)
                {
                    paramType = gameModule.Import(ReflectionUtils.DynamicResolve(@params.InvokerReturnParams[i]));
                }
                invoker.Parameters.Add(new ParameterDefinition(paramType));
            }
            
            var processor = invoker.Body.GetILProcessor();
            if (!@params.IsStatic)
            {
                processor.Append(processor.Create(OpCodes.Ldarg_0));
            }

            for (int i = 0; i < paramTypes.Length; i++)
            {
                switch (i)
                {
                    case 0:
                        processor.Append(processor.Create(OpCodes.Ldarg_1));
                        break;
                    case 1:
                        processor.Append(processor.Create(OpCodes.Ldarg_2));
                        break;
                    case 2:
                        processor.Append(processor.Create(OpCodes.Ldarg_3));
                        break;
                    default:
                        processor.Append(processor.Create(OpCodes.Ldarg, i));
                        break;
                }
            }

            processor.Append(processor.Create(OpCodes.Call, invoking));
            processor.Append(processor.Create(OpCodes.Ret));
            invoking.DeclaringType.Methods.Add(invoker);
        }

        public object GetParams()
        {
            return @params;
        }
    }
}
