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
    public class CecilFieldDetourInjector : Injector
    {
        private readonly AssemblyDefinition def;
        private readonly AssemblyDefinition self;
        private FieldDetourParams @params;

        public CecilFieldDetourInjector(AssemblyDefinition self, AssemblyDefinition def, FieldDetourParams @params)
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
            var callingDefinition = self.GetMethod(@params.DetourType, @params.DetourMethodName, @params.DetourMethodDesc);
            if (callingDefinition == null)
            {
                callingDefinition = def.GetMethod(@params.DetourType, @params.DetourMethodName, @params.DetourMethodDesc);
            }
            if (callingDefinition == null)
            {
                Logging.DebugLogs("[{0}] Could not find callingDefinition!", GetType().Name);
                Logging.DebugLogs("\t{0} {1} {2}", @params.OwnerType, @params.OwnerFieldName, @params.OwnerFieldType);
                Logging.DebugLogs("\t{0} {1} {2}", @params.DetourType, @params.DetourMethodName, @params.DetourMethodDesc);
                return;
            }

            var fieldRef = def.GetField(@params.OwnerType, @params.OwnerFieldName, @params.OwnerFieldType);
            if (fieldRef == null)
            {
                Logging.DebugLogs("[{0}] Could not find fieldRef!", GetType().Name);
                Logging.DebugLogs("\t{0} {1} {2}", @params.OwnerType, @params.OwnerFieldName, @params.OwnerFieldType);
                Logging.DebugLogs("\t{0} {1} {2}", @params.DetourType, @params.DetourMethodName, @params.DetourMethodDesc);
                return;
            }

            var methods = def.FindRefences(fieldRef, callingDefinition);
            foreach (var method in methods)
            {
                var import = method.Module.Import(callingDefinition.Resolve());
                var processor = method.Body.GetILProcessor();
                var instructions = method.Body.Instructions;
                for (var i = 0; i < instructions.Count; i++)
                {
                    var ins = instructions[i];
                    if (CecilUtils.IsGettingField(ins) && ins.Operand is FieldReference)
                    {
                        var casted = ins.Operand as FieldReference;
                        if (casted.Resolve() == fieldRef.Resolve())
                        {
                            instructions[i] = processor.Create(OpCodes.Call, import);
                        }
                    }
                }
            }
        }

        public object GetParams()
        {
            return @params;
        }
    }
}