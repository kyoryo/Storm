using Mono.Cecil;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gAyPI.Manipulation
{
    public class CecilInterfaceInjector : Injector
    {
        private AssemblyDefinition self;
        private AssemblyDefinition def;
        private InterfaceInjectorParams @params;

        public CecilInterfaceInjector(AssemblyDefinition self, AssemblyDefinition def, InterfaceInjectorParams @params)
        {
            this.self = self;
            this.def = def;
            this.@params = @params;
        }

        public void Inject()
        {
            TypeReference implementingInterface = null;
            foreach (var module in self.Modules)
            {
                foreach (var type in module.Types)
                {
                    if (type.FullName.Equals(@params.InterfaceType))
                    {
                        implementingInterface = type;
                    }
                }
            }

            foreach (var module in def.Modules)
            {
                var import = module.Import(implementingInterface);
                foreach (var type in module.Types)
                {
                    if (type.FullName.Equals(@params.OwnerType))
                    {
                        type.Interfaces.Add(import);
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
