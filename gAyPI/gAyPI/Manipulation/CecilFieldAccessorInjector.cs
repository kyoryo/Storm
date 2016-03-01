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
            foreach (var module in def.Modules)
            {
                foreach (var type in module.Types)
                {
                    if (type.FullName.Equals(@params.OwnerType))
                    {
                        foreach (var field in type.Fields)
                        {
                            if (field.Name.Equals(@params.OwnerFieldName) &&
                                field.FieldType.Resolve().FullName.Equals(@params.OwnerFieldType))
                            {
                                var method = new MethodDefinition(@params.MethodName, MethodAttributes.Public | MethodAttributes.NewSlot | MethodAttributes.Final | MethodAttributes.Virtual, field.FieldType.Resolve());
                                var instructions = method.Body.Instructions;
                                var processor = method.Body.GetILProcessor();
                                instructions.Add(processor.Create(OpCodes.Ldarg_0));
                                instructions.Add(processor.Create(OpCodes.Ldfld, field));
                                instructions.Add(processor.Create(OpCodes.Ret));
                                type.Methods.Add(method);
                                Logging.Log("Injected");
                            }
                        }
                    }
                }
            }

            var fs = new FileStream("bleh.exe", FileMode.Create);
            def.Write(fs);
            fs.Close();
        }
    }
}
