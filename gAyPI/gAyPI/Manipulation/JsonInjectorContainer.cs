using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gAyPI.Manipulation
{
    public class JsonInjectorContainer
    {
        public JsonInterfaceInjector[] InterfaceInjectors { get; set; }
        public JsonFieldDetourInjector[] FieldDetourInjectors { get; set; }
        public JsonFieldAccessorInjector[] FieldAccessorInjectors { get; set; }
    }
}
