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
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storm.Manipulation.Cecil
{
    public class CecilFieldDetourInjector : Injector
    {
        private AssemblyDefinition self;
        private AssemblyDefinition def;
        private FieldDetourParams @params;

        public CecilFieldDetourInjector(AssemblyDefinition self, AssemblyDefinition def, FieldDetourParams @params)
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
                FirstOrDefault(m => m.Name.Equals(@params.DetourMethodName) &&  CecilUtils.DescriptionOf(m).Equals(@params.DetourMethodDesc));
            if (callingDefinition == null)
            {
                callingDefinition = def.Modules.
                SelectMany(m => m.Types).
                Where(t => t.FullName.Equals(@params.DetourType)).
                SelectMany(t => t.Methods).
                FirstOrDefault(m => m.Name.Equals(@params.DetourMethodName) && CecilUtils.DescriptionOf(m).Equals(@params.DetourMethodDesc));
            }

            var fieldRef = def.Modules.
                SelectMany(m => m.Types).
                Where(t => t.FullName.Equals(@params.OwnerType)).
                SelectMany(t => t.Fields).
                FirstOrDefault(f => f.Name.Equals(@params.OwnerFieldName) && f.FieldType.Resolve().FullName.Equals(@params.OwnerFieldType));

            if (callingDefinition == null)
            {
                Logging.DebugLog(String.Format("[CecilFieldDetourInjector] Could not find callingDefinition {0} {1} {2} {3} {4} {4} {5}",
                    @params.OwnerType, @params.OwnerFieldName, @params.OwnerFieldType,
                    @params.DetourType, @params.DetourMethodDesc, @params.DetourMethodDesc));
                return;
            }

            if (fieldRef == null)
            {
                Logging.DebugLog(String.Format("[CecilFieldDetourInjector] Could not find fieldRef {0} {1} {2} {3} {4} {4} {5}",
                    @params.OwnerType, @params.OwnerFieldName, @params.OwnerFieldType,
                    @params.DetourType, @params.DetourMethodDesc, @params.DetourMethodDesc));
                return;
            }

            var resolved = fieldRef.Resolve();
            var methods = def.Modules.SelectMany(m => m.Types).
                SelectMany(t => t.Methods).
                Where(m => m.HasBody && m != callingDefinition && m.Body.Instructions.
                    FirstOrDefault(i => CecilUtils.IsGettingField(i) && i.Operand is FieldReference) != null);

            foreach (var method in methods)
            {
                var import = method.Module.Import(callingDefinition.Resolve());
                var processor = method.Body.GetILProcessor();
                var instructions = method.Body.Instructions;
                for (int i = 0; i < instructions.Count; i++)
                {
                    var ins = instructions[i];
                    if (CecilUtils.IsGettingField(ins) && (ins.Operand is FieldReference))
                    {
                        var casted = ins.Operand as FieldReference;
                        if (casted.Resolve() == resolved)
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
