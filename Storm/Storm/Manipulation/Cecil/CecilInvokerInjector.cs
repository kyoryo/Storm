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

using Mono.Cecil;
using Mono.Cecil.Cil;

namespace Storm.Manipulation.Cecil
{
    public class CecilInvokerInjector : Injector
    {
        private readonly AssemblyDefinition def;
        private InvokerParams @params;
        private readonly AssemblyDefinition self;

        public CecilInvokerInjector(AssemblyDefinition self, AssemblyDefinition def, InvokerParams @params)
        {
            this.self = self;
            this.def = def;
            this.@params = @params;
        }

        public void Init()
        {
        }

        public void Inject()
        {
            var returnType = def.GetTypeRef(@params.InvokerReturnType, true);
            if (returnType == null)
            {
                Logging.DebugLogs("[{0}] Could not find returnType!", GetType().Name);
                Logging.DebugLogs("\t{0} {1} {2}", @params.OwnerType, @params.OwnerMethodName, @params.OwnerMethodDesc);
                Logging.DebugLogs("\t{0} {1} {2}", @params.InvokerType, @params.InvokerName, @params.InvokerReturnType);
                return;
            }

            var invoking = def.GetMethod(@params.OwnerType, @params.OwnerMethodName, @params.OwnerMethodDesc);
            if (invoking == null)
            {
                Logging.DebugLogs("[{0}] Could not find invoking!", GetType().Name);
                Logging.DebugLogs("\t{0} {1} {2}", @params.OwnerType, @params.OwnerMethodName, @params.OwnerMethodDesc);
                Logging.DebugLogs("\t{0} {1} {2}", @params.InvokerType, @params.InvokerName, @params.InvokerReturnType);
                return;
            }

            var invokingParent = invoking.DeclaringType;
            var invokerType = invokingParent;
            if (@params.InvokerType != null)
            {
                invokerType = def.GetTypeDef(@params.InvokerType);
                if (invokerType == null)
                {
                    invokerType = self.GetTypeDef(@params.InvokerType);
                }
            }

            if (invokerType == null)
            {
                Logging.DebugLogs("[{0}] Could not find invokerType!", GetType().Name);
                Logging.DebugLogs("\t{0} {1} {2}", @params.OwnerType, @params.OwnerMethodName, @params.OwnerMethodDesc);
                Logging.DebugLogs("\t{0} {1} {2}", @params.InvokerType, @params.InvokerName, @params.InvokerReturnType);
                return;
            }

            var invoker = new MethodDefinition(@params.InvokerName, MethodAttributes.Public | MethodAttributes.NewSlot | MethodAttributes.Virtual, returnType);
            var paramTypes = new TypeReference[@params.InvokerReturnParams.Length];
            for (var i = 0; i < paramTypes.Length; i++)
            {
                var paramType = def.GetTypeRef(@params.InvokerReturnParams[i], true);
                if (paramType == null)
                {
                    Logging.DebugLogs("[{0}] Could not find param {1}!", GetType().Name, i);
                    Logging.DebugLogs("\t{0} {1} {2}", @params.OwnerType, @params.OwnerMethodName, @params.OwnerMethodDesc);
                    Logging.DebugLogs("\t{0} {1} {2}", @params.InvokerType, @params.InvokerName, @params.InvokerReturnType);
                    return;
                }

                invoker.Parameters.Add(new ParameterDefinition(paramType));
            }

            var processor = invoker.Body.GetILProcessor();
            if (!@params.IsStatic)
            {
                processor.Append(processor.Create(OpCodes.Ldarg_0));
            }

            for (var i = 0; i < paramTypes.Length; i++)
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
            invokerType.Methods.Add(invoker);
        }

        public object GetParams()
        {
            return @params;
        }
    }
}