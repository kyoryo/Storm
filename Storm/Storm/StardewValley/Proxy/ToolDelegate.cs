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
using Storm.StardewValley.Wrapper;

namespace Storm.StardewValley.Proxy
{
    public abstract class ToolDelegate : TypeDelegate<Tool>
    {
        [ProxyMap(Name = "DrawInMenu")]
        public abstract void DrawInMenu(SpriteBatch b, Vector2 loc, float scaleSize, float transparency, float layerDepth, bool drawStackNumber);

        [ProxyMap(Name = "BeginUsing")]
        public abstract void BeginUsing(GameLocation location, int x, int y, Farmer farmer);
    }
}