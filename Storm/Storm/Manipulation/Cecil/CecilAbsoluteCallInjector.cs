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
    public class CecilAbsoluteCallInjector : IInjector
    {
        private readonly AssemblyDefinition _def;
        private readonly AssemblyDefinition _self;
        private AbsoluteCallParams _params;

        public CecilAbsoluteCallInjector(AssemblyDefinition self, AssemblyDefinition def, AbsoluteCallParams @params)
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
            var callingDefinition = _self.GetMethod(_params.DetourType, _params.DetourMethodName, _params.DetourMethodDesc) ?? _self.GetMethod(_params.DetourType, _params.DetourMethodName, _params.DetourMethodDesc);

            if (callingDefinition == null)
            {
                Logging.DebugLogs("[{0}] Could not find callingDefinition!", GetType().Name);
                Logging.DebugLogs("\t{0} {1} {2}", _params.OwnerType, _params.OwnerMethodName, _params.OwnerMethodDesc);
                Logging.DebugLogs("\t{0} {1} {2}", _params.DetourType, _params.DetourMethodDesc, _params.DetourMethodDesc);
                Logging.DebugLogs("\t{0}", _params.InsertionIndex);
                return;
            }

            var injectee = _def.GetMethod(_params.OwnerType, _params.OwnerMethodName, _params.OwnerMethodDesc);
            if (injectee == null)
            {
                Logging.DebugLogs("[{0}] Could not find injectee!", GetType().Name);
                Logging.DebugLogs("\t{0} {1} {2}", _params.OwnerType, _params.OwnerMethodName, _params.OwnerMethodDesc);
                Logging.DebugLogs("\t{0} {1} {2}", _params.DetourType, _params.DetourMethodDesc, _params.DetourMethodDesc);
                Logging.DebugLogs("\t{0}", _params.InsertionIndex);
                return;
            }

            var import = injectee.Module.Import(callingDefinition);
            var processor = injectee.Body.GetILProcessor();
            var instructions = injectee.Body.Instructions;
            switch (_params.InsertionType)
            {
                case InsertionType.Beginning:
                    processor.InsertBefore(instructions[0], processor.Create(OpCodes.Call, import));
                    break;
                case InsertionType.Absolute:
                    processor.InsertBefore(instructions[_params.InsertionIndex], processor.Create(OpCodes.Call, import));
                    break;
                case InsertionType.Last:
                    processor.InsertBefore(instructions[instructions.Count - 1], processor.Create(OpCodes.Call, import));
                    break;
            }
        }

        public object GetParams()
        {
            return _params;
        }
    }
}