using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using gAyPI.Manipulation;
using Mono.Cecil;
using Mono.Cecil.Cil;
using System.IO;

namespace gAyPI.StardewValley
{
    public class CecilRewriteEntryInjector : Injector
    {
        private AssemblyDefinition self;
        private AssemblyDefinition def;
        private RewriteEntryInjectorParams @params;

        public CecilRewriteEntryInjector(AssemblyDefinition self, AssemblyDefinition def, RewriteEntryInjectorParams @params)
        {
            this.self = self;
            this.def = def;
            this.@params = @params;
        }

        public void Inject()
        {
            var entry = def.EntryPoint.DeclaringType;
            entry.Attributes = TypeAttributes.Class | 
                TypeAttributes.AutoLayout | 
                TypeAttributes.BeforeFieldInit | 
                TypeAttributes.Public | 
                TypeAttributes.AnsiClass;

            var hasConstructor = entry.Methods.Count(m => m.Name.Equals(".ctor")) > 0;
            var imported = entry.Module.Import(typeof(object).GetConstructor(new Type[0]));
            if (!hasConstructor)
            {
                var method = new MethodDefinition(".ctor", 
                    MethodAttributes.SpecialName | 
                    MethodAttributes.HideBySig | 
                    MethodAttributes.Family | 
                    MethodAttributes.Public | 
                    MethodAttributes.ReuseSlot | 
                    MethodAttributes.RTSpecialName,
                    entry.Module.Import(typeof(void)));

                var processor = method.Body.GetILProcessor();
                processor.Append(processor.Create(OpCodes.Ldarg_0));
                processor.Append(processor.Create(OpCodes.Call, imported));
                processor.Append(processor.Create(OpCodes.Ret));
                entry.Methods.Add(method);
            }
        }

        public object GetParams()
        {
            return @params;
        }
    }
}
