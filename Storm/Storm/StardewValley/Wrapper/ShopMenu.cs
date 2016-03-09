using System.Collections;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Storm.StardewValley.Accessor;
using Storm.Collections;

namespace Storm.StardewValley.Wrapper
{
    public class ShopMenu : ClickableMenu
    {
        private readonly ShopMenuAccessor accessor;

        public ShopMenu(StaticContext parent, ShopMenuAccessor accessor) :
            base(parent, accessor)
        {
            this.accessor = accessor;
        }

        public bool AddForSale(Item item, int price, int amount = int.MaxValue)
        {
            var list = ItemsForSale;
            if (list == null) return false;
            var dict = ItemsForSaleData;
            if (dict == null) return false;
            list.Add(item);
            dict.Add(item, new int[] { price, amount });
            return true;
        }

        public WrappedProxyList<ItemAccessor, Item> ItemsForSale
        {
            get
            {
                var tmp = accessor._GetForSale();
                if (tmp == null) return null;
                return new WrappedProxyList<ItemAccessor, Item>(tmp, i => new Item(Parent, i));
            }
        }

        public KeyProxyDictionary<Item, int[]> ItemsForSaleData
        {
            get
            {
                var tmp = accessor._GetItemPriceAndStock();
                if (tmp == null) return null;
                return new KeyProxyDictionary<Item, int[]>(tmp);
            }
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

        public string BoldTitleText
        {
            get { return accessor._GetBoldTitleText(); }
            set { accessor._SetBoldTitleText(value); }
        }

        public InventoryMenu Inventory
        {
            get { return new InventoryMenu(Parent, accessor._GetInventory()); }
            set { accessor._SetInventory(value.Cast<InventoryMenuAccessor>()); }
        }

        public Item HeldItem
        {
            get { return new Item(Parent, accessor._GetHeldItem()); }
            set { accessor._SetHeldItem(value.Cast<ItemAccessor>()); }
        }

        public Item HoveredItem
        {
            get { return new Item(Parent, accessor._GetHoveredItem()); }
            set { accessor._SetHoveredItem(value.Cast<ItemAccessor>()); }
        }

        public Texture2D Wallpapers
        {
            get { return accessor._GetWallpapers(); }
            set { accessor._SetWallpapers(value); }
        }

        public Texture2D Floors
        {
            get { return accessor._GetFloors(); }
            set { accessor._SetFloors(value); }
        }

        public int LastWallpaperFloorPrice
        {
            get { return accessor._GetLastWallpaperFloorPrice(); }
            set { accessor._SetLastWallpaperFloorPrice(value); }
        }

        public Rectangle ScrollBarRunner
        {
            get { return accessor._GetScrollBarRunner(); }
            set { accessor._SetScrollBarRunner(value); }
        }

        public float SellPercentage
        {
            get { return accessor._GetSellPercentage(); }
            set { accessor._SetSellPercentage(value); }
        }

        public IList Animations
        {
            get { return accessor._GetAnimations(); }
            set { accessor._SetAnimations(value); }
        }

        public int HoverPrice
        {
            get { return accessor._GetHoverPrice(); }
            set { accessor._SetHoverPrice(value); }
        }

        public int Currency
        {
            get { return accessor._GetCurrency(); }
            set { accessor._SetCurrency(value); }
        }

        public int CurrentItemIndex
        {
            get { return accessor._GetCurrentItemIndex(); }
            set { accessor._SetCurrentItemIndex(value); }
        }

        public ClickableTextureComponent UpArrow
        {
            get { return new ClickableTextureComponent(Parent, accessor._GetUpArrow()); }
            set { accessor._SetUpArrow(value.Cast<ClickableTextureComponentAccessor>()); }
        }

        public ClickableTextureComponent DownArrow
        {
            get { return new ClickableTextureComponent(Parent, accessor._GetDownArrow()); }
            set { accessor._SetDownArrow(value.Cast<ClickableTextureComponentAccessor>()); }
        }

        public ClickableTextureComponent ScrollBar
        {
            get { return new ClickableTextureComponent(Parent, accessor._GetScrollBar()); }
            set { accessor._SetScrollBar(value.Cast<ClickableTextureComponentAccessor>()); }
        }

        public NPC PortraitPerson
        {
            get { return new NPC(Parent, accessor._GetPortraitPerson()); }
            set { accessor._SetPortraitPerson(value.Cast<NPCAccessor>()); }
        }

        public string PotraitPersonDialogue
        {
            get { return accessor._GetPotraitPersonDialogue(); }
            set { accessor._SetPotraitPersonDialogue(value); }
        }

        public bool Scrolling
        {
            get { return accessor._GetScrolling(); }
            set { accessor._SetScrolling(value); }
        }
    }
}