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
using Mono.Cecil.Cil;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storm.Manipulation.Cecil
{
    public class CecilAbsoluteCallInjector : Injector
    {
        private AssemblyDefinition self;
        private AssemblyDefinition def;
        private AbsoluteCallParams @params;

        public CecilAbsoluteCallInjector(AssemblyDefinition self, AssemblyDefinition def, AbsoluteCallParams @params)
        {
            this.self = self;
            this.def = def;
            this.@params = @params;
        }

        public void Inject()
        {
            var callingDefinition = self.Modules.
                SelectMany(m => m.Types).
                Where(t => t.FullName.Equals(@params.DetourType)).
                SelectMany(t => t.Methods).
                FirstOrDefault(m => m.Name.Equals(@params.DetourMethodName) && CecilUtils.DescriptionOf(m).Equals(@params.DetourMethodDesc));

            var injectee = def.Modules.
                SelectMany(m => m.Types).
                Where(t => t.FullName.Equals(@params.OwnerType)).
                SelectMany(t => t.Methods).
                FirstOrDefault(m => m.Name.Equals(@params.OwnerMethodName) && CecilUtils.DescriptionOf(m).Equals(@params.OwnerMethodDesc));

            var import = injectee.Module.Import(callingDefinition);
            var processor = injectee.Body.GetILProcessor();
            var instructions = injectee.Body.Instructions;
            processor.InsertBefore(instructions[@params.InsertionIndex], processor.Create(OpCodes.Call, import));
        }

        public object GetParams()
        {
            return @params;
        }
    }
}
