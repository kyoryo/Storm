using System.Collections;

namespace Storm.StardewValley.Accessor
{
    public interface GameMenuAccessor : ClickableMenuAccessor
    {
        int _GetCurrentTab();
        void _SetCurrentTab(int val);

        string _GetHoverText();
        void _SetHoverText(string val);

        string _GetDescriptionText();
        void _SetDescriptionText(string val);

        IList _GetTabs();
        void _SetTabs(IList val);

        IList _GetPages();
        void _SetPages(IList val);

        bool _GetInvisible();
        void _SetInvisible(bool val);

        bool _GetForcePreventClose();
        void _SetForcePreventClose(bool val);
    }
}