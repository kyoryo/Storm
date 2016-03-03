using gAyPI.StardewValley.Accessor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gAyPI.StardewValley.Wrapper
{
    public class GameLocation
    {
        private GameLocationAccessor accessor;

        public GameLocation(GameLocationAccessor accessor)
        {
            this.accessor = accessor;
        }

        public bool IsOutdoors()
        {
            return accessor._IsOutdoors();
        }
    }
}
