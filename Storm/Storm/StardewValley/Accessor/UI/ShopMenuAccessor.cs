/*
    Copyright 2016 Cody R. (Demmonic)

    Storm is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    Storm is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with Storm.  If not, see <http://www.gnu.org/licenses/>.
 */

using System.Collections;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Storm.StardewValley.Accessor
{
    public interface ShopMenuAccessor : ClickableMenuAccessor
    {
        string _GetDescriptionText();
        void _SetDescriptionText(string val);

        string _GetHoverText();
        void _SetHoverText(string val);

        string _GetBoldTitleText();
        void _SetBoldTitleText(string val);

        InventoryMenuAccessor _GetInventory();
        void _SetInventory(InventoryMenuAccessor val);

        ItemAccessor _GetHeldItem();
        void _SetHeldItem(ItemAccessor val);

        ItemAccessor _GetHoveredItem();
        void _SetHoveredItem(ItemAccessor val);

        Texture2D _GetWallpapers();
        void _SetWallpapers(Texture2D val);

        Texture2D _GetFloors();
        void _SetFloors(Texture2D val);

        int _GetLastWallpaperFloorPrice();
        void _SetLastWallpaperFloorPrice(int val);

        Rectangle _GetScrollBarRunner();
        void _SetScrollBarRunner(Rectangle val);

        IList _GetForSale();
        void _SetForSale(IList val);

        IList _GetForSaleButtons();
        void _SetForSaleButtons(IList val);

        IList _GetCategoriesToSellHere();
        void _SetCategoriesToSellHere(IList val);

        IDictionary _GetItemPriceAndStock();
        void _SetItemPriceAndStock(IDictionary val);

        float _GetSellPercentage();
        void _SetSellPercentage(float val);

        IList _GetAnimations();
        void _SetAnimations(IList val);

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

        string _GetPotraitPersonDialogue();
        void _SetPotraitPersonDialogue(string val);

        bool _GetScrolling();
        void _SetScrolling(bool val);
    }
}