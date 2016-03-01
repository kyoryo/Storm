using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gAyPI.Accessor
{
    public interface BootsAccessor : ItemAccessor
    {
        int GetDefenseBonus();

        string GetDescription();

        int GetImmunityBonus();

        string GetName();

        int GetPrice();
    }
}
