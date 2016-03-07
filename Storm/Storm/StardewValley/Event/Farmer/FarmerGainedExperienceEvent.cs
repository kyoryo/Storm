using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storm.StardewValley.Event.Farmer
{
    public class FarmerGainedExperienceEvent : StaticContextEvent
    {
        public FarmerGainedExperienceEvent(int which, int howMuch)
        {
            Which = which;
            HowMuch = howMuch;
        }

        public int Which { get; }
        public int HowMuch { get; }
    }
}
