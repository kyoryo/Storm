using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storm.StardewValley.Accessor
{
    public interface AnimatedSpriteAccessor
    {
        Texture2D _GetSpriteTexture();
        int _GetSpriteWidth();
        int _GetSpriteHeight();
    }
}
