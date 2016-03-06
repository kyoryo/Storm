using System.Collections;
using Microsoft.Xna.Framework;

namespace Storm.StardewValley.Accessor
{
    public interface ChestAccessor : ObjectAccessor
    {
        int _GetCurrentLidFrame();
        void _SetCurrentLidFrame(int val);

        int _GetFrameCounter();
        void _SetFrameCounter(int val);

        int _GetCoins();
        void _SetCoins(int val);

        IList _GetItems();
        void _SetItems(IList val);

        FarmerAccessor _GetOpener();
        void _SetOpener(FarmerAccessor val);

        string _GetChestType();
        void _SetChestType(string val);

        Color _GetTint();
        void _SetTint(Color val);

        bool _GetPlayerChest();
        void _SetPlayerChest(bool val);

        bool _GetGiftbox();
        void _SetGiftbox(bool val);
    }
}