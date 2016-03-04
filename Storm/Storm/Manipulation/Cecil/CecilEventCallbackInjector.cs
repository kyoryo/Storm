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
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storm.Manipulation.Cecil
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
            var injectee = def.GetMethod(@params.OwnerType, @params.OwnerMethodName, @params.OwnerMethodDesc);

            if (injectee == null)
            {
                Logging.DebugLog(String.Format("[CecilEventCallbackInjector] Could not find injectee {0} {1} {2} {3} {4} {4} {5} {6} {7} {8}",
                    @params.OwnerType, @params.OwnerMethodName,  @params.OwnerMethodDesc, @params.CallbackType,
                    @params.InstanceCallbackName, @params.InstanceCallbackDesc, @params.StaticCallbackName, @params.StaticCallbackDesc,
                    @params.InsertionIndex));
                return;
            }
            
            var returnName = injectee.ReturnType.FullName;

            var hasReturnValue = typeof(DetourEvent).GetProperty("ReturnEarly");
            var hasReturnValueImport = def.MainModule.Import(hasReturnValue.GetMethod);
            
            var eventReturnValue = typeof(DetourEvent).GetProperty("ReturnValue");
            var eventReturnValueImport = def.MainModule.Import(eventReturnValue.GetMethod);

            var body = injectee.Body;
            var processor = body.GetILProcessor();
            var ins = body.Instructions[@params.InsertionIndex];
            var jmpTarget = returnName.Equals(typeof(void).FullName) ? ins : processor.Create(OpCodes.Pop);

            MethodReference instancedImport = null;
            MethodReference staticImport = null;
            if (injectee.IsStatic)
            {
                var staticRecv = self.GetMethod(@params.CallbackType, @params.StaticCallbackName, @params.StaticCallbackDesc);
                if (staticRecv == null)
                {
                    Logging.DebugLog(String.Format("[CecilEventCallbackInjector] Could not find staticRecv {0} {1} {2} {3} {4} {4} {5} {6} {7} {8}",
                        @params.OwnerType, @params.OwnerMethodName, @params.OwnerMethodDesc, @params.CallbackType,
                        @params.InstanceCallbackName, @params.InstanceCallbackDesc, @params.StaticCallbackName, @params.StaticCallbackDesc,
                        @params.InsertionIndex));
                    return;
                }
                staticImport = injectee.Module.Import(staticRecv);
            }
            else
            {
                var instancedRecv = self.GetMethod(@params.CallbackType, @params.InstanceCallbackName, @params.InstanceCallbackDesc);
                if (instancedRecv == null)
                {
                    Logging.DebugLog(String.Format("[CecilEventCallbackInjector] Could not find instancedRecv {0} {1} {2} {3} {4} {4} {5} {6} {7} {8}",
                        @params.OwnerType, @params.OwnerMethodName, @params.OwnerMethodDesc, @params.CallbackType,
                        @params.InstanceCallbackName, @params.InstanceCallbackDesc, @params.StaticCallbackName, @params.StaticCallbackDesc,
                        @params.InsertionIndex));
                    return;
                }
                instancedImport = injectee.Module.Import(instancedRecv);
            }

            if (!injectee.IsStatic)
            {
                processor.InsertBefore(ins, processor.Create(OpCodes.Ldarg_0));
            }

            if (@params.PushParams)
            {
                for (int i = 0; i < injectee.Parameters.Count(); i++)
                {
                    switch (i)
                    {
                        case 0:
                            processor.InsertBefore(ins, processor.Create(OpCodes.Ldarg_1));
                            break;
                        case 1:
                            processor.InsertBefore(ins, processor.Create(OpCodes.Ldarg_2));
                            break;
                        case 2:
                            processor.InsertBefore(ins, processor.Create(OpCodes.Ldarg_3));
                            break;
                        default:
                            processor.InsertBefore(ins, processor.Create(OpCodes.Ldarg, i));
                            break;
                    }
                }
            }

            processor.InsertBefore(ins, processor.Create(OpCodes.Call, injectee.IsStatic ? staticImport : instancedImport));
            if (!returnName.Equals(typeof(void).FullName))
            {
                processor.InsertBefore(ins, processor.Create(OpCodes.Dup));
            }
            processor.InsertBefore(ins, processor.Create(OpCodes.Call, hasReturnValueImport));
            processor.InsertBefore(ins, processor.Create(OpCodes.Brfalse_S, jmpTarget));

            if (!returnName.Equals(typeof(void).FullName))
            {
                processor.InsertBefore(ins, processor.Create(OpCodes.Call, eventReturnValueImport));
            }

            if (returnName.Equals(typeof(Int32).FullName) || returnName.Equals(typeof(Boolean).FullName))
            {
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