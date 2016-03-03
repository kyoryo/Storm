using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gAyPI.Manipulation.Json
{
    public class JsonInvokerParams
    {
        public string OwnerAccessorType { get; set; }
        public string OwnerMethodName { get; set; }
        public string OwnerMethodDesc { get; set; }
        public string InvokerName { get; set; }
        public string[] InvokerReturnParams { get; set; }
        public string InvokerReturnType { get; set; }
        public bool IsStatic { get; set; }
    }
}
