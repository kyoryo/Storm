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

namespace Storm.StardewValley.Wrapper
{
    public class Character : Wrapper<CharacterAccessor>
    {
        public StaticContext Parent { get; }
        private CharacterAccessor accessor;

        public Character(StaticContext parent, CharacterAccessor accessor)
        {
            this.Parent = parent;
            this.accessor = accessor;
        }

        public bool EmoteFading
        {
            get { return accessor._GetEmoteFading(); }
        }

        public float EmoteInterval
        {
            get { return accessor._GetEmoteInterval(); }
            set { accessor._SetEmoteInterval(value); }
        }

        public Vector2 LastClick
        {
            get { return accessor._GetLastClick(); }
            set { accessor._SetLastClick(value); }
        }

        public string Name
        {
            get { return accessor._GetName(); }
            set { accessor._SetName(value); }
        }

        public Vector2 Position
        {
            get { return accessor._GetPosition(); }
            set { accessor._SetPosition(value); }
        }

        public float VelocityX
        {
            get { return accessor._GetXVelocity(); }
            set { accessor._SetXVelocity(value); }
        }

        public float VelocityY
        {
            get { return accessor._GetYVelocity(); }
            set { accessor._SetYVelocity(value); }
        }

        public float Scale
        {
            get { return accessor._GetScale(); }
            set { accessor._SetScale(value); }
        }

        public int Speed
        {
            get { return accessor._GetSpeed(); }
            set { accessor._SetSpeed(value); }
        }

        public AnimatedSprite Sprite
        {
            get { return new AnimatedSprite(accessor._GetSprite()); }
            set { accessor._SetSprite(value.Expose()); }
        }

        public CharacterAccessor Expose() => accessor;
    }
}
