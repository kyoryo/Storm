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
using Storm.StardewValley.Accessor;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storm.StardewValley.Wrapper
{
    public class Character : Wrapper<CharacterAccessor>
    {
        private CharacterAccessor accessor;

        public Character(CharacterAccessor accessor)
        {
            this.accessor = accessor;
        }

        public bool IsEmoteFading()
        {
            return accessor._IsEmoteFading();
        }

        public float GetEmoteInterval()
        {
            return accessor._GetEmoteInterval();
        }

        public Vector2 GetLastClick()
        {
            return accessor._GetLastClick();
        }

        public string GetName()
        {
            return accessor._GetName();
        }

        public Vector2 GetPosition()
        {
            return accessor._GetPosition();
        }

        public void SetPosition(Vector2 pos)
        {
            accessor._SetPosition(pos);
        }

        public float GetVelocityX()
        {
            return accessor._GetVelocityX();
        }

        public float GetVelocityY()
        {
            return accessor._GetVelocityY();
        }

        public float GetScale()
        {
            return accessor._GetScale();
        }

        public int GetSpeed()
        {
            return accessor._GetSpeed();
        }

        public CharacterAccessor Expose() => accessor;
    }
}
