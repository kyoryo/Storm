using System;
using System.Collections;

namespace Storm.StardewValley.Accessor
{
    public interface InventoryPageAccessor : ClickableMenuAccessor
    {
        InventoryMenuAccessor _GetInventory();
        void _SetInventory(InventoryMenuAccessor val);

        String _GetDescriptionText();
        void _SetDescriptionText(String val);

        String _GetHoverText();
        void _SetHoverText(String val);

        String _GetDescriptionTitle();
        void _SetDescriptionTitle(String val);

        String _GetHoverTitle();
        void _SetHoverTitle(String val);

        ItemAccessor _GetHeldItem();
        void _SetHeldItem(ItemAccessor val);

        ItemAccessor _GetHoveredItem();
        void _SetHoveredItem(ItemAccessor val);

        IList _GetEquipmentIcons();
        void _SetEquipmentIcons(IList val);

        float _GetTrashCanLidRotation();
        void _SetTrashCanLidRotation(float val);

        String _GetHorseName();
        void _SetHorseName(String val);
    }
}
