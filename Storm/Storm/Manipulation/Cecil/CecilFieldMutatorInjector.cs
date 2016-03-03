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
