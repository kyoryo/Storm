using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gAyPI.Manipulation
{
    public struct MethodInfoParams
    {
        public string OwnerType { get; set; }
        public string MethodName { get; set; }
        public string MethodDesc { get; set; }
        public string OwnerAccessorType { get; set; }
        public string RefactoredName { get; set; }
    }
}
