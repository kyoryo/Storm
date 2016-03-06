using Storm.StardewValley.Accessor;
using System;
using System.Collections;

namespace Storm.StardewValley.Wrapper
{
    public class InventoryMenu : ClickableMenu, Wrapper<InventoryMenuAccessor>
    {
        private InventoryMenuAccessor accessor;

        public InventoryMenu(StaticContext parent, InventoryMenuAccessor accessor) : base(parent, accessor)
        {
            this.accessor = accessor;
        }

        public ItemAccessor GetItemAt(int mouseX, int mouseY)
        {
            return accessor._GetItemAt(mouseX, mouseY);
        }

        public String HoverText
        {
            get { return accessor._GetHoverText(); }
            set { accessor._SetHoverText(value); }
        }

        public String HoverTitle
        {
            get { return accessor._GetHoverTitle(); }
            set { accessor._SetHoverTitle(value); }
        }

        public String DescriptionTitle
        {
            get { return accessor._GetDescriptionTitle(); }
            set { accessor._SetDescriptionTitle(value); }
        }

        public String DescriptionText
        {
            get { return accessor._GetDescriptionText(); }
            set { accessor._SetDescriptionText(value); }
        }

        public IList Inventory
        {
            get { return accessor._GetInventory(); }
            set { accessor._SetInventory(value); }
        }

        public IList ActualInventory
        {
            get { return accessor._GetActualInventory(); }
            set { accessor._SetActualInventory(value); }
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

        public new InventoryMenuAccessor Expose() => accessor;
    }
}
