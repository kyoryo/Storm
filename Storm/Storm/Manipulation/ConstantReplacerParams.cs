using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storm.Manipulation
{
    public class ConstantReplacerParams
    {
        public string OwnerType { get; set; }
        public string OwnerMethodName { get; set; }
        public string OwnerMethodDesc { get; set; }
        public string Value { get; set; }
        public string ValueType { get; set; }

    }
}
