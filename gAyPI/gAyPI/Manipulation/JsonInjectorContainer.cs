using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gAyPI.Manipulation
{
    public class JsonInjectorContainer
    {
        public JsonInterfaceParams[] InterfaceParams { get; set; }
        public JsonFieldDetourParams[] FieldDetourParams { get; set; }
        public JsonFieldAccessorParams[] FieldAccessorParams { get; set; }
        public JsonFieldMutatorParams[] FieldMutatorParams { get; set; }
        public JsonAbsoluteCallParams[] AbsoluteCallParams { get; set; }
        public JsonFieldInfoParams[] FieldInfoParams { get; set; }
        public JsonMethodInfoParams[] MethodInfoParams { get; set; }
    }
}
