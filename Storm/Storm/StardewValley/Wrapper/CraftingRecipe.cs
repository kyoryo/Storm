/*
    Copyright 2016 Cody R. (Demmonic), Inari-Whitebear

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

using Microsoft.Xna.Framework;
using Storm.Collections;
using Storm.StardewValley.Accessor;

namespace Storm.StardewValley.Wrapper
{
    public class CraftingRecipe : StaticContextWrapper
    {
        public CraftingRecipe(StaticContext parent, CraftingRecipeAccessor accessor) :
            base(parent)        
        {
            Underlying = accessor;
        }

        public CraftingRecipe()
        {
        }

        public string Name
        {
            get { return Cast<CraftingRecipeAccessor>()._GetName(); }
            set { Cast<CraftingRecipeAccessor>()._SetName(value); }
        }

        public string Description
        {
            get { return Cast<CraftingRecipeAccessor>()._GetDescription(); }
            set { Cast<CraftingRecipeAccessor>()._SetDescription(value); }
        }

        public ProxyDictionary<string, string> CraftingRecipes
        {
            get
            {
                var tmp = Cast<CraftingRecipeAccessor>()._GetCraftingRecipes();
                if (tmp == null) return null;
                return new ProxyDictionary<string, string>(tmp);
            }
        }

        public ProxyDictionary<string, string> CookingRecipes
        {
            get
            {
                var tmp = Cast<CraftingRecipeAccessor>()._GetCookingRecipes();
                if (tmp == null) return null;
                return new ProxyDictionary<string, string>(tmp);
            }
        }
        public ProxyDictionary<int, int> RecipeList
        {
            get
            {
                var tmp = Cast<CraftingRecipeAccessor>()._GetRecipeList();
                if (tmp == null) return null;
                return new ProxyDictionary<int, int>(tmp);
            }
        }

        public ProxyList<int> ItemToProduce
        {
            get
            {
                var tmp = Cast<CraftingRecipeAccessor>()._GetItemToProduce();
                if (tmp == null) return null;
                return new ProxyList<int>(tmp);
            }
        }

        public bool BigCraftable
        {
            get { return Cast<CraftingRecipeAccessor>()._GetBigCraftable();  }
            set { Cast<CraftingRecipeAccessor>()._SetBigCraftable(value); }
        }

        public bool IsCookingRecipe
        {
            get { return Cast<CraftingRecipeAccessor>()._GetIsCookingRecipe(); }
            set { Cast<CraftingRecipeAccessor>()._SetIsCookingRecipe(value); }
        }

        public int TimesCrafted
        {
            get { return Cast<CraftingRecipeAccessor>()._GetTimesCrafted(); }
            set { Cast<CraftingRecipeAccessor>()._SetTimesCrafted(value); }
        }

        public int NumberProducedPerCraft
        {
            get { return Cast<CraftingRecipeAccessor>()._GetNumberProducedPerCraft(); }
            set { Cast<CraftingRecipeAccessor>()._SetNumberProducedPerCraft(value); }
        }
    }
}