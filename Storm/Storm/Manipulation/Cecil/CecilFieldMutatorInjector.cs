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
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storm.Manipulation.Cecil
{
    public class CecilFieldMutatorInjector : Injector
    {
        private AssemblyDefinition self;
        private AssemblyDefinition def;
        private FieldMutatorParams @params;

        public CecilFieldMutatorInjector(AssemblyDefinition self, AssemblyDefinition def, FieldMutatorParams @params)
        {
            this.self = self;
            this.def = def;
            this.@params = @params;
        }

        public void Inject()
        {
            var gameModule = def.MainModule;
            TypeReference paramType = gameModule.Types.FirstOrDefault(t => t.Resolve().FullName.Equals(@params.ParamType));
            if (paramType == null)
            {
                paramType = gameModule.Import(ReflectionUtils.DynamicResolve(@params.ParamType));
            }
            
            var field = gameModule.Types.
                Where(t => t.FullName.Equals(@params.OwnerType)).
                SelectMany(t => t.Fields).
                FirstOrDefault(f => f.Name.Equals(@params.OwnerFieldName) && f.FieldType.Resolve().FullName.Equals(@params.OwnerFieldType));

            if (paramType == null)
            {
                Logging.DebugLog(String.Format("[CecilFieldMutatorInjector] Could not find paramType {0} {1} {2} {3} {4} {4} {5}",
                     @params.OwnerType, @params.OwnerFieldName, @params.OwnerFieldType,
                     @params.MethodName, @params.ParamType, @params.IsStatic));
                return;
            }

            if (field == null)
            {
                Logging.DebugLog(String.Format("[CecilFieldMutatorInjector] Could not find field {0} {1} {2} {3} {4} {4} {5}",
                     @params.OwnerType, @params.OwnerFieldName, @params.OwnerFieldType,
                     @params.MethodName, @params.ParamType, @params.IsStatic));
                return;
            }

            var method = new MethodDefinition(@params.MethodName, MethodAttributes.Public | MethodAttributes.NewSlot | MethodAttributes.Virtual, gameModule.Import(typeof(void)));
            method.Parameters.Add(new ParameterDefinition(gameModule.Import(paramType)));

            var instructions = method.Body.Instructions;
            var processor = method.Body.GetILProcessor();
            if (!@params.IsStatic)
            {
                instructions.Add(processor.Create(OpCodes.Ldarg_0));
            }
            instructions.Add(processor.Create(@params.IsStatic ? OpCodes.Ldarg_0 : OpCodes.Ldarg_1));
            instructions.Add(processor.Create(OpCodes.Stfld, field));
            instructions.Add(processor.Create(OpCodes.Ret));
            field.DeclaringType.Methods.Add(method);
        }

        public object GetParams()
        {
            return @params;
        }
    }
}
