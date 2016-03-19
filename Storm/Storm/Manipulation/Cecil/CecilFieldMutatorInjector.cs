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
    public class CecilFieldMutatorInjector : Injector
    {
        private readonly AssemblyDefinition _def;
        private FieldMutatorParams _params;
        private AssemblyDefinition _self;

        public CecilFieldMutatorInjector(AssemblyDefinition self, AssemblyDefinition def, FieldMutatorParams @params)
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
            var paramType = _def.GetTypeRef(_params.ParamType, true);
            if (paramType == null)
            {
                Logging.DebugLogs("[{0}] Could not find paramType!", GetType().Name);
                Logging.DebugLogs("\t{0} {1} {2}", _params.OwnerType, _params.OwnerFieldName, _params.OwnerFieldType);
                Logging.DebugLogs("\t{0} {1} {2}", _params.MethodName, _params.ParamType, _params.IsStatic);
                return;
            }

            var field = _def.GetField(_params.OwnerType, _params.OwnerFieldName, _params.OwnerFieldType);
            if (field == null)
            {
                Logging.DebugLogs("[{0}] Could not find field!", GetType().Name);
                Logging.DebugLogs("\t{0} {1} {2}", _params.OwnerType, _params.OwnerFieldName, _params.OwnerFieldType);
                Logging.DebugLogs("\t{0} {1} {2}", _params.MethodName, _params.ParamType, _params.IsStatic);
                return;
            }

            var method = new MethodDefinition(_params.MethodName, MethodAttributes.Public | MethodAttributes.NewSlot | MethodAttributes.Virtual, _def.Import(typeof(void)));
            method.Parameters.Add(new ParameterDefinition(_def.Import(paramType)));

            var instructions = method.Body.Instructions;
            var processor = method.Body.GetILProcessor();
            if (!_params.IsStatic)
            {
                instructions.Add(processor.Create(OpCodes.Ldarg_0));
            }
            instructions.Add(processor.Create(_params.IsStatic ? OpCodes.Ldarg_0 : OpCodes.Ldarg_1));
            instructions.Add(processor.Create(OpCodes.Stfld, field));
            instructions.Add(processor.Create(OpCodes.Ret));
            field.DeclaringType.Methods.Add(method);
        }

        public object GetParams()
        {
            return _params;
        }
    }
}