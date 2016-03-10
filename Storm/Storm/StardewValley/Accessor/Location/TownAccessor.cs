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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storm.StardewValley.Accessor
{
    public interface TownAccessor : GameLocationAccessor
    {
        TempAnimatedSpriteAccessor _GetMinecartSteam();
        void _SetMinecartSteam(TempAnimatedSpriteAccessor val);

        bool _GetCcRefurbished();
        void _SetCcRefurbished(bool val);

        bool _GetCcJoja();
        void _SetCcJoja(bool val);

        bool _GetPlayerCheckedBoard();
        void _SetPlayerCheckedBoard(bool val);

        bool _GetIsShowingDestroyedJoja();
        void _SetIsShowingDestroyedJoja(bool val);

        bool[] _GetGarbageChecked();
        void _SetGarbageChecked(bool[] val);

        Microsoft.Xna.Framework.Vector2 _GetClockCenter();
        void _SetClockCenter(Microsoft.Xna.Framework.Vector2 val);

        Microsoft.Xna.Framework.Vector2 _GetCcFacadePosition();
        void _SetCcFacadePosition(Microsoft.Xna.Framework.Vector2 val);

        Microsoft.Xna.Framework.Vector2 _GetCcFacadePositionBottom();
        void _SetCcFacadePositionBottom(Microsoft.Xna.Framework.Vector2 val);

        Microsoft.Xna.Framework.Rectangle _GetMinuteHandSource();
        void _SetMinuteHandSource(Microsoft.Xna.Framework.Rectangle val);

        Microsoft.Xna.Framework.Rectangle _GetHourHandSource();
        void _SetHourHandSource(Microsoft.Xna.Framework.Rectangle val);

        Microsoft.Xna.Framework.Rectangle _GetClockNub();
        void _SetClockNub(Microsoft.Xna.Framework.Rectangle val);

        Microsoft.Xna.Framework.Rectangle _GetJojaFacadeTop();
        void _SetJojaFacadeTop(Microsoft.Xna.Framework.Rectangle val);

        Microsoft.Xna.Framework.Rectangle _GetJojaFacadeBottom();
        void _SetJojaFacadeBottom(Microsoft.Xna.Framework.Rectangle val);
    }
}
