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
