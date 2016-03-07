using Storm.StardewValley.Accessor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storm.StardewValley.Wrapper
{
    public class ClickableComponent : Wrapper<ClickableComponentAccessor>
    {
        private StaticContext Parent { get; }
        private ClickableComponentAccessor accessor;

        public ClickableComponent(StaticContext parent, ClickableComponentAccessor accessor)
        {
            this.Parent = parent;
            this.accessor = accessor;
        }

        public ClickableComponentAccessor Expose() => accessor;
    }
}
