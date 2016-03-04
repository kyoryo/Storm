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
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storm.Manipulation.Cecil
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

            var returnType = def.GetTypeRef(@params.InvokerReturnType, true);
            var invoking = def.GetMethod(@params.OwnerType, @params.OwnerMethodName, @params.OwnerMethodDesc);

            if (returnType == null)
            {
                Logging.DebugLog(String.Format("[CecilInvokerInjector] Could not find returnType {0} {1} {2} {3} {4}",
                     @params.OwnerType, @params.OwnerMethodName, @params.OwnerMethodDesc, @params.InvokerName, @params.InvokerReturnType));
                return;
            }

            if (invoking == null)
            {
                Logging.DebugLog(String.Format("[CecilInvokerInjector] Could not find invoking {0} {1} {2} {3} {4}",
                     @params.OwnerType, @params.OwnerMethodName, @params.OwnerMethodDesc, @params.InvokerName, @params.InvokerReturnType));
                return;
            }

            var invokingParent = invoking.DeclaringType;
            var invoker = new MethodDefinition(@params.InvokerName, MethodAttributes.Public | MethodAttributes.NewSlot | MethodAttributes.Virtual, returnType);
            var paramTypes = new TypeReference[@params.InvokerReturnParams.Length];
            for (int i = 0; i < paramTypes.Length; i++)
            {
                var paramType = def.GetTypeRef(@params.InvokerReturnParams[i], true);
                if (paramType == null)
                {
                    Logging.DebugLog(String.Format("[CecilInvokerInjector] Could not find param {0} {1} {2} {3} {4}",
                         @params.OwnerType, @params.OwnerMethodName, @params.OwnerMethodDesc, @params.InvokerName, @params.InvokerReturnType));
                    return;
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
