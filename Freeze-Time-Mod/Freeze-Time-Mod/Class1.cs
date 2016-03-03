using gAyPI.ExternalEvent;
using gAyPI.StardewValley;
using gAyPI.StardewValley.Event;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Freeze_Time_Mod
{
    [Mod(Author = "Demmonic", Name = "Freeze Time Indoors", Version = 0.1D)]
    public class FreezeTimeMod
    {
        private Texture2D chickenTexture;

        [Subscribe]
        public void InitializeCallback(InitializeEvent @event)
        {
            Debug.WriteLine("loaded?");
            chickenTexture = @event.Root.LoadResource("C:\\Users\\Cody\\Desktop\\Untitled.png");
        }

        [Subscribe]
        public void PostRenderCallback(PostRenderEvent @event)
        {
            var batch = @event.Root.GetSpriteBatch();
            if (chickenTexture != null)
            {
                batch.Draw(chickenTexture, new Vector2(16, 16), Color.Red);
            }
        }

        [Subscribe]
        public void PerformClockUpdateCallback(PerformClockUpdateEvent @event)
        {
            var loc = @event.Root.GetCurrentLocation();
            @event.ReturnEarly = (loc != null && !loc.IsOutdoors());
        }
    }
}
