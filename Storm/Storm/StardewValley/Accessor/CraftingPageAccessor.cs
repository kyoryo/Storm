using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storm.StardewValley.Accessor
{
    public interface CraftingPageAccessor : ClickableMenuAccessor
    {
        System.String _GetDescriptionText();
        void _SetDescriptionText(System.String val);

        System.String _GetHoverText();
        void _SetHoverText(System.String val);

        ItemAccessor _GetHoverItem();
        void _SetHoverItem(ItemAccessor val);

        ItemAccessor _GetLastCookingHover();
        void _SetLastCookingHover(ItemAccessor val);

        InventoryMenuAccessor _GetInventory();
        void _SetInventory(InventoryMenuAccessor val);

        ItemAccessor _GetHeldItem();
        void _SetHeldItem(ItemAccessor val);

        System.Collections.IList _GetPagesOfCraftingRecipes();
        void _SetPagesOfCraftingRecipes(System.Collections.IList val);

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

        System.String _GetHoverTitle();
        void _SetHoverTitle(System.String val);

    }
}
