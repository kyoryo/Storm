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