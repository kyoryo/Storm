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
        private readonly AssemblyDefinition _self;
        private AssemblyDefinition _def;
        private RetCallParams _params;

        public CecilRetCallInjector(AssemblyDefinition self, AssemblyDefinition def, RetCallParams @params)
        {
            _self = self;
            _def = def;
            _params = @params;
        }

        public void Init()
        {
        }

        public void Inject()
        {
            var callingDefinition = _self.GetMethod(_params.DetourType, _params.DetourMethodName, _params.DetourMethodDesc);
            if (callingDefinition == null)
            {
                Logging.DebugLogs("[{0}] Could not find callingDefinition!", GetType().Name);
                Logging.DebugLogs("\t{0} {1} {2}", _params.OwnerType, _params.OwnerMethodName, _params.OwnerMethodDesc);
                Logging.DebugLogs("\t{0} {1} {2}", _params.DetourType, _params.DetourMethodName, _params.DetourMethodDesc);
                return;
            }

            var injectee = _self.GetMethod(_params.OwnerType, _params.OwnerMethodName, _params.OwnerMethodDesc);
            if (injectee == null)
            {
                Logging.DebugLogs("[{0}] Could not find injectee!", GetType().Name);
                Logging.DebugLogs("\t{0} {1} {2}", _params.OwnerType, _params.OwnerMethodName, _params.OwnerMethodDesc);
                Logging.DebugLogs("\t{0} {1} {2}", _params.DetourType, _params.DetourMethodName, _params.DetourMethodDesc);
                return;
            }

            var import = injectee.Module.Import(callingDefinition);
            var body = injectee.Body;
            var processor = body.GetILProcessor();
            var instructions = body.Instructions;
            foreach (var ins in instructions)
            {
                if (ins.OpCode == OpCodes.Ret)
                {
                    processor.InsertBefore(ins, processor.Create(OpCodes.Call, import));
                }
            }
        }

        public object Params()
        {
            return _params;
        }
    }
}