using Storm.StardewValley.Accessor;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using xTile.Dimensions;

namespace Storm.StardewValley.Wrapper
{
    public class StaticContext
    {
        private StaticContextAccessor accessor;

        public StaticContext(StaticContextAccessor accessor)
        {
            this.accessor = accessor;
        }

        public SpriteBatch GetSpriteBatch()
        {
            return accessor._GetSpriteBatch();
        }

        public SpriteFont GetSmoothFont()
        {
            return accessor._GetSmoothFont();
        }

        public GraphicsDeviceManager GetGraphicsDeviceManager()
        {
            return accessor._GetGraphicsDeviceManager();
        }

        public Texture2D LoadResource(string path)
        {
            var fs = new FileStream(path, FileMode.Create);
            var tex = Texture2D.FromStream(GetGraphicsDeviceManager().GraphicsDevice, fs);
            fs.Close();
            return tex;
        }

        public int GetTileSize()
        {
            return accessor._GetTileSize();
        }

        public xTile.Dimensions.Rectangle GetViewport()
        {
            return accessor._GetViewport();
        }

        public Farmer GetPlayer()
        {
            var farmer = accessor._GetPlayer();
            if (farmer == null) return null;
            return new Farmer(farmer);
        }

        public GameLocation GetCurrentLocation()
        {
            var location = accessor._GetCurrentLocation();
            if (location == null) return null;
            return new GameLocation(location);
        }

        public void UnlockSteamAchievement(string name)
        {
            accessor._UnlockSteamAchievement(name);
        }
    }
}
