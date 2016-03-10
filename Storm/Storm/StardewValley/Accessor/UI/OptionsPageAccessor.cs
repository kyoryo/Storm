using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storm.StardewValley.Accessor
{
    public interface OptionsPageAccessor : ClickableMenuAccessor
    {
        System.String _GetDescriptionText();
        void _SetDescriptionText(System.String val);

        System.String _GetHoverText();
        void _SetHoverText(System.String val);

        System.Collections.IList _GetOptionSlots();
        void _SetOptionSlots(System.Collections.IList val);

        int _GetCurrentItemIndex();
        void _SetCurrentItemIndex(int val);

        ClickableTextureComponentAccessor _GetUpArrow();
        void _SetUpArrow(ClickableTextureComponentAccessor val);

        ClickableTextureComponentAccessor _GetDownArrow();
        void _SetDownArrow(ClickableTextureComponentAccessor val);

        ClickableTextureComponentAccessor _GetScrollBar();
        void _SetScrollBar(ClickableTextureComponentAccessor val);

        bool _GetScrolling();
        void _SetScrolling(bool val);

        System.Collections.IList _GetOptions();
        void _SetOptions(System.Collections.IList val);

        Microsoft.Xna.Framework.Rectangle _GetScrollBarRunner();
        void _SetScrollBarRunner(Microsoft.Xna.Framework.Rectangle val);

        int _GetOptionsSlotHeld();
        void _SetOptionsSlotHeld(int val);
    }
}
