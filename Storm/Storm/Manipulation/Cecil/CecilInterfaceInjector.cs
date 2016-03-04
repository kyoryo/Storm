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

                              .       .
                         / `.   .' \
                 .---.  <    > <    >  .---.
                 |    \  \ - ~ ~ - /  /    |
                  ~-..-~             ~-..-~
              \~~~\.'                    `./~~~/
    .-~~^-.    \__/                        \__/
  .'  O    \     /               /       \  \
 (_____,    `._.'               |         }  \/~~~/
  `----.          /       }     |        /    \__/
        `-.      |       /      |       /      `. ,~~|
            ~-.__|      /_ - ~ ^|      /- _      `..-'   f: f:
                 |     /        |     /     ~-.     `-. _||_||_
                 |_____|        |_____|         ~ - . _ _ _ _ _>

 */
using Mono.Cecil;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storm.Manipulation.Cecil
{
    public class CecilInterfaceInjector : Injector
    {
        private AssemblyDefinition self;
        private AssemblyDefinition def;
        private InterfaceParams @params;

        public CecilInterfaceInjector(AssemblyDefinition self, AssemblyDefinition def, InterfaceParams @params)
        {
            this.self = self;
            this.def = def;
            this.@params = @params;
        }

        public void Inject()
        {
            var implementingInterface = self.Modules.SelectMany(m => m.Types).FirstOrDefault(t => t.FullName.Equals(@params.InterfaceType));
            if (implementingInterface == null)
            {
                Logging.DebugLog(String.Format("[CecilFieldMutatorInjector] Could not find implementingInterface {0} {1}", 
                    @params.OwnerType, @params.InterfaceType));
                return;
            }

            var implementer = def.Modules.SelectMany(m => m.Types).FirstOrDefault(t => t.FullName.Equals(@params.OwnerType));
            if (implementer == null)
            {
                Logging.DebugLog(String.Format("[CecilFieldMutatorInjector] Could not find implementer {0} {1}",
                    @params.OwnerType, @params.InterfaceType));
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
