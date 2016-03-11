/*
    Copyright 2016 Inari-Whitebear

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
    public class AnimatedSprite : StaticContextWrapper
    {
        public AnimatedSprite(StaticContext parent, AnimatedSpriteAccessor accessor) :
            base(parent)
        {
            Underlying = accessor;
        }

        public AnimatedSprite()
        {
        }

        public Texture2D SpriteTexture
        {
            get { return Cast<AnimatedSpriteAccessor>()._GetSpriteTexture(); }
        }

        public int SpriteWidth
        {
            get { return Cast<AnimatedSpriteAccessor>()._GetSpriteWidth(); }
        }

        public int SpriteHeight
        {
            get { return Cast<AnimatedSpriteAccessor>()._GetSpriteHeight(); }
        }
    }
}