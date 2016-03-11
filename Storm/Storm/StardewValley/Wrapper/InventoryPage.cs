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

using Storm.StardewValley.Accessor;

namespace Storm.StardewValley.Wrapper
{
    public class InventoryPage : ClickableMenu
    {
        public InventoryPage(StaticContext parent, InventoryPageAccessor accessor) :
            base(parent, accessor)
        {
        }

        public InventoryPage()
        {
        }

        public InventoryMenu Inventory
        {
            get
            {
                var tmp = Cast<InventoryPageAccessor>()._GetInventory();
                if (tmp == null) return null;
                return new InventoryMenu(Parent, tmp);
            }
            set { Cast<InventoryPageAccessor>()._SetInventory((InventoryMenuAccessor)value?.Underlying); }
        }

        public string DescriptionText
        {
            get { return Cast<InventoryPageAccessor>()._GetDescriptionText(); }
            set { Cast<InventoryPageAccessor>()._SetDescriptionText(value); }
        }

        public string HoverText
        {
            get { return Cast<InventoryPageAccessor>()._GetHoverText(); }
            set { Cast<InventoryPageAccessor>()._SetHoverText(value); }
        }

        public string DescriptionTitle
        {
            get { return Cast<InventoryPageAccessor>()._GetDescriptionTitle(); }
            set { Cast<InventoryPageAccessor>()._SetDescriptionTitle(value); }
        }

        public string HoverTitle
        {
            get { return Cast<InventoryPageAccessor>()._GetHoverTitle(); }
            set { Cast<InventoryPageAccessor>()._SetHoverTitle(value); }
        }

        public Item HeldItem
        {
            get
            {
                var tmp = Cast<InventoryPageAccessor>()._GetHeldItem();
                if (tmp == null) return null;
                return new Item(Parent, tmp);
            }
            set { Cast<InventoryPageAccessor>()._SetHeldItem(value?.Cast<ItemAccessor>()); }
        }

        public Item HoveredItem
        {
            get
            {
                var tmp = Cast<InventoryPageAccessor>()._GetHoveredItem();
                if (tmp == null) return null;
                return new Item(Parent, tmp);
            }
            set { Cast<InventoryPageAccessor>()._SetHoveredItem(value?.Cast<ItemAccessor>()); }
        }

        public float TrashCanLidRotation
        {
            get { return Cast<InventoryPageAccessor>()._GetTrashCanLidRotation(); }
            set { Cast<InventoryPageAccessor>()._SetTrashCanLidRotation(value); }
        }

        public string HorseName
        {
            get { return Cast<InventoryPageAccessor>()._GetHorseName(); }
            set { Cast<InventoryPageAccessor>()._SetHorseName(value); }
        }
    }
}