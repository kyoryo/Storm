using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Storm.StardewValley.Wrapper;

namespace Storm.StardewValley.Event.Crop
{
    class BeforeHarvestCropEvent : StaticContextEvent
    {
        public Storm.StardewValley.Wrapper.Crop Crop { get; }

        public BeforeHarvestCropEvent(Storm.StardewValley.Wrapper.Crop crop)
        {
            this.Crop = crop;
        }

    }
}
