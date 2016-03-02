using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gAyPI.Manipulation
{
    public struct FieldMutatorParams
    {
        public string OwnerType { get; set; }
        public string OwnerFieldType { get; set; }
        public string OwnerFieldName { get; set; }
        public string MethodName { get; set; }
        public string ParamType { get; set; }
        public bool IsStatic { get; set; }
        public string OwnerAccessorType { get; set; }
    }
}
