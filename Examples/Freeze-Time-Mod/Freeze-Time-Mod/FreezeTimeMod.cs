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
using Storm;

namespace Freeze_Time_Mod
{
    [Mod]
    public class FreezeTimeMod : DiskResource
    {
        [Subscribe]
        public void PerformClockUpdateCallback(Pre10MinuteClockUpdateEvent @event)
        {
            Logging.DebugLog("Stopping clock..");
            @event.ReturnEarly = true;
        }
    }
}
