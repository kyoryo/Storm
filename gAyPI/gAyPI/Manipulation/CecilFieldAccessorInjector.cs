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
            var module = def.MainModule;

            TypeReference returnType = module.Types.FirstOrDefault(t => t.Resolve().FullName.Equals(@params.ReturnType));
            if (returnType == null)
            {
                returnType = module.Import(ReflectionUtils.DynamicResolve(@params.ReturnType));
            }

            var ownerType = module.Types.Single(t => t.FullName.Equals(@params.OwnerType));
            if (ownerType != null)
            {
                var field = ownerType.Fields.FirstOrDefault(f =>
                    f.Name.Equals(@params.OwnerFieldName) &&
                    f.FieldType.Resolve().FullName.Equals(@params.OwnerFieldType)
                );

                if (field != null)
                {
                    var import = module.Import(returnType);
                    var method = new MethodDefinition(@params.MethodName, MethodAttributes.Public | MethodAttributes.NewSlot | MethodAttributes.Virtual, import);
                    var instructions = method.Body.Instructions;
                    var processor = method.Body.GetILProcessor();
                    if (!@params.IsStatic)
                    {
                        instructions.Add(processor.Create(OpCodes.Ldarg_0));
                    }
                    instructions.Add(processor.Create(OpCodes.Ldfld, field));
                    instructions.Add(processor.Create(OpCodes.Ret));
                    ownerType.Methods.Add(method);
                }
                else
                {
                    Logging.Log("null " + @params.OwnerFieldName + " ");
                    Array.ForEach(ownerType.Fields.ToArray(), f => Logging.Log(f.Name + " " + @params.OwnerFieldType + " " + f.FieldType.Resolve().FullName));
                }
            }
        }

        public object GetParams()
        {
            return @params;
        }
    }
}
