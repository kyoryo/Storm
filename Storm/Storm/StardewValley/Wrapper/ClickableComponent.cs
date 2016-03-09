using Storm.StardewValley.Accessor;

namespace Storm.StardewValley.Wrapper
{
    public class ClickableComponent : Wrapper<ClickableComponentAccessor>
    {
        private readonly ClickableComponentAccessor accessor;

        public ClickableComponent(StaticContext parent, ClickableComponentAccessor accessor)
        {
            Parent = parent;
            this.accessor = accessor;
        }

        private StaticContext Parent { get; }

        public ClickableComponentAccessor Expose() => accessor;
    }
}