using System.Collections;

namespace Storm.StardewValley.Accessor
{
    public interface InventoryPageAccessor : ClickableMenuAccessor
    {
        InventoryMenuAccessor _GetInventory();
        void _SetInventory(InventoryMenuAccessor val);

        string _GetDescriptionText();
        void _SetDescriptionText(string val);

        string _GetHoverText();
        void _SetHoverText(string val);

        string _GetDescriptionTitle();
        void _SetDescriptionTitle(string val);

        string _GetHoverTitle();
        void _SetHoverTitle(string val);

        ItemAccessor _GetHeldItem();
        void _SetHeldItem(ItemAccessor val);

        ItemAccessor _GetHoveredItem();
        void _SetHoveredItem(ItemAccessor val);

        IList _GetEquipmentIcons();
        void _SetEquipmentIcons(IList val);

        float _GetTrashCanLidRotation();
        void _SetTrashCanLidRotation(float val);

        string _GetHorseName();
        void _SetHorseName(string val);
    }
}