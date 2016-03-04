using Microsoft.Xna.Framework.Graphics;
using Storm.StardewValley.Accessor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storm.StardewValley.Wrapper
{
    public class AnimatedSprite
    {
        private AnimatedSpriteAccessor accessor;

        public AnimatedSprite(AnimatedSpriteAccessor accessor)
        {
            this.accessor = accessor;
        }

        public Texture2D getSpriteTexture()
        {
            return accessor._GetSpriteTexture();
        }

        public int getSpriteWidth()
        {
            return accessor._GetSpriteWidth();
        }

        public int getSpriteHeight()
        {
            return accessor._GetSpriteHeight();
        }
    }
}
