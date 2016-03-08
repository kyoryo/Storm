using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Storm.StardewValley.Wrapper;

namespace Storm.StardewValley.Proxy
{
    public abstract class ObjectDelegate : TypeDelegate<ObjectItem>
    {
        public abstract object[] GetConstructorParams();

        public virtual OverrideEvent DrawInMenu(object[] @params)
        {
            return new OverrideEvent
            {
                ReturnEarly = false
            };
        }
    }
}
