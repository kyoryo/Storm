using System.Collections;
using Microsoft.Xna.Framework;
using Storm.StardewValley.Accessor;

namespace Storm.StardewValley.Wrapper
{
    public class Chest : Object, Wrapper<ChestAccessor>
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

        public IList Items
        {
            get { return accessor._GetItems(); }
            set { accessor._SetItems(value); }
        }

        public Farmer Opener
        {
            get { return new Farmer(Parent, accessor._GetOpener()); }
            set { accessor._SetOpener(value.Expose()); }
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

        public new ChestAccessor Expose() => accessor;
    }
}