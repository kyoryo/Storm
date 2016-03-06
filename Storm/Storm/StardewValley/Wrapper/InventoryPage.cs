using Storm.StardewValley.Accessor;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storm.StardewValley.Wrapper
{
    class InventoryPage : ClickableMenu, Wrapper<InventoryPageAccessor>
    {
        private InventoryPageAccessor accessor;

        public InventoryPage(StaticContext parent, InventoryPageAccessor accessor) : base(parent, accessor)
        {
            this.accessor = accessor;
        }

        public InventoryMenuAccessor Inventory
        {
            get { return accessor._GetInventory(); }
            set { accessor._SetInventory(value); }
        }

        public String DescriptionText
        {
            get { return accessor._GetDescriptionText(); }
            set { accessor._SetDescriptionText(value); }
        }

        public String HoverText
        {
            get { return accessor._GetHoverText(); }
            set { accessor._SetHoverText(value); }
        }

        public String DescriptionTitle
        {
            get { return accessor._GetDescriptionTitle(); }
            set { accessor._SetDescriptionTitle(value); }
        }

        public String HoverTitle
        {
            get { return accessor._GetHoverTitle(); }
            set { accessor._SetHoverTitle(value); }
        }

        public ItemAccessor HeldItem
        {
            get { return accessor._GetHeldItem(); }
            set { accessor._SetHeldItem(value); }
        }

        public ItemAccessor HoveredItem
        {
            get { return accessor._GetHoveredItem(); }
            set { accessor._SetHoveredItem(value); }
        }

        public IList EquipmentIcons
        {
            get { return accessor._GetEquipmentIcons(); }
            set { accessor._SetEquipmentIcons(value); }
        }

        public float TrashCanLidRotation
        {
            get { return accessor._GetTrashCanLidRotation(); }
            set { accessor._SetTrashCanLidRotation(value); }
        }

        public String HorseName
        {
            get { return accessor._GetHorseName(); }
            set { accessor._SetHorseName(value); }
        }

        public new InventoryPageAccessor Expose() => accessor;
    }
}
