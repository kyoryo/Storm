using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gAyPI.StardewValley.Accessor
{
    public interface GameAccessor
    {
        SpriteBatch GetSpriteBatch();

        SpriteFont GetSmoothFont();

        FarmerAccessor GetPlayer();
    }
}
