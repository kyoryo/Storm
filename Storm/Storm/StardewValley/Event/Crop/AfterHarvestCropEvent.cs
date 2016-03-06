using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Storm.StardewValley.Wrapper;

namespace Storm.StardewValley.Event.Crop
{
    class AfterHarvestCropEvent : StaticContextEvent
    {
        public Storm.StardewValley.Wrapper.Crop Crop { get; }

        public AfterHarvestCropEvent(Storm.StardewValley.Wrapper.Crop crop)
        {
            this.Crop = crop;
        }

    }
}
