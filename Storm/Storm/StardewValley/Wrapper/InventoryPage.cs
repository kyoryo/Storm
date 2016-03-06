using System.Collections;
using Storm.StardewValley.Accessor;

namespace Storm.StardewValley.Wrapper
{
    internal class InventoryPage : ClickableMenu, Wrapper<InventoryPageAccessor>
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

        public string HorseName
        {
            get { return accessor._GetHorseName(); }
            set { accessor._SetHorseName(value); }
        }

        public new InventoryPageAccessor Expose() => accessor;
    }
}