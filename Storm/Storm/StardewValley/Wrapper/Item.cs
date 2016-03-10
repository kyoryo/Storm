﻿/*
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

using Storm.StardewValley.Accessor;

namespace Storm.StardewValley.Wrapper
{
    public class Item : StaticContextWrapper
    {
        public Item(StaticContext parent, ItemAccessor accessor) : 
            base(parent)
        {
            Accessor = accessor;
        }

        public Item()
        {
        }

        public int Category
        {
            get { return Cast<ItemAccessor>()._GetCategory(); }
            set { Cast<ItemAccessor>()._SetCategory(value); }
        }

        public bool HasBeenInInventory
        {
            get { return Cast<ItemAccessor>()._GetHasBeenInInventory(); }
            set { Cast<ItemAccessor>()._SetHasBeenInInventory(value); }
        }

        public bool IsSpecialItem
        {
            get { return Cast<ItemAccessor>()._GetSpecialItem(); }
            set { Cast<ItemAccessor>()._SetSpecialItem(value); }
        }

        public int SpecialVariable
        {
            get { return Cast<ItemAccessor>()._GetSpecialVariable(); }
            set { Cast<ItemAccessor>()._SetSpecialVariable(value); }
        }

        public bool IsTool() => Cast<ItemAccessor>() is ToolAccessor;
        public Tool ToTool() => Cast<ItemAccessor>() == null ? null : new Tool(Parent, (ToolAccessor)Cast<ItemAccessor>());

        public bool IsObject() => Cast<ItemAccessor>() is ObjectAccessor;
        public ObjectItem ToObject() => Cast<ItemAccessor>() == null ? null : new ObjectItem(Parent, (ObjectAccessor)Cast<ItemAccessor>());

        public override object Expose() => Accessor;
    }
}