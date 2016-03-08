using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storm.StardewValley.Accessor
{
    public interface ShopMenuAccessor : ClickableMenuAccessor
    {
        System.String _GetDescriptionText();
        void _SetDescriptionText(System.String val);

        System.String _GetHoverText();
        void _SetHoverText(System.String val);

        System.String _GetBoldTitleText();
        void _SetBoldTitleText(System.String val);

        InventoryMenuAccessor _GetInventory();
        void _SetInventory(InventoryMenuAccessor val);

        ItemAccessor _GetHeldItem();
        void _SetHeldItem(ItemAccessor val);

        ItemAccessor _GetHoveredItem();
        void _SetHoveredItem(ItemAccessor val);

        Microsoft.Xna.Framework.Graphics.Texture2D _GetWallpapers();
        void _SetWallpapers(Microsoft.Xna.Framework.Graphics.Texture2D val);

        Microsoft.Xna.Framework.Graphics.Texture2D _GetFloors();
        void _SetFloors(Microsoft.Xna.Framework.Graphics.Texture2D val);

        int _GetLastWallpaperFloorPrice();
        void _SetLastWallpaperFloorPrice(int val);

        Microsoft.Xna.Framework.Rectangle _GetScrollBarRunner();
        void _SetScrollBarRunner(Microsoft.Xna.Framework.Rectangle val);

        System.Collections.IList _GetForSale();
        void _SetForSale(System.Collections.IList val);

        System.Collections.IList _GetForSaleButtons();
        void _SetForSaleButtons(System.Collections.IList val);

        System.Collections.IList _GetCategoriesToSellHere();
        void _SetCategoriesToSellHere(System.Collections.IList val);

        System.Collections.IDictionary _GetItemPriceAndStock();
        void _SetItemPriceAndStock(System.Collections.IDictionary val);

        float _GetSellPercentage();
        void _SetSellPercentage(float val);

        System.Collections.IList _GetAnimations();
        void _SetAnimations(System.Collections.IList val);

        int _GetHoverPrice();
        void _SetHoverPrice(int val);

        int _GetCurrency();
        void _SetCurrency(int val);

        int _GetCurrentItemIndex();
        void _SetCurrentItemIndex(int val);

        ClickableTextureComponentAccessor _GetUpArrow();
        void _SetUpArrow(ClickableTextureComponentAccessor val);

        ClickableTextureComponentAccessor _GetDownArrow();
        void _SetDownArrow(ClickableTextureComponentAccessor val);

        ClickableTextureComponentAccessor _GetScrollBar();
        void _SetScrollBar(ClickableTextureComponentAccessor val);

        NPCAccessor _GetPortraitPerson();
        void _SetPortraitPerson(NPCAccessor val);

        System.String _GetPotraitPersonDialogue();
        void _SetPotraitPersonDialogue(System.String val);

        bool _GetScrolling();
        void _SetScrolling(bool val);

    }
}
