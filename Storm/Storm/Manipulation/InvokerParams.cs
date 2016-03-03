using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storm.Manipulation
{
    public struct InvokerParams
    {
        public string OwnerType { get; set; }
        public string OwnerMethodName { get; set; }
        public string OwnerMethodDesc { get; set; }
        public string InvokerName { get; set; }
        public string[] InvokerReturnParams { get; set; }
        public string InvokerReturnType { get; set; }
        public bool IsStatic { get; set; }
    }
}
