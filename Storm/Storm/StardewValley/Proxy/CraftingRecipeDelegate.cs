using Storm.StardewValley.Accessor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storm.StardewValley.Proxy
{
    public abstract class CraftingRecipeDelegate : TypeDelegate<CraftingRecipeAccessor>
    {
        public abstract object[] GetConstructorParams();
    }
}
