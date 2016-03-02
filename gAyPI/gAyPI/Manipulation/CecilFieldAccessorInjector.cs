using Microsoft.Xna.Framework;
using Mono.Cecil;
using Mono.Cecil.Cil;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gAyPI.Manipulation
{
    public class CecilFieldAccessorInjector : Injector
    {
        private AssemblyDefinition self;
        private AssemblyDefinition def;
        private FieldAccessorInjectorParams @params;

        public CecilFieldAccessorInjector(AssemblyDefinition self, AssemblyDefinition def, FieldAccessorInjectorParams @params)
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

            var import = gameModule.Import(returnType);
            var method = new MethodDefinition(@params.MethodName, MethodAttributes.Public | MethodAttributes.NewSlot | MethodAttributes.Virtual, import);
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
