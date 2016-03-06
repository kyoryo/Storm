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
using Storm.StardewValley.Accessor;

namespace Storm.StardewValley.Wrapper
{
    public class InventoryMenu : ClickableMenu, Wrapper<InventoryMenuAccessor>
    {
        private readonly InventoryMenuAccessor accessor;

        public InventoryMenu(StaticContext parent, InventoryMenuAccessor accessor) : base(parent, accessor)
        {
            this.accessor = accessor;
        }

        public string HoverText
        {
            get { return accessor._GetHoverText(); }
            set { accessor._SetHoverText(value); }
        }

        public string HoverTitle
        {
            get { return accessor._GetHoverTitle(); }
            set { accessor._SetHoverTitle(value); }
        }

        public string DescriptionTitle
        {
            get { return accessor._GetDescriptionTitle(); }
            set { accessor._SetDescriptionTitle(value); }
        }

        public string DescriptionText
        {
            get { return accessor._GetDescriptionText(); }
            set { accessor._SetDescriptionText(value); }
        }
        
        public bool PlayerInventory
        {
            get { return accessor._GetPlayerInventory(); }
            set { accessor._SetPlayerInventory(value); }
        }

        public bool DrawSlots
        {
            get { return accessor._GetDrawSlots(); }
            set { accessor._SetDrawSlots(value); }
        }

        public bool ShowGrayedOutSlots
        {
            get { return accessor._GetShowGrayedOutSlots(); }
            set { accessor._SetShowGrayedOutSlots(value); }
        }

        public int Capacity
        {
            get { return accessor._GetCapacity(); }
            set { accessor._SetCapacity(value); }
        }

        public int Rows
        {
            get { return accessor._GetRows(); }
            set { accessor._SetRows(value); }
        }

        public int HorizontalGap
        {
            get { return accessor._GetHorizontalGap(); }
            set { accessor._SetHorizontalGap(value); }
        }

        public int VerticalGap
        {
            get { return accessor._GetVerticalGap(); }
            set { accessor._SetVerticalGap(value); }
        }

        public ItemAccessor GetItemAt(int mouseX, int mouseY)
        {
            return accessor._GetItemAt(mouseX, mouseY);
        }

        public new InventoryMenuAccessor Expose() => accessor;
    }
}