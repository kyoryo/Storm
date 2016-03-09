using Storm.StardewValley.Accessor;

namespace Storm.StardewValley.Wrapper
{
    public class ClickableTextureComponent : ClickableComponent
    {
        private readonly ClickableTextureComponentAccessor accessor;

        public ClickableTextureComponent(StaticContext parent, ClickableTextureComponentAccessor accessor) :
            base(parent, accessor)
        {
            this.accessor = accessor;
        }
    }
}