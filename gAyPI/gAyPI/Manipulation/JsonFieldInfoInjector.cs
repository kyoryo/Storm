using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gAyPI.Manipulation
{
    public class JsonFieldInfoInjector
    {
        public string OwnerType { get; set; }
        public string FieldName { get; set; }
        public string FieldType { get; set; }
        public string OwnerAccessorType { get; set; }
        public string RefactoredName { get; set; }
    }
}
