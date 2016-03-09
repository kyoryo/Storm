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
using Microsoft.Xna.Framework.Graphics;

namespace Storm.StardewValley.Accessor
{
    public interface FenceAccessor : ObjectAccessor
    {
        int _GetFencePieceWidth();
        void _SetFencePieceWidth(int val);

        int _GetFencePieceHeight();
        void _SetFencePieceHeight(int val);

        Texture2D _GetFenceTexture();
        void _SetFenceTexture(Texture2D val);

        new float _GetHealth();
        void _SetHealth(float val);

        float _GetMaxHealth();
        void _SetMaxHealth(float val);

        int _GetWhichType();
        void _SetWhichType(int val);

        int _GetGatePosition();
        void _SetGatePosition(int val);

        int _GetGateMotion();
        void _SetGateMotion(int val);

        IDictionary _GetFenceDrawGuide();
        void _SetFenceDrawGuide(IDictionary val);

        bool _GetIsGate();
        void _SetIsGate(bool val);
    }
}