using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gAyPI.Manipulation
{
    public class JsonFieldDetourParams
    {
        public string OwnerAccessorType { get; set; }
        public string OwnerFieldType { get; set; }
        public string OwnerFieldName { get; set; }
        public string DetourType { get; set; }
        public string DetourMethodName { get; set; }
        public string DetourMethodDesc { get; set; }
    }
}
