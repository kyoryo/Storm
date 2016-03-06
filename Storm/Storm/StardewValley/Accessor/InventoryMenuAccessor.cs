using System.Collections;

namespace Storm.StardewValley.Accessor
{
    public interface InventoryMenuAccessor : ClickableMenuAccessor
    {
        ItemAccessor _GetItemAt(int mouesX, int mouseY);

        string _GetHoverText();
        void _SetHoverText(string val);

        string _GetHoverTitle();
        void _SetHoverTitle(string val);

        string _GetDescriptionTitle();
        void _SetDescriptionTitle(string val);

        string _GetDescriptionText();
        void _SetDescriptionText(string val);

        IList _GetInventory();
        void _SetInventory(IList val);

        IList _GetActualInventory();
        void _SetActualInventory(IList val);

        bool _GetPlayerInventory();
        void _SetPlayerInventory(bool val);

        bool _GetDrawSlots();
        void _SetDrawSlots(bool val);

        bool _GetShowGrayedOutSlots();
        void _SetShowGrayedOutSlots(bool val);

        int _GetCapacity();
        void _SetCapacity(int val);

        int _GetRows();
        void _SetRows(int val);

        int _GetHorizontalGap();
        void _SetHorizontalGap(int val);

        int _GetVerticalGap();
        void _SetVerticalGap(int val);
    }
}