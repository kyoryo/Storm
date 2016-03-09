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

namespace Storm.StardewValley.Accessor
{
    public interface CraftingPageAccessor : ClickableMenuAccessor
    {
        string _GetDescriptionText();
        void _SetDescriptionText(string val);

        string _GetHoverText();
        void _SetHoverText(string val);

        ItemAccessor _GetHoverItem();
        void _SetHoverItem(ItemAccessor val);

        ItemAccessor _GetLastCookingHover();
        void _SetLastCookingHover(ItemAccessor val);

        InventoryMenuAccessor _GetInventory();
        void _SetInventory(InventoryMenuAccessor val);

        ItemAccessor _GetHeldItem();
        void _SetHeldItem(ItemAccessor val);

        IList _GetPagesOfCraftingRecipes();
        void _SetPagesOfCraftingRecipes(IList val);

        int _GetCurrentCraftingPage();
        void _SetCurrentCraftingPage(int val);

        CraftingRecipeAccessor _GetHoverRecipe();
        void _SetHoverRecipe(CraftingRecipeAccessor val);

        ClickableTextureComponentAccessor _GetUpButton();
        void _SetUpButton(ClickableTextureComponentAccessor val);

        ClickableTextureComponentAccessor _GetDownButton();
        void _SetDownButton(ClickableTextureComponentAccessor val);

        bool _GetCooking();
        void _SetCooking(bool val);

        ClickableTextureComponentAccessor _GetTrashCan();
        void _SetTrashCan(ClickableTextureComponentAccessor val);

        float _GetTrashCanLidRotation();
        void _SetTrashCanLidRotation(float val);

        string _GetHoverTitle();
        void _SetHoverTitle(string val);
    }
}