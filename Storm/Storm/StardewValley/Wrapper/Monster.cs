using Storm.StardewValley.Accessor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storm.StardewValley.Wrapper
{
    public class Monster : NPC
    {
        MonsterAccessor accessor;

        public Monster(MonsterAccessor accessor) : base(accessor)
        {
            this.accessor = accessor;
        }

        public int getHealth()
        {
            return accessor._GetHealth();
        }

        public void setMaxHealth(int newHealth)
        {
            accessor._SetMaxHealth(newHealth);
        }

        public int getMaxHealth()
        {
            return accessor._GetMaxHealth();
        }
    }
}
