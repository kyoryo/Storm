using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using xTile.Dimensions;

namespace gAyPI.StardewValley.Accessor
{
    public interface GameAccessor
    {
        SpriteBatch _GetSpriteBatch();

        SpriteFont _GetSmoothFont();

        int _GetTileSize();

        Rectangle _GetViewport();

        FarmerAccessor _GetPlayer();

        GameLocationAccessor _GetCurrentLocation();

        void _UnlockSteamAchievement(string name);
    }
}
