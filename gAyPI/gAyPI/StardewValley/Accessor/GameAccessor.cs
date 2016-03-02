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
        SpriteBatch _GetSpriteBatch();

        SpriteFont _GetSmoothFont();

        FarmerAccessor _GetPlayer();
    }
}
