using Storm.ExternalEvent;
using Storm.StardewValley.Event;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grow_Grass_Fast_Mod
{
    [Mod(Author = "Demmonic", Name = "Grow Grass Fast", Version = 0.1D)]
    public class GrowGrassFastMod
    {
        [Subscribe]
        public void PerformClockUpdateCallback(PerformClockUpdateEvent @event)
        {
            var loc = @event.Root.CurrentLocation;
            if (loc != null)
            {
                loc.GrowWeedGrass(5);
            }
        }
    }
}
