using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storm.Manipulation.Json
{
    public class JsonFieldMutatorParams
    {
        public string OwnerAccessorType { get; set; }
        public string OwnerFieldType { get; set; }
        public string OwnerFieldName { get; set; }
        public string MethodName { get; set; }
        public string ParamType { get; set; }
        public bool IsStatic { get; set; }
    }
}
