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

using Microsoft.Xna.Framework;
using Storm.Collections;
using Storm.StardewValley.Accessor;

namespace Storm.StardewValley.Wrapper
{
    public class Chest : ObjectItem
    {
        public Chest(StaticContext parent, ChestAccessor accessor) :
            base(parent, accessor)
        {
        }

        public Chest()
        {
        }

        public WrappedProxyList<ItemAccessor, Item> Items
        {
            get
            {
                var tmp = Cast<ChestAccessor>()._GetItems();
                if (tmp == null) return null;
                return new WrappedProxyList<ItemAccessor, Item>(tmp, i => new Item(Parent, i));
            }
        }

        public int CurrentLidFrame
        {
            get { return Cast<ChestAccessor>()._GetCurrentLidFrame(); }
            set { Cast<ChestAccessor>()._SetCurrentLidFrame(value); }
        }

        public int FrameCounter
        {
            get { return Cast<ChestAccessor>()._GetFrameCounter(); }
            set { Cast<ChestAccessor>()._SetFrameCounter(value); }
        }

        public int Coins
        {
            get { return Cast<ChestAccessor>()._GetCoins(); }
            set { Cast<ChestAccessor>()._SetCoins(value); }
        }

        public Farmer Opener
        {
            get
            {
                var tmp = Cast<ChestAccessor>()._GetOpener();
                if (tmp == null) return null;
                return new Farmer(Parent, tmp);
            }
            set { Cast<ChestAccessor>()._SetOpener(value?.Cast<FarmerAccessor>()); }
        }

        public string ChestType
        {
            get { return Cast<ChestAccessor>()._GetChestType(); }
            set { Cast<ChestAccessor>()._SetChestType(value); }
        }

        public Color Tint
        {
            get { return Cast<ChestAccessor>()._GetTint(); }
            set { Cast<ChestAccessor>()._SetTint(value); }
        }

        public bool PlayerChest
        {
            get { return Cast<ChestAccessor>()._GetPlayerChest(); }
            set { Cast<ChestAccessor>()._SetPlayerChest(value); }
        }

        public bool Giftbox
        {
            get { return Cast<ChestAccessor>()._GetGiftbox(); }
            set { Cast<ChestAccessor>()._SetGiftbox(value); }
        }
    }
}