using Microsoft.Xna.Framework;
using Mono.Cecil;
using Mono.Cecil.Cil;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gAyPI.Manipulation.Cecil
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

        public void Inject()
        {
            var gameModule = def.MainModule;
            TypeReference returnType = gameModule.Types.FirstOrDefault(t => t.Resolve().FullName.Equals(@params.ReturnType));
            if (returnType == null)
            {
                returnType = gameModule.Import(ReflectionUtils.DynamicResolve(@params.ReturnType));
            }

            var field = gameModule.Types.
                Where(t => t.FullName.Equals(@params.OwnerType)).
                SelectMany(t => t.Fields).
                FirstOrDefault(f => f.Name.Equals(@params.OwnerFieldName) && f.FieldType.Resolve().FullName.Equals(@params.OwnerFieldType));
            
            var method = new MethodDefinition(@params.MethodName, MethodAttributes.Public | MethodAttributes.NewSlot | MethodAttributes.Virtual, gameModule.Import(returnType));
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
