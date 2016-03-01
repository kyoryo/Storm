using Mono.Cecil;
using Mono.Cecil.Cil;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gAyPI.Manipulation
{
    public class CecilRetCallInjector
    {
        private AssemblyDefinition self;
        private AssemblyDefinition def;
        private RetCallInjectorParams @params;

        public CecilRetCallInjector(AssemblyDefinition self, AssemblyDefinition def, RetCallInjectorParams @params)
        {
            this.self = self;
            this.def = def;
            this.@params = @params;
        }

        public void Inject()
        {
            // find the method call to insert before every return
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

            // insert the calls before every return
            foreach (var module in def.Modules)
            {
                var import = module.Import(callingDefinition.Resolve());
                foreach (var type in module.Types)
                {
                    if (type.FullName.Equals(@params.OwnerType))
                    {
                        foreach (var method in type.Methods)
                        {
                            if (!method.HasBody) continue;

                            if (method.Name.Equals(@params.OwnerMethodName) &&
                                CecilUtils.DescriptionOf(method).Equals(@params.OwnerMethodDesc))
                            {
                                var processor = method.Body.GetILProcessor();
                                var instructions = method.Body.Instructions;
                                for (int i = 0; i < instructions.Count; i++)
                                {
                                    var ins = instructions[i];
                                    if (ins.OpCode == OpCodes.Ret)
                                    {
                                        processor.InsertBefore(ins, processor.Create(OpCodes.Call, import));
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
