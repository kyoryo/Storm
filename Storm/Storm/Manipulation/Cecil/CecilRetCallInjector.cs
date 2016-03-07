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
    public class CecilRetCallInjector
    {
        private readonly AssemblyDefinition self;
        private AssemblyDefinition def;
        private RetCallParams @params;

        public CecilRetCallInjector(AssemblyDefinition self, AssemblyDefinition def, RetCallParams @params)
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
                Logging.DebugLogs("[{0}] Could not find callingDefinition!", GetType().Name);
                Logging.DebugLogs("\t{0} {1} {2}", @params.OwnerType, @params.OwnerMethodName, @params.OwnerMethodDesc);
                Logging.DebugLogs("\t{0} {1} {2}", @params.DetourType, @params.DetourMethodName, @params.DetourMethodDesc);
                return;
            }

            var injectee = self.GetMethod(@params.OwnerType, @params.OwnerMethodName, @params.OwnerMethodDesc);
            if (injectee == null)
            {
                Logging.DebugLogs("[{0}] Could not find injectee!", GetType().Name);
                Logging.DebugLogs("\t{0} {1} {2}", @params.OwnerType, @params.OwnerMethodName, @params.OwnerMethodDesc);
                Logging.DebugLogs("\t{0} {1} {2}", @params.DetourType, @params.DetourMethodName, @params.DetourMethodDesc);
                return;
            }

            var import = injectee.Module.Import(callingDefinition);
            var body = injectee.Body;
            var processor = body.GetILProcessor();
            var instructions = body.Instructions;
            for (var i = 0; i < instructions.Count; i++)
            {
                var ins = instructions[i];
                if (ins.OpCode == OpCodes.Ret)
                {
                    processor.InsertBefore(ins, processor.Create(OpCodes.Call, import));
                }
            }
        }

        public object Params()
        {
            return @params;
        }
    }
}