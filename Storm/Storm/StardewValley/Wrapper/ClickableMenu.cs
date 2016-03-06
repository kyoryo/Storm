using Storm.StardewValley.Accessor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storm.StardewValley.Wrapper
{
    public class ClickableMenu : Wrapper<ClickableMenuAccessor>
    {
        private StaticContext Parent { get; }
        private ClickableMenuAccessor accessor;

        public ClickableMenu(StaticContext parent, ClickableMenuAccessor accessor)
        {
            this.Parent = parent;
            this.accessor = accessor;
        }

        public ClickableMenuAccessor Expose() => accessor;
    }
}
