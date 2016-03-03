using gAyPI.StardewValley.Accessor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gAyPI.StardewValley.Wrapper
{
    public class Farmer
    {
        private FarmerAccessor accessor;

        public Farmer(FarmerAccessor accessor)
        {
            this.accessor = accessor;
        }
    }
}
