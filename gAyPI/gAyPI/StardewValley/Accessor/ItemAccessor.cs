using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gAyPI.StardewValley.Accessor
{
    public interface ItemAccessor
    {
        int _GetCategory();

        bool _HasBeenInInventory();

        bool _IsSpecialItem();

        int _GetSpecialVariable();
    }
}
