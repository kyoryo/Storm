using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storm.StardewValley.Proxy
{
    public struct OverrideEvent
    {
        public bool ReturnEarly { get; set; }
        public object ReturnValue { get; set; }
    }
}
