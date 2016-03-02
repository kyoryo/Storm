using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gAyPI.Manipulation
{
    public class FieldInfoInjector : Injector
    {
        private FieldInfoParams @params;

        public FieldInfoInjector(FieldInfoParams @params)
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
