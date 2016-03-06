using Microsoft.Xna.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        String _GetChestType();
        void _SetChestType(String val);

        Color _GetTint();
        void _SetTint(Color val);

        bool _GetPlayerChest();
        void _SetPlayerChest(bool val);

        bool _GetGiftbox();
        void _SetGiftbox(bool val);
    }
}
