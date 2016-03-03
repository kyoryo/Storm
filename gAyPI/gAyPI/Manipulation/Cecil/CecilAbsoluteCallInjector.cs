using Mono.Cecil;
using Mono.Cecil.Cil;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gAyPI.Manipulation.Cecil
{
    public class CecilAbsoluteCallInjector : Injector
    {
        private AssemblyDefinition self;
        private AssemblyDefinition def;
        private AbsoluteCallParams @params;

        public CecilAbsoluteCallInjector(AssemblyDefinition self, AssemblyDefinition def, AbsoluteCallParams @params)
        {
            this.self = self;
            this.def = def;
            this.@params = @params;
        }

        public void Inject()
        {
            var callingDefinition = self.Modules.
                SelectMany(m => m.Types).
                Where(t => t.FullName.Equals(@params.DetourType)).
                SelectMany(t => t.Methods).
                FirstOrDefault(m => m.Name.Equals(@params.DetourMethodName) && CecilUtils.DescriptionOf(m).Equals(@params.DetourMethodDesc));

            var injectee = def.Modules.
                SelectMany(m => m.Types).
                Where(t => t.FullName.Equals(@params.OwnerType)).
                SelectMany(t => t.Methods).
                FirstOrDefault(m => m.Name.Equals(@params.OwnerMethodName) && CecilUtils.DescriptionOf(m).Equals(@params.OwnerMethodDesc));

            var import = injectee.Module.Import(callingDefinition);
            var processor = injectee.Body.GetILProcessor();
            var instructions = injectee.Body.Instructions;
            processor.InsertBefore(instructions[@params.InsertionIndex], processor.Create(OpCodes.Call, import));
        }

        public object GetParams()
        {
            return @params;
        }
    }
}
