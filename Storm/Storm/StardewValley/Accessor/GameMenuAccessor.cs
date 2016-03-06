using System;
using System.Collections;

namespace Storm.StardewValley.Accessor
{
    public interface GameMenuAccessor : ClickableMenuAccessor
    {
        int _GetCurrentTab();
        void _SetCurrentTab(int val);

        String _GetHoverText();
        void _SetHoverText(String val);

        String _GetDescriptionText();
        void _SetDescriptionText(String val);

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
