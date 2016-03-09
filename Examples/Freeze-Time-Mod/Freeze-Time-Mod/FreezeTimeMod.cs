using Storm.ExternalEvent;
using Storm.StardewValley;
using Storm.StardewValley.Event;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Input;

namespace Freeze_Time_Mod
{
    [Mod]
    public class FreezeTimeMod : DiskResource
    {
        [Subscribe]
        public void PerformClockUpdateCallback(PerformClockUpdateEvent @event)
        {
            var loc = @event.Root.CurrentLocation;
            @event.ReturnEarly = (loc != null && !loc.IsOutdoors);
        }
    }
}
