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

namespace Storm.StardewValley.Wrapper
{
    public class InventoryPage : ClickableMenu
    {
        private readonly InventoryPageAccessor accessor;

        public InventoryPage(StaticContext parent, InventoryPageAccessor accessor) : base(parent, accessor)
        {
            this.accessor = accessor;
        }

        public InventoryMenuAccessor Inventory
        {
            get { return accessor._GetInventory(); }
            set { accessor._SetInventory(value); }
        }

        public string DescriptionText
        {
            get { return accessor._GetDescriptionText(); }
            set { accessor._SetDescriptionText(value); }
        }

        public string HoverText
        {
            get { return accessor._GetHoverText(); }
            set { accessor._SetHoverText(value); }
        }

        public string DescriptionTitle
        {
            get { return accessor._GetDescriptionTitle(); }
            set { accessor._SetDescriptionTitle(value); }
        }

        public string HoverTitle
        {
            get { return accessor._GetHoverTitle(); }
            set { accessor._SetHoverTitle(value); }
        }

        public Item HeldItem
        {
            get { return accessor._GetHeldItem() == null ? null : new Item(Parent, accessor._GetHeldItem()); }
            set { accessor._SetHeldItem(value.Cast<ItemAccessor>()); }
        }

        public Item HoveredItem
        {
            get { return accessor._GetHoveredItem() == null ? null : new Item(Parent, accessor._GetHoveredItem()); }
            set { accessor._SetHoveredItem(value.Cast<ItemAccessor>()); }
        }

        public float TrashCanLidRotation
        {
            get { return accessor._GetTrashCanLidRotation(); }
            set { accessor._SetTrashCanLidRotation(value); }
        }

        public string HorseName
        {
            get { return accessor._GetHorseName(); }
            set { accessor._SetHorseName(value); }
        }
    }
}