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
using Storm.StardewValley.Accessor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storm.StardewValley.Wrapper
{
    public class Item : Wrapper<ItemAccessor>
    {
        public StaticContext Parent { get; }
        private ItemAccessor accessor;

        public Item(StaticContext parent, ItemAccessor accessor)
        {
            this.Parent = parent;
            this.accessor = accessor;
        }

        public int Category
        {
            get { return accessor._GetCategory(); }
        }

        public bool HasBeenInInventory
        {
            get { return accessor._HasBeenInInventory(); }
        }

        public bool IsSpecialItem
        {
            get { return accessor._IsSpecialItem(); }
        }

        public int SpecialVariable
        {
            get { return accessor._GetSpecialVariable(); }
        }

        public ItemAccessor Expose() => accessor;
    }
}
