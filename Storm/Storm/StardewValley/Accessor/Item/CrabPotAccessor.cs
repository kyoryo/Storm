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

namespace Storm.StardewValley.Accessor
{
    public interface CrabPotAccessor
    {
        float _GetYBob();
        void _SetYBob(float val);

        Microsoft.Xna.Framework.Vector2 _GetDirectionOffset();
        void _SetDirectionOffset(Microsoft.Xna.Framework.Vector2 val);

        ObjectAccessor _GetBait();
        void _SetBait(ObjectAccessor val);

        int _GetTileIndexToShow();
        void _SetTileIndexToShow(int val);

        bool _GetLidFlapping();
        void _SetLidFlapping(bool val);

        bool _GetLidClosing();
        void _SetLidClosing(bool val);

        float _GetLidFlapTimer();
        void _SetLidFlapTimer(float val);

        float _GetShakeTimer();
        void _SetShakeTimer(float val);

        Microsoft.Xna.Framework.Vector2 _GetShake();
        void _SetShake(Microsoft.Xna.Framework.Vector2 val);
    }
}