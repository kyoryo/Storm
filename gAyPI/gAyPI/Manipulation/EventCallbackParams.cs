using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gAyPI.Manipulation
{
    public struct EventCallbackParams
    {
        public string OwnerType { get; set; }
        public string OwnerMethodName { get; set; }
        public string OwnerMethodDesc { get; set; }
        public string CallbackType { get; set; }
        public string InstanceCallbackName { get; set; }
        public string InstanceCallbackDesc { get; set; }
        public string StaticCallbackName { get; set; }
        public string StaticCallbackDesc { get; set; }
        public int InsertionIndex { get; set; }
    }
}
