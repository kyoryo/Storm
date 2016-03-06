using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Storm.StardewValley.Accessor;
using Storm.StardewValley.Wrapper;

namespace Storm.StardewValley.Event
{
    public class FarmerDamageEvent : StaticContextEvent
    {
        public int Damage { get; }
        public bool OverrideParry { get; }
        public Monster Damager { get; }

        public FarmerDamageEvent(int damage, bool overrideParry, Monster damager)
        {
            Damage = damage;
            OverrideParry = overrideParry;
            Damager = damager;
        }
    }
}
