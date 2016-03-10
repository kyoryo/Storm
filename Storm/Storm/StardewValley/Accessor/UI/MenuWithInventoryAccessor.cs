using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storm.StardewValley.Accessor
{
    public interface MenuWithInventoryAccessor : ClickableMenuAccessor
    {
        System.String _GetDescriptionText();
        void _SetDescriptionText(System.String val);

        System.String _GetHoverText();
        void _SetHoverText(System.String val);

        System.String _GetDescriptionTitle();
        void _SetDescriptionTitle(System.String val);

        InventoryMenuAccessor _GetInventory();
        void _SetInventory(InventoryMenuAccessor val);

        ItemAccessor _GetHeldItem();
        void _SetHeldItem(ItemAccessor val);

        ItemAccessor _GetHoveredItem();
        void _SetHoveredItem(ItemAccessor val);

        int _GetWiggleWordsTimer();
        void _SetWiggleWordsTimer(int val);

        ClickableTextureComponentAccessor _GetOkButton();
        void _SetOkButton(ClickableTextureComponentAccessor val);

        ClickableTextureComponentAccessor _GetTrashCan();
        void _SetTrashCan(ClickableTextureComponentAccessor val);

        float _GetTrashCanLidRotation();
        void _SetTrashCanLidRotation(float val);
    }
}
