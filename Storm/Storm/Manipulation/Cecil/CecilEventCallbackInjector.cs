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

        private readonly List<Instruction> injectionPoints = new List<Instruction>();
        private readonly EventCallbackParams @params;
        private readonly AssemblyDefinition self;
        private MethodReference callback;
        private MethodDefinition injectee;
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

            var paramCount = injectee.IsStatic ? 0 : 1;
            if (@params.PushParams)
            {
                paramCount += injectee.Parameters.Count;
            }

            callback = injectee.Module.Import(recv);
            if (paramCount != callback.Parameters.Count)
            {
                Logging.DebugLogs("[{0}] Invalid param count on callback!", GetType().Name);
                Logging.DebugLogs("\t{0} {1} {2}", @params.OwnerType, @params.OwnerMethodName, @params.OwnerMethodDesc);
                Logging.DebugLogs("\t{0} {1}", @params.InstanceCallbackName, @params.InstanceCallbackDesc);
                Logging.DebugLogs("\t{0} {1}", @params.StaticCallbackName, @params.StaticCallbackDesc);
                Logging.DebugLogs("\t{0}", @params.InsertionIndex);
                invalid = true;
                return;
            }

            var injecteeBody = injectee.Body;
            var injecteeInstructions = injecteeBody.Instructions;
            var injecteeInsCount = injecteeInstructions.Count;
            if (@params.InsertionType == InsertionType.BEGINNING)
            {
                injectionPoints.Add(injecteeInstructions[0]);
                return;
            }

            if (@params.InsertionType == InsertionType.LAST && @params.InsertionIndex == null)
            {
                injectionPoints.Add(injecteeInstructions[injecteeInsCount - 1]);
                return;
            }

            foreach (var i in @params.InsertionIndex)
            {
                switch (@params.InsertionType)
                {
                    case InsertionType.ABSOLUTE:
                        if (i < 0 || i >= injecteeInsCount)
                        {
                            Logging.DebugLogs("[{0}] Instruction {1} out of bounds", GetType().Name, i);
                            Logging.DebugLogs("\t{0} {1} {2}", @params.OwnerType, @params.OwnerMethodName, @params.OwnerMethodDesc);
                            Logging.DebugLogs("\t{0} {1}", @params.InstanceCallbackName, @params.InstanceCallbackDesc);
                            Logging.DebugLogs("\t{0} {1}", @params.StaticCallbackName, @params.StaticCallbackDesc);
                            Logging.DebugLogs("\t{0}", @params.InsertionIndex);
                            invalid = true;
                            return;
                        }

                        injectionPoints.Add(injecteeInstructions[i]);
                        break;
                    case InsertionType.LAST:
                        if ((injecteeInsCount - 1 - i) < 0 || (injecteeInsCount - 1 - i) >= injecteeInsCount)
                        {
                            Logging.DebugLogs("[{0}] Instruction {1} out of bounds", GetType().Name, i);
                            Logging.DebugLogs("\t{0} {1} {2}", @params.OwnerType, @params.OwnerMethodName, @params.OwnerMethodDesc);
                            Logging.DebugLogs("\t{0} {1}", @params.InstanceCallbackName, @params.InstanceCallbackDesc);
                            Logging.DebugLogs("\t{0} {1}", @params.StaticCallbackName, @params.StaticCallbackDesc);
                            Logging.DebugLogs("\t{0}", @params.InsertionIndex);
                            invalid = true;
                            return;
                        }

                        injectionPoints.Add(injecteeInstructions[injecteeInsCount - 1 - i]);
                        break;
                    case InsertionType.RETURNS:
                        var relative = GetReturnByRelativity(injectee, i);
                        if (relative == null)
                        {
                            Logging.DebugLogs("[{0}] Unable to find return {1}", GetType().Name, i);
                            Logging.DebugLogs("\t{0} {1} {2}", @params.OwnerType, @params.OwnerMethodName, @params.OwnerMethodDesc);
                            Logging.DebugLogs("\t{0} {1}", @params.InstanceCallbackName, @params.InstanceCallbackDesc);
                            Logging.DebugLogs("\t{0} {1}", @params.StaticCallbackName, @params.StaticCallbackDesc);
                            Logging.DebugLogs("\t{0}", @params.InsertionIndex);
                            invalid = true;
                            return;
                        }
                        injectionPoints.Add(relative);
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

            var returnsPrimitive = CecilUtils.IsNativeType(returnName);

            foreach (var injectionPoint in injectionPoints)
            {
                var jmpTarget = returnsVoid ? injectionPoint : processor.Create(OpCodes.Pop);

                Instruction initial = null;
                if (!injectee.IsStatic)
                {
                    processor.InsertBefore(injectionPoint, initial = processor.Create(OpCodes.Ldarg_0));
                }

                if (@params.PushParams)
                {
                    for (var i = 0; i < injectee.Parameters.Count(); i++)
                    {
                        switch (i)
                        {
                            case 0:
                                {
                                    var ins = processor.Create(injectee.IsStatic ? OpCodes.Ldarg_0 : OpCodes.Ldarg_1);
                                    if (initial == null) initial = ins;
                                    processor.InsertBefore(injectionPoint, ins);
                                }
                                break;

                            case 1:
                                {
                                    var ins = processor.Create(injectee.IsStatic ? OpCodes.Ldarg_1 : OpCodes.Ldarg_2);
                                    if (initial == null) initial = ins;
                                    processor.InsertBefore(injectionPoint, ins);
                                }
                                break;

                            case 2:
                                {
                                    var ins = processor.Create(injectee.IsStatic ? OpCodes.Ldarg_2 : OpCodes.Ldarg_3);
                                    if (initial == null) initial = ins;
                                    processor.InsertBefore(injectionPoint, ins);
                                }
                                break;

                            case 3:
                                {
                                    var ins = injectee.IsStatic ? processor.Create(OpCodes.Ldarg_3) : processor.Create(OpCodes.Ldarg, i + (injectee.IsStatic ? 0 : 1));
                                    if (initial == null) initial = ins;
                                    processor.InsertBefore(injectionPoint, ins);
                                }
                                break;

                            default:
                                {
                                    var ins = processor.Create(OpCodes.Ldarg, i + (injectee.IsStatic ? 0 : 1));
                                    if (initial == null) initial = ins;
                                    processor.InsertBefore(injectionPoint, ins);
                                }
                                break;
                        }
                    }
                }

                var callbackCall = processor.Create(OpCodes.Call, callback);
                if (initial == null) initial = callbackCall;

                processor.InsertBefore(injectionPoint, callbackCall);
                if (!returnsVoid)
                {
                    processor.InsertBefore(injectionPoint, processor.Create(OpCodes.Dup));
                }
                processor.InsertBefore(injectionPoint, processor.Create(OpCodes.Call, hasReturnValueImport));

                var continueNormalJump = processor.Create(OpCodes.Brfalse, jmpTarget);
                processor.InsertBefore(injectionPoint, continueNormalJump);

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

                if (@params.JumpFix)
                {
                    foreach (var instruction in body.Instructions.Where(i => i != continueNormalJump))
                    {
                        if (CecilUtils.IsJump(instruction.OpCode))
                        {
                            var idx = body.Instructions.IndexOf(instruction.Operand as Instruction);
                            var targetIdx = body.Instructions.IndexOf(jmpTarget);
                            if (instruction.Operand == injectionPoint)
                            {
                                instruction.Operand = initial;
                            }
                        }
                    }
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