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
    public class StaticContext : Wrapper<StaticContextAccessor>
    {
        private StaticContextAccessor accessor;

        public StaticContext(StaticContextAccessor accessor)
        {
            this.accessor = accessor;
        }

        public SpriteBatch SpriteBatch
        {
            get { return accessor._GetSpriteBatch(); }
        }

        public SpriteFont SmoothFont
        {
            get { return accessor._GetSmoothFont(); }
        }

        public SpriteFont TinyFont
        {
            get { return accessor._GetTinyFont(); }
        }

        public SpriteFont TinyFontBorder
        {
            get { return accessor._GetTinyFontBorder(); }
        }
        
        public GraphicsDeviceManager GraphicsDeviceManager
        {
            get { return accessor._GetGraphicsDeviceManager(); }
        }

        public Texture2D LoadResource(string path)
        {
            var fs = new FileStream(path, FileMode.Open);
            var tex = Texture2D.FromStream(GraphicsDeviceManager.GraphicsDevice, fs);
            fs.Close();
            return tex;
        }

        public int TileSize
        {
            get { return accessor._GetTileSize(); }
        }

        public string Version
        {
            get { return accessor._GetVersionString(); }
            set { accessor._SetVersionString(value);  }
        }

        public GameWindow Window
        {
            get { return ((Game)accessor).Window; }
        }

        public xTile.Dimensions.Rectangle Viewport
        {
            get { return accessor._GetViewport(); }
        }

        public Farmer Player
        {
            get
            {
                var farmer = accessor._GetPlayer();
                if (farmer == null) return null;
                return new Farmer(farmer);
            }
        }

        public GameLocation CurrentLocation
        {
            get
            {
                var location = accessor._GetCurrentLocation();
                return location == null ? null : new GameLocation(location);
            }
        }

        public void UnlockSteamAchievement(string name)
        {
            accessor._UnlockSteamAchievement(name);
        }

        public int PixelZoom
        {
            get { return accessor._GetPixelZoom(); }
        }

        public StaticContextAccessor Expose() => accessor;
    }
}
