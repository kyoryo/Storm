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

namespace Storm.Manipulation.Cecil
{
    public class CecilFieldAccessorInjector : Injector
    {
        private AssemblyDefinition self;
        private AssemblyDefinition def;
        private FieldAccessorParams @params;

        public CecilFieldAccessorInjector(AssemblyDefinition self, AssemblyDefinition def, FieldAccessorParams @params)
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
            TypeReference returnType = def.GetTypeRef(@params.ReturnType, true);
            var field = def.GetField(@params.OwnerType, @params.OwnerFieldName, @params.OwnerFieldType);

            if (returnType == null)
            {
                Logging.DebugLog(String.Format("[CecilFieldAccessorInjector] Could not find returnType {0} {1} {2} {3} {4} {4} {5}",
                     @params.OwnerType, @params.OwnerFieldName,  @params.OwnerFieldType, 
                     @params.MethodName, @params.ReturnType, @params.IsStatic));
                return;
            }
            
            if (field == null)
            {
                Logging.DebugLog(String.Format("[CecilFieldAccessorInjector] Could not find field {0} {1} {2} {3} {4} {4} {5}",
                     @params.OwnerType, @params.OwnerFieldName,  @params.OwnerFieldType, 
                     @params.MethodName, @params.ReturnType,  @params.IsStatic));
                return;
            }

            var method = new MethodDefinition(@params.MethodName, MethodAttributes.Public | MethodAttributes.NewSlot | MethodAttributes.Virtual, def.MainModule.Import(returnType));
            var instructions = method.Body.Instructions;
            var processor = method.Body.GetILProcessor();
            if (!@params.IsStatic)
            {
                instructions.Add(processor.Create(OpCodes.Ldarg_0));
            }
            instructions.Add(processor.Create(OpCodes.Ldfld, field));
            instructions.Add(processor.Create(OpCodes.Ret));
            field.DeclaringType.Methods.Add(method);
        }

        public object GetParams()
        {
            return @params;
        }
    }
}
