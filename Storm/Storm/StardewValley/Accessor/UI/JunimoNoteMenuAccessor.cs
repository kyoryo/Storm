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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storm.StardewValley.Accessor
{
    public interface JunimoNoteMenuAccessor : ClickableMenuAccessor
    {
        Microsoft.Xna.Framework.Graphics.Texture2D _GetNoteTexture();
        void _SetNoteTexture(Microsoft.Xna.Framework.Graphics.Texture2D val);

        bool _GetSpecificBundlePage();
        void _SetSpecificBundlePage(bool val);

        InventoryMenuAccessor _GetInventory();
        void _SetInventory(InventoryMenuAccessor val);

        ItemAccessor _GetHeldItem();
        void _SetHeldItem(ItemAccessor val);

        ItemAccessor _GetHoveredItem();
        void _SetHoveredItem(ItemAccessor val);

        bool _GetCanClick();
        void _SetCanClick(bool val);

        int _GetWhichArea();
        void _SetWhichArea(int val);

        System.String _GetHoverText();
        void _SetHoverText(System.String val);

        System.Collections.IList _GetBundles();
        void _SetBundles(System.Collections.IList val);

        System.Collections.IList _GetTempSprites();
        void _SetTempSprites(System.Collections.IList val);

        System.Collections.IList _GetIngredientSlots();
        void _SetIngredientSlots(System.Collections.IList val);

        System.Collections.IList _GetIngredientList();
        void _SetIngredientList(System.Collections.IList val);

        System.Collections.IList _GetOtherClickableComponents();
        void _SetOtherClickableComponents(System.Collections.IList val);

        bool _GetFromGameMenu();
        void _SetFromGameMenu(bool val);

        bool _GetScrambledText();
        void _SetScrambledText(bool val);

        ClickableTextureComponentAccessor _GetBackButton();
        void _SetBackButton(ClickableTextureComponentAccessor val);

        ClickableTextureComponentAccessor _GetPurchaseButton();
        void _SetPurchaseButton(ClickableTextureComponentAccessor val);

        ClickableTextureComponentAccessor _GetAreaNextButton();
        void _SetAreaNextButton(ClickableTextureComponentAccessor val);

        ClickableTextureComponentAccessor _GetAreaBackButton();
        void _SetAreaBackButton(ClickableTextureComponentAccessor val);

        ClickableAnimatedComponentAccessor _GetPresentButton();
        void _SetPresentButton(ClickableAnimatedComponentAccessor val);

        BundleAccessor _GetCurrentPageBundle();
        void _SetCurrentPageBundle(BundleAccessor val);
    }
}
