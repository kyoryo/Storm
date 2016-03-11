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

using System.Collections;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Storm.StardewValley.Accessor;
using Storm.Collections;

namespace Storm.StardewValley.Wrapper
{
    public class ShopMenu : ClickableMenu
    {
        public ShopMenu(StaticContext parent, ShopMenuAccessor accessor) :
            base(parent, accessor)
        {
        }

        public ShopMenu()
        {
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
                var tmp = Cast<ShopMenuAccessor>()._GetForSale();
                if (tmp == null) return null;
                return new WrappedProxyList<ItemAccessor, Item>(tmp, i => new Item(Parent, i));
            }
        }

        public KeyProxyDictionary<Item, int[]> ItemsForSaleData
        {
            get
            {
                var tmp = Cast<ShopMenuAccessor>()._GetItemPriceAndStock();
                if (tmp == null) return null;
                return new KeyProxyDictionary<Item, int[]>(tmp);
            }
        }

        public string DescriptionText
        {
            get { return Cast<ShopMenuAccessor>()._GetDescriptionText(); }
            set { Cast<ShopMenuAccessor>()._SetDescriptionText(value); }
        }

        public string HoverText
        {
            get { return Cast<ShopMenuAccessor>()._GetHoverText(); }
            set { Cast<ShopMenuAccessor>()._SetHoverText(value); }
        }

        public string BoldTitleText
        {
            get { return Cast<ShopMenuAccessor>()._GetBoldTitleText(); }
            set { Cast<ShopMenuAccessor>()._SetBoldTitleText(value); }
        }

        public InventoryMenu Inventory
        {
            get
            {
                var tmp = Cast<ShopMenuAccessor>()._GetInventory();
                if (tmp == null) return null;
                return new InventoryMenu(Parent, tmp);
            }
            set { Cast<ShopMenuAccessor>()._SetInventory(value?.Cast<InventoryMenuAccessor>()); }
        }

        public Item HeldItem
        {
            get
            {
                var tmp = Cast<ShopMenuAccessor>()._GetHeldItem();
                if (tmp == null) return null;
                return new Item(Parent, tmp);
            }
            set { Cast<ShopMenuAccessor>()._SetHeldItem(value?.Cast<ItemAccessor>()); }
        }

        public Item HoveredItem
        {
            get
            {
                var tmp = Cast<ShopMenuAccessor>()._GetHoveredItem();
                if (tmp == null) return null;
                return new Item(Parent, tmp);
            }
            set { Cast<ShopMenuAccessor>()._SetHoveredItem(value?.Cast<ItemAccessor>()); }
        }

        public Texture2D Wallpapers
        {
            get { return Cast<ShopMenuAccessor>()._GetWallpapers(); }
            set { Cast<ShopMenuAccessor>()._SetWallpapers(value); }
        }

        public Texture2D Floors
        {
            get { return Cast<ShopMenuAccessor>()._GetFloors(); }
            set { Cast<ShopMenuAccessor>()._SetFloors(value); }
        }

        public int LastWallpaperFloorPrice
        {
            get { return Cast<ShopMenuAccessor>()._GetLastWallpaperFloorPrice(); }
            set { Cast<ShopMenuAccessor>()._SetLastWallpaperFloorPrice(value); }
        }

        public Rectangle ScrollBarRunner
        {
            get { return Cast<ShopMenuAccessor>()._GetScrollBarRunner(); }
            set { Cast<ShopMenuAccessor>()._SetScrollBarRunner(value); }
        }

        public float SellPercentage
        {
            get { return Cast<ShopMenuAccessor>()._GetSellPercentage(); }
            set { Cast<ShopMenuAccessor>()._SetSellPercentage(value); }
        }

        public IList Animations
        {
            get { return Cast<ShopMenuAccessor>()._GetAnimations(); }
            set { Cast<ShopMenuAccessor>()._SetAnimations(value); }
        }

        public int HoverPrice
        {
            get { return Cast<ShopMenuAccessor>()._GetHoverPrice(); }
            set { Cast<ShopMenuAccessor>()._SetHoverPrice(value); }
        }

        public int Currency
        {
            get { return Cast<ShopMenuAccessor>()._GetCurrency(); }
            set { Cast<ShopMenuAccessor>()._SetCurrency(value); }
        }

        public int CurrentItemIndex
        {
            get { return Cast<ShopMenuAccessor>()._GetCurrentItemIndex(); }
            set { Cast<ShopMenuAccessor>()._SetCurrentItemIndex(value); }
        }

        public ClickableTextureComponent UpArrow
        {
            get
            {
                var tmp = Cast<ShopMenuAccessor>()._GetUpArrow();
                if (tmp == null) return null;
                return new ClickableTextureComponent(Parent, tmp);
            }
            set { Cast<ShopMenuAccessor>()._SetUpArrow(value?.Cast<ClickableTextureComponentAccessor>()); }
        }

        public ClickableTextureComponent DownArrow
        {
            get
            {
                var tmp = Cast<ShopMenuAccessor>()._GetDownArrow();
                if (tmp == null) return null;
                return new ClickableTextureComponent(Parent, tmp);
            }
            set { Cast<ShopMenuAccessor>()._SetDownArrow(value?.Cast<ClickableTextureComponentAccessor>()); }
        }

        public ClickableTextureComponent ScrollBar
        {
            get
            {
                var tmp = Cast<ShopMenuAccessor>()._GetScrollBar();
                if (tmp == null) return null;
                return new ClickableTextureComponent(Parent, tmp);
            }
            set { Cast<ShopMenuAccessor>()._SetScrollBar(value?.Cast<ClickableTextureComponentAccessor>()); }
        }

        public NPC PortraitPerson
        {
            get
            {
                var tmp = Cast<ShopMenuAccessor>()._GetPortraitPerson();
                if (tmp == null) return null;
                return new NPC(Parent, tmp);
            }
            set { Cast<ShopMenuAccessor>()._SetPortraitPerson(value?.Cast<NPCAccessor>()); }
        }

        public string PotraitPersonDialogue
        {
            get { return Cast<ShopMenuAccessor>()._GetPotraitPersonDialogue(); }
            set { Cast<ShopMenuAccessor>()._SetPotraitPersonDialogue(value); }
        }

        public bool Scrolling
        {
            get { return Cast<ShopMenuAccessor>()._GetScrolling(); }
            set { Cast<ShopMenuAccessor>()._SetScrolling(value); }
        }
    }
}