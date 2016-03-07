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
    public class CecilAbsoluteCallInjector : Injector
    {
        private readonly AssemblyDefinition def;
        private readonly AssemblyDefinition self;
        private AbsoluteCallParams @params;

        public CecilAbsoluteCallInjector(AssemblyDefinition self, AssemblyDefinition def, AbsoluteCallParams @params)
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
                callingDefinition = self.GetMethod(@params.DetourType, @params.DetourMethodName, @params.DetourMethodDesc);
            }
            if (callingDefinition == null)
            {
                Logging.DebugLogs("[{0}] Could not find callingDefinition!", GetType().Name);
                Logging.DebugLogs("\t{0} {1} {2}", @params.OwnerType, @params.OwnerMethodName, @params.OwnerMethodDesc);
                Logging.DebugLogs("\t{0} {1} {2}", @params.DetourType, @params.DetourMethodDesc, @params.DetourMethodDesc);
                Logging.DebugLogs("\t{0}", @params.InsertionIndex);
                return;
            }

            var injectee = def.GetMethod(@params.OwnerType, @params.OwnerMethodName, @params.OwnerMethodDesc);
            if (injectee == null)
            {
                Logging.DebugLogs("[{0}] Could not find injectee!", GetType().Name);
                Logging.DebugLogs("\t{0} {1} {2}", @params.OwnerType, @params.OwnerMethodName, @params.OwnerMethodDesc);
                Logging.DebugLogs("\t{0} {1} {2}", @params.DetourType, @params.DetourMethodDesc, @params.DetourMethodDesc);
                Logging.DebugLogs("\t{0}", @params.InsertionIndex);
                return;
            }

            var import = injectee.Module.Import(callingDefinition);
            var processor = injectee.Body.GetILProcessor();
            var instructions = injectee.Body.Instructions;
            switch (@params.InsertionType)
            {
                case InsertionType.BEGINNING:
                    processor.InsertBefore(instructions[0], processor.Create(OpCodes.Call, import));
                    break;
                case InsertionType.ABSOLUTE:
                    processor.InsertBefore(instructions[@params.InsertionIndex], processor.Create(OpCodes.Call, import));
                    break;
                case InsertionType.LAST:
                    processor.InsertBefore(instructions[instructions.Count - 1], processor.Create(OpCodes.Call, import));
                    break;
            }
        }

        public object GetParams()
        {
            return @params;
        }
    }
}