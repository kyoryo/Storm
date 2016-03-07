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
using System.Linq;
using Mono.Cecil;
using Mono.Cecil.Cil;

namespace Storm.Manipulation.Cecil
{
    public class CecilEventCallbackInjector : Injector
    {
        private readonly AssemblyDefinition def;
        private readonly AssemblyDefinition self;
        private readonly EventCallbackParams @params;

        private readonly List<Instruction> injectionPoints = new List<Instruction>();
        private MethodDefinition injectee;
        private MethodReference callback;
        private bool invalid;

        public CecilEventCallbackInjector(AssemblyDefinition self, AssemblyDefinition def, EventCallbackParams @params)
        {
            this.self = self;
            this.def = def;
            this.@params = @params;
        }

        public void Init()
        {
            injectee = def.GetMethod(@params.OwnerType, @params.OwnerMethodName, @params.OwnerMethodDesc);
            if (injectee == null)
            {
                Logging.DebugLogs("[{0}] Could not find injectee!", GetType().Name);
                Logging.DebugLogs("\t{0} {1} {2}", @params.OwnerType, @params.OwnerMethodName, @params.OwnerMethodDesc);
                Logging.DebugLogs("\t{0} {1}", @params.InstanceCallbackName, @params.InstanceCallbackDesc);
                Logging.DebugLogs("\t{0} {1}", @params.StaticCallbackName, @params.StaticCallbackDesc);
                Logging.DebugLogs("\t{0}", @params.InsertionIndex);
                invalid = true;
                return;
            }

            MethodDefinition recv = null;
            if (injectee.IsStatic) recv = self.GetMethod(@params.CallbackType, @params.StaticCallbackName, @params.StaticCallbackDesc);
            else recv = self.GetMethod(@params.CallbackType, @params.InstanceCallbackName, @params.InstanceCallbackDesc);
            if (recv == null)
            {
                Logging.DebugLogs("[{0}] Could not find receiver!", GetType().Name);
                Logging.DebugLogs("\t{0} {1} {2}", @params.OwnerType, @params.OwnerMethodName, @params.OwnerMethodDesc);
                Logging.DebugLogs("\t{0} {1}", @params.InstanceCallbackName, @params.InstanceCallbackDesc);
                Logging.DebugLogs("\t{0} {1}", @params.StaticCallbackName, @params.StaticCallbackDesc);
                Logging.DebugLogs("\t{0}", @params.InsertionIndex);
                invalid = true;
                return;
            }

            var paramCount = (injectee.IsStatic ? 0 : 1);
            if (@params.PushParams)
            {
                paramCount += injectee.Parameters.Count;
            }

            callback = injectee.Module.Import(recv);
            if (paramCount != callback.Parameters.Count)
            {
                Logging.DebugLog("[CecilEventCallbackInjector] Invalid param count on callback!");
                Logging.DebugLogs("\t{0} {1} {2}", @params.OwnerType, @params.OwnerMethodName, @params.OwnerMethodDesc);
                Logging.DebugLogs("\t{0} {1}", @params.InstanceCallbackName, @params.InstanceCallbackDesc);
                Logging.DebugLogs("\t{0} {1}", @params.StaticCallbackName, @params.StaticCallbackDesc);
                Logging.DebugLogs("\t{0}", @params.InsertionIndex);
                invalid = true;
                return;
            }

            if (@params.InsertionType == InsertionType.BEGINNING)
            {
                injectionPoints.Add(injectee.Body.Instructions[0]);
                return;
            }

            if (@params.InsertionType == InsertionType.LAST && @params.InsertionIndex == null)
            {
                injectionPoints.Add(injectee.Body.Instructions[injectee.Body.Instructions.Count - 1]);
                return;
            }

            foreach (var i in @params.InsertionIndex)
            {
                switch (@params.InsertionType)
                {
                    case InsertionType.ABSOLUTE:
                        injectionPoints.Add(injectee.Body.Instructions[i]);
                        break;
                    case InsertionType.LAST:
                        injectionPoints.Add(injectee.Body.Instructions[injectee.Body.Instructions.Count - 1 - i]);
                        break;
                    case InsertionType.RETURNS:
                        injectionPoints.Add(GetReturnByRelativity(injectee, i));
                        break;
                }
            }
        }

        public void Inject()
        {
            if (invalid) return;

            var hasReturnValue = typeof(DetourEvent).GetProperty("ReturnEarly");
            var hasReturnValueImport = def.MainModule.Import(hasReturnValue.GetMethod);

            var eventReturnValue = typeof(DetourEvent).GetProperty("ReturnValue");
            var eventReturnValueImport = def.MainModule.Import(eventReturnValue.GetMethod);

            var body = injectee.Body;
            var processor = body.GetILProcessor();

            var returnName = injectee.ReturnType.FullName;
            var returnsVoid = returnName.Equals(typeof(void).FullName);

            var returnsPrimitive =
                returnName.Equals(typeof(long).FullName) ||
                returnName.Equals(typeof(ulong).FullName) ||
                returnName.Equals(typeof(int).FullName) ||
                returnName.Equals(typeof(uint).FullName) ||
                returnName.Equals(typeof(short).FullName) ||
                returnName.Equals(typeof(ushort).FullName) ||
                returnName.Equals(typeof(byte).FullName) ||
                returnName.Equals(typeof(bool).FullName);

            foreach (var injectionPoint in injectionPoints)
            {
                var jmpTarget = returnName.Equals(typeof (void).FullName) ? injectionPoint : processor.Create(OpCodes.Pop);

                if (!injectee.IsStatic)
                {
                    processor.InsertBefore(injectionPoint, processor.Create(OpCodes.Ldarg_0));
                }

                if (@params.PushParams)
                {
                    for (var i = 0; i < injectee.Parameters.Count(); i++)
                    {
                        switch (i)
                        {
                            case 0:
                                processor.InsertBefore(injectionPoint, processor.Create(injectee.IsStatic ? OpCodes.Ldarg_0 : OpCodes.Ldarg_1));
                                break;
                            case 1:
                                processor.InsertBefore(injectionPoint, processor.Create(injectee.IsStatic ? OpCodes.Ldarg_1 : OpCodes.Ldarg_2));
                                break;
                            case 2:
                                processor.InsertBefore(injectionPoint, processor.Create(injectee.IsStatic ? OpCodes.Ldarg_2 : OpCodes.Ldarg_3));
                                break;
                            case 3:
                                processor.InsertBefore(injectionPoint, injectee.IsStatic ? processor.Create(OpCodes.Ldarg_3) : processor.Create(OpCodes.Ldarg, i));
                                break;
                            default:
                                processor.InsertBefore(injectionPoint, processor.Create(OpCodes.Ldarg, i));
                                break;
                        }
                    }
                }

                processor.InsertBefore(injectionPoint, processor.Create(OpCodes.Call, callback));
                if (!returnsVoid)
                {
                    processor.InsertBefore(injectionPoint, processor.Create(OpCodes.Dup));
                }
                processor.InsertBefore(injectionPoint, processor.Create(OpCodes.Call, hasReturnValueImport));
                processor.InsertBefore(injectionPoint, processor.Create(OpCodes.Brfalse, jmpTarget));

                if (!returnsVoid)
                {
                    processor.InsertBefore(injectionPoint, processor.Create(OpCodes.Call, eventReturnValueImport));
                }

                if (returnsPrimitive)
                {
                    processor.InsertBefore(injectionPoint, processor.Create(OpCodes.Unbox_Any, injectee.ReturnType));
                }

                processor.InsertBefore(injectionPoint, processor.Create(OpCodes.Ret));
                if (!returnsVoid)
                {
                    processor.InsertBefore(injectionPoint, jmpTarget);
                }
            }
        }

        private Instruction GetReturnByRelativity(MethodDefinition md, int index)
        {
            var instructions = md.Body.Instructions;
            var counter = 0;
            for (var i = 0; i < instructions.Count; i++)
            {
                var ins = instructions[i];
                if (ins.OpCode == OpCodes.Ret)
                {
                    if (counter == index)
                    {
                        return ins;
                    }
                    counter++;
                }
            }
            return null;
        }

        public object GetParams()
        {
            return @params;
        }
    }
}