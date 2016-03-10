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

namespace Storm.Manipulation.Cecil
{
    public class CecilInterfaceInjector : Injector
    {
        private readonly AssemblyDefinition def;
        private readonly AssemblyDefinition self;
        private InterfaceParams @params;

        public CecilInterfaceInjector(AssemblyDefinition self, AssemblyDefinition def, InterfaceParams @params)
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
            var implementingInterface = self.GetTypeDef(@params.InterfaceType);
            if (implementingInterface == null)
            {
                Logging.DebugLogs("[{0}] Could not find implementingInterface!", GetType().Name);
                Logging.DebugLogs("\t{0} {1}", @params.OwnerType, @params.InterfaceType);
                return;
            }

            var implementer = def.GetTypeDef(@params.OwnerType);
            if (implementer == null)
            {
                Logging.DebugLogs("[{0}] Could not find implementer!", GetType().Name);
                Logging.DebugLogs("\t{0} {1}", @params.OwnerType, @params.InterfaceType);
                return;
            }

            implementer.Interfaces.Add(implementer.Module.Import(implementingInterface));
        }

        public object GetParams()
        {
            return @params;
        }
    }
}