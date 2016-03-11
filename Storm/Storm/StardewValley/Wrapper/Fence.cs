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

using Microsoft.Xna.Framework.Graphics;
using Storm.StardewValley.Accessor;

namespace Storm.StardewValley.Wrapper
{
    public class Fence : ObjectItem
    {
        public Fence(StaticContext parent, FenceAccessor accessor) :
            base(parent, accessor)
        {
        }

        public Fence()
        {
        }

        public int FencePieceWidth
        {
            get { return Cast<FenceAccessor>()._GetFencePieceWidth(); }
            set { Cast<FenceAccessor>()._SetFencePieceWidth(value); }
        }

        public int FencePieceHeight
        {
            get { return Cast<FenceAccessor>()._GetFencePieceHeight(); }
            set { Cast<FenceAccessor>()._SetFencePieceHeight(value); }
        }

        public Texture2D FenceTexture
        {
            get { return Cast<FenceAccessor>()._GetFenceTexture(); }
            set { Cast<FenceAccessor>()._SetFenceTexture(value); }
        }

        public float Health
        {
            get { return Cast<FenceAccessor>()._GetHealth(); }
            set { Cast<FenceAccessor>()._SetHealth(value); }
        }

        public float MaxHealth
        {
            get { return Cast<FenceAccessor>()._GetMaxHealth(); }
            set { Cast<FenceAccessor>()._SetMaxHealth(value); }
        }

        public int WhichType
        {
            get { return Cast<FenceAccessor>()._GetWhichType(); }
            set { Cast<FenceAccessor>()._SetWhichType(value); }
        }

        public int GatePosition
        {
            get { return Cast<FenceAccessor>()._GetGatePosition(); }
            set { Cast<FenceAccessor>()._SetGatePosition(value); }
        }

        public int GateMotion
        {
            get { return Cast<FenceAccessor>()._GetGateMotion(); }
            set { Cast<FenceAccessor>()._SetGateMotion(value); }
        }

        public bool IsGate
        {
            get { return Cast<FenceAccessor>()._GetIsGate(); }
            set { Cast<FenceAccessor>()._SetIsGate(value); }
        }
    }
}