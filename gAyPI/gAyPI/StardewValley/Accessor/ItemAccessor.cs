using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gAyPI.StardewValley.Accessor
{
    public interface ItemAccessor
    {
        int GetCategory();

        bool HasBeenInInventory();

        bool IsSpecialItem();

        int GetSpecialVariable();
    }
}
