using Storm.StardewValley.Accessor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storm.StardewValley.Wrapper
{
    public class ClickableTextureComponent : ClickableComponent, Wrapper<ClickableTextureComponentAccessor>
    {
        private ClickableTextureComponentAccessor accessor;

        public ClickableTextureComponent(StaticContext parent, ClickableTextureComponentAccessor accessor) :
            base(parent, accessor)
        {
            this.accessor = accessor;
        }

        public new ClickableTextureComponentAccessor Expose() => accessor;
    }
}
