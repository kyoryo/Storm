using Storm.StardewValley.Accessor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storm.StardewValley.Wrapper
{
    public class Horse : NPC
    {
        private readonly HorseAccessor accessor;

        public Horse(StaticContext parent, HorseAccessor accessor) : base(parent, accessor)
        {
            this.accessor = accessor;
        }
    }
}