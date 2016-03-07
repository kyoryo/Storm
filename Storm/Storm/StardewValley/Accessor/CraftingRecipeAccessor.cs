using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storm.StardewValley.Accessor
{
    public interface CraftingRecipeAccessor
    {
        System.String _GetName();
        void _SetName(System.String val);

        System.String _GetDescription();
        void _SetDescription(System.String val);

        System.Collections.IDictionary _GetCraftingRecipes();
        void _SetCraftingRecipes(System.Collections.IDictionary val);

        System.Collections.IDictionary _GetCookingRecipes();
        void _SetCookingRecipes(System.Collections.IDictionary val);

        System.Collections.IDictionary _GetRecipeList();
        void _SetRecipeList(System.Collections.IDictionary val);

        System.Collections.IList _GetItemToProduce();
        void _SetItemToProduce(System.Collections.IList val);

        bool _GetBigCraftable();
        void _SetBigCraftable(bool val);

        bool _GetIsCookingRecipe();
        void _SetIsCookingRecipe(bool val);

        int _GetTimesCrafted();
        void _SetTimesCrafted(int val);

        int _GetNumberProducedPerCraft();
        void _SetNumberProducedPerCraft(int val);

    }
}
