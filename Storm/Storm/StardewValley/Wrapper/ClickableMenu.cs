using Storm.StardewValley.Accessor;

namespace Storm.StardewValley.Wrapper
{
    public class ClickableMenu : Wrapper<ClickableMenuAccessor>
    {
        private readonly ClickableMenuAccessor accessor;

        public ClickableMenu(StaticContext parent, ClickableMenuAccessor accessor)
        {
            Parent = parent;
            this.accessor = accessor;
        }

        private StaticContext Parent { get; }

        public ClickableMenuAccessor Expose() => accessor;
    }
}