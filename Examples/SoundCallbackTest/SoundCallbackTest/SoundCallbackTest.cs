using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Storm.ExternalEvent;
using Storm.StardewValley.Event;

namespace SoundCallbackTest
{
    [Mod]
    public class SoundCallbackTest : DiskResource
    {
        [Subscribe]
        public void PlaySoundCallback( PlaySoundEvent @event )
        {
            var sound = @event.SoundCue;
            Console.WriteLine( "Sound Played: " + sound);
        }
    }
}
