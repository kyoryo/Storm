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
            var implementingInterface = self.Modules.SelectMany(m => m.Types).FirstOrDefault(t => t.FullName.Equals(@params.InterfaceType));
            var implementer = def.Modules.SelectMany(m => m.Types).FirstOrDefault(t => t.FullName.Equals(@params.OwnerType));
            implementer.Interfaces.Add(implementer.Module.Import(implementingInterface));
        }

        public object GetParams()
        {
            return @params;
        }
    }
}
