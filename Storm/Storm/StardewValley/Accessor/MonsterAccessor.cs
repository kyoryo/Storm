using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storm.StardewValley.Accessor
{
    public interface MonsterAccessor : NPCAccessor
    {
        int _GetHealth();
        int _GetMaxHealth();
        void _SetMaxHealth(int newMaxHealth);
    }
}
