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
    public interface CraftingRecipeAccessor
    {
        string _GetName();
        void _SetName(string val);

        string _GetDescription();
        void _SetDescription(string val);

        IDictionary _GetCraftingRecipes();
        void _SetCraftingRecipes(IDictionary val);

        IDictionary _GetCookingRecipes();
        void _SetCookingRecipes(IDictionary val);

        IDictionary _GetRecipeList();
        void _SetRecipeList(IDictionary val);

        IList _GetItemToProduce();
        void _SetItemToProduce(IList val);

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