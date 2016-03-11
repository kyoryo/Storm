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
    public class InventoryMenu : ClickableMenu
    {
        public InventoryMenu(StaticContext parent, InventoryMenuAccessor accessor) :
            base(parent, accessor)
        {
        }

        public InventoryMenu()
        {
        }

        public string HoverText
        {
            get { return Cast<InventoryMenuAccessor>()._GetHoverText(); }
            set { Cast<InventoryMenuAccessor>()._SetHoverText(value); }
        }

        public string HoverTitle
        {
            get { return Cast<InventoryMenuAccessor>()._GetHoverTitle(); }
            set { Cast<InventoryMenuAccessor>()._SetHoverTitle(value); }
        }

        public string DescriptionTitle
        {
            get { return Cast<InventoryMenuAccessor>()._GetDescriptionTitle(); }
            set { Cast<InventoryMenuAccessor>()._SetDescriptionTitle(value); }
        }

        public string DescriptionText
        {
            get { return Cast<InventoryMenuAccessor>()._GetDescriptionText(); }
            set { Cast<InventoryMenuAccessor>()._SetDescriptionText(value); }
        }

        public bool PlayerInventory
        {
            get { return Cast<InventoryMenuAccessor>()._GetPlayerInventory(); }
            set { Cast<InventoryMenuAccessor>()._SetPlayerInventory(value); }
        }

        public bool DrawSlots
        {
            get { return Cast<InventoryMenuAccessor>()._GetDrawSlots(); }
            set { Cast<InventoryMenuAccessor>()._SetDrawSlots(value); }
        }

        public bool ShowGrayedOutSlots
        {
            get { return Cast<InventoryMenuAccessor>()._GetShowGrayedOutSlots(); }
            set { Cast<InventoryMenuAccessor>()._SetShowGrayedOutSlots(value); }
        }

        public int Capacity
        {
            get { return Cast<InventoryMenuAccessor>()._GetCapacity(); }
            set { Cast<InventoryMenuAccessor>()._SetCapacity(value); }
        }

        public int Rows
        {
            get { return Cast<InventoryMenuAccessor>()._GetRows(); }
            set { Cast<InventoryMenuAccessor>()._SetRows(value); }
        }

        public int HorizontalGap
        {
            get { return Cast<InventoryMenuAccessor>()._GetHorizontalGap(); }
            set { Cast<InventoryMenuAccessor>()._SetHorizontalGap(value); }
        }

        public int VerticalGap
        {
            get { return Cast<InventoryMenuAccessor>()._GetVerticalGap(); }
            set { Cast<InventoryMenuAccessor>()._SetVerticalGap(value); }
        }

        public Item GetItemAt(int mouseX, int mouseY)
        {
            var tmp = Cast<InventoryMenuAccessor>()._GetItemAt(mouseX, mouseY);
            if (tmp == null) return null;
            return new Item(Parent, tmp);
        }
    }
}