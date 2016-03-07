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
