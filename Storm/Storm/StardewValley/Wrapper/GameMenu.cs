using System.Collections;
using Storm.StardewValley.Accessor;

namespace Storm.StardewValley.Wrapper
{
    public class GameMenu : ClickableMenu, Wrapper<GameMenuAccessor>
    {
        private readonly GameMenuAccessor accessor;

        public GameMenu(StaticContext parent, GameMenuAccessor accessor) : base(parent, accessor)
        {
            this.accessor = accessor;
        }

        public int CurrentTab
        {
            get { return accessor._GetCurrentTab(); }
            set { accessor._SetCurrentTab(value); }
        }

        public string HoverText
        {
            get { return accessor._GetHoverText(); }
            set { accessor._SetHoverText(value); }
        }

        public string DescriptionText
        {
            get { return accessor._GetDescriptionText(); }
            set { accessor._SetDescriptionText(value); }
        }

        public IList Tabs
        {
            get { return accessor._GetTabs(); }
            set { accessor._SetTabs(value); }
        }

        public IList Pages
        {
            get { return accessor._GetPages(); }
            set { accessor._SetPages(value); }
        }

        public bool Invisible
        {
            get { return accessor._GetInvisible(); }
            set { accessor._SetInvisible(value); }
        }

        public bool ForcePreventClose
        {
            get { return accessor._GetForcePreventClose(); }
            set { accessor._SetForcePreventClose(value); }
        }

        public new GameMenuAccessor Expose() => accessor;
    }
}