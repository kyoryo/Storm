using Storm.StardewValley.Accessor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storm.StardewValley.Wrapper
{
    public class NPC : Character
    {
        NPCAccessor accessor;

        public NPC(NPCAccessor accessor) : base(accessor)
        {
            this.accessor = accessor;
        }

    }
}
