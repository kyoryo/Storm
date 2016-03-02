using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gAyPI.Manipulation
{
    public class MethodInfoInjector : Injector
    {
        private MethodInfoParams @params;

        public MethodInfoInjector(MethodInfoParams @params)
        {
            this.@params = @params;
        }

        public void Inject()
        {

        }

        public object GetParams()
        {
            return @params;
        }
    }
}
