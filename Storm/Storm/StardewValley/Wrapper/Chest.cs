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

using Microsoft.Xna.Framework;
using Storm.StardewValley.Accessor;

namespace Storm.StardewValley.Wrapper
{
    public class Chest : ObjectItem
    {
        private readonly ChestAccessor accessor;

        public Chest(StaticContext parent, ChestAccessor accessor) : base(parent, accessor)
        {
            this.accessor = accessor;
        }

        public int CurrentLidFrame
        {
            get { return accessor._GetCurrentLidFrame(); }
            set { accessor._SetCurrentLidFrame(value); }
        }

        public int FrameCounter
        {
            get { return accessor._GetFrameCounter(); }
            set { accessor._SetFrameCounter(value); }
        }

        public int Coins
        {
            get { return accessor._GetCoins(); }
            set { accessor._SetCoins(value); }
        }

        public Farmer Opener
        {
            get { return accessor._GetOpener() == null ? null : new Farmer(Parent, accessor._GetOpener()); }
            set { accessor._SetOpener(value.Cast<FarmerAccessor>()); }
        }

        public string ChestType
        {
            get { return accessor._GetChestType(); }
            set { accessor._SetChestType(value); }
        }

        public Color Tint
        {
            get { return accessor._GetTint(); }
            set { accessor._SetTint(value); }
        }

        public bool PlayerChest
        {
            get { return accessor._GetPlayerChest(); }
            set { accessor._SetPlayerChest(value); }
        }

        public bool Giftbox
        {
            get { return accessor._GetGiftbox(); }
            set { accessor._SetGiftbox(value); }
        }
    }
}