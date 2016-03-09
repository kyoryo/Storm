using Mono.Cecil;
using Mono.Cecil.Cil;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storm.Manipulation.Cecil
{
    public class CecilConstructorReplacer : Injector
    {
        private readonly AssemblyDefinition def;
        private readonly AssemblyDefinition self;
        private readonly ConstructorReplacerParams @params;

        public CecilConstructorReplacer(AssemblyDefinition self, AssemblyDefinition def, ConstructorReplacerParams @params)
        {
            this.self = self;
            this.def = def;
            this.@params = @params;
        }

        public void Init()
        {
            
        }

        public void Inject()
        {
            var from = def.GetTypeRef(@params.FromClass);
            if (from == null)
            {
                from = self.GetTypeRef(@params.FromClass, true);
            }

            if (from == null)
            {
                Logging.DebugLogs("[{0}] Unable to find from type", GetType().Name);
                Logging.DebugLogs("\t{0} {1}", @params.FromClass, @params.ToClass);
                return;
            }

            var to = def.GetTypeRef(@params.ToClass);
            if (to == null)
            {
                to = self.GetTypeRef(@params.ToClass, true);
            }

            if (to == null)
            {
                Logging.DebugLogs("[{0}] Unable to find to type", GetType().Name);
                Logging.DebugLogs("\t{0} {1}", @params.FromClass, @params.ToClass);
                return;
            }

            var froms = from.Resolve().Methods.Where(m => m.Name.Equals(".ctor"));
            var tos = to.Resolve().Methods.Where(m => m.Name.Equals(".ctor"));

            var methods = def.Modules.SelectMany(m => m.Types).SelectMany(t => t.Methods).ToList();
            foreach (var method in methods)
            {
                foreach (var ins in method.Body.Instructions)
                {
                    if (ins.OpCode == OpCodes.Call || ins.OpCode == OpCodes.Callvirt)
                    {
                        var @ref = (MethodReference)ins.Operand;
                        if (froms.Contains(@ref.Resolve()))
                        {
                            var toMatching = tos.Where(m => m.Parameters.Count == @ref.Parameters.Count).FirstOrDefault();
                            if (toMatching != null)
                            {
                                Logging.DebugLog("bluuuh");
                            }
                        }
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
