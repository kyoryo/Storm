using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gAyPI.StardewValley.Accessor
{
    public interface BootsAccessor : ItemAccessor
    {
        int _GetDefenseBonus();

        string _GetDescription();

        int _GetImmunityBonus();

        string _GetName();

        int _GetPrice();
    }
}
