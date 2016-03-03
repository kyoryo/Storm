using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gAyPI.Manipulation.Json
{
    public class JsonAbsoluteCallParams
    {
        public string OwnerAccessorType { get; set; }
        public string OwnerMethodName { get; set; }
        public string OwnerMethodDesc { get; set; }
        public string DetourType { get; set; }
        public string DetourMethodName { get; set; }
        public string DetourMethodDesc { get; set; }
        public int InsertionIndex { get; set; }
    }
}
