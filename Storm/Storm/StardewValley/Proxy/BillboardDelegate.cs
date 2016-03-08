using Storm.StardewValley.Wrapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storm.StardewValley.Proxy
{
    public abstract class BillboardDelegate : TypeDelegate<Billboard>
    {
        public abstract object[] GetConstructorParams();
    }
}
