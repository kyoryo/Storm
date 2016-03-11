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

using Microsoft.Xna.Framework;
using Storm.StardewValley.Accessor;

namespace Storm.StardewValley.Wrapper
{
    public class Character : StaticContextWrapper
    {
        public Character(StaticContext parent, CharacterAccessor accessor) :
            base(parent)
        {
            Underlying = accessor;
        }

        public Character()
        {
        }

        public bool EmoteFading
        {
            get { return Cast<CharacterAccessor>()._GetEmoteFading(); }
        }

        public float EmoteInterval
        {
            get { return Cast<CharacterAccessor>()._GetEmoteInterval(); }
            set { Cast<CharacterAccessor>()._SetEmoteInterval(value); }
        }

        public Vector2 LastClick
        {
            get { return Cast<CharacterAccessor>()._GetLastClick(); }
            set { Cast<CharacterAccessor>()._SetLastClick(value); }
        }

        public string Name
        {
            get { return Cast<CharacterAccessor>()._GetName(); }
            set { Cast<CharacterAccessor>()._SetName(value); }
        }

        public Vector2 Position
        {
            get { return Cast<CharacterAccessor>()._GetPosition(); }
            set { Cast<CharacterAccessor>()._SetPosition(value); }
        }

        public float VelocityX
        {
            get { return Cast<CharacterAccessor>()._GetXVelocity(); }
            set { Cast<CharacterAccessor>()._SetXVelocity(value); }
        }

        public float VelocityY
        {
            get { return Cast<CharacterAccessor>()._GetYVelocity(); }
            set { Cast<CharacterAccessor>()._SetYVelocity(value); }
        }

        public float Scale
        {
            get { return Cast<CharacterAccessor>()._GetScale(); }
            set { Cast<CharacterAccessor>()._SetScale(value); }
        }

        public int Speed
        {
            get { return Cast<CharacterAccessor>()._GetSpeed(); }
            set { Cast<CharacterAccessor>()._SetSpeed(value); }
        }

        public AnimatedSprite Sprite
        {
            get
            {
                var tmp = Cast<CharacterAccessor>()._GetSprite();
                if (tmp == null) return null;
                return new AnimatedSprite(Parent, tmp);
            }
            set { Cast<CharacterAccessor>()._SetSprite(value?.Cast<AnimatedSpriteAccessor>()); }
        }
    }
}