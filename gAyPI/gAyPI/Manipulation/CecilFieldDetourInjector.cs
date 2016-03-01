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
    public class CecilFieldDetourInjector : Injector
    {
        private AssemblyDefinition self;
        private AssemblyDefinition def;
        private FieldDetourInjectorParams @params;

        public CecilFieldDetourInjector(AssemblyDefinition self, AssemblyDefinition def, FieldDetourInjectorParams @params)
        {
            this.self = self;
            this.def = def;
            this.@params = @params;
        }

        public void Inject()
        {
            // find the method call to replace field refs with
            MethodDefinition callingDefinition = null;
            foreach (var module in self.Modules)
            {
                foreach (var type in module.Types)
                {
                    if (type.FullName.Equals(@params.DetourType))
                    {
                        foreach (var method in type.Methods)
                        {
                            if (method.Name.Equals(@params.DetourMethodName) &&
                                CecilUtils.DescriptionOf(method).Equals(@params.DetourMethodDesc))
                            {
                                callingDefinition = method;
                            }
                        }
                    }
                }
            }

            // find the field, to replace with the method call
            FieldDefinition fieldRef = null;
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
                                fieldRef = field;
                            }
                        }
                    }
                }
            }

            // now replace any references to the field
            var resolved = fieldRef.Resolve();
            foreach (var module in def.Modules)
            {
                var import = module.Import(callingDefinition.Resolve());
                foreach (var type in module.Types)
                {
                    foreach (var method in type.Methods)
                    {
                        if (method.IsAbstract || method.Body == null) continue;

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
            }
        }
    }
}
