using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using xTile.Dimensions;

namespace Storm.StardewValley.Accessor
{
    public interface StaticContextAccessor
    {
        SpriteBatch _GetSpriteBatch();

        SpriteFont _GetSmoothFont();

        GraphicsDeviceManager _GetGraphicsDeviceManager();

        int _GetTileSize();

        xTile.Dimensions.Rectangle _GetViewport();

        FarmerAccessor _GetPlayer();

        GameLocationAccessor _GetCurrentLocation();

        void _UnlockSteamAchievement(string name);
    }
}
