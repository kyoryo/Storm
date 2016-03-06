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
using Storm.StardewValley.Wrapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storm.StardewValley.Event
{
    public class WarpFarmerEvent : StaticContextEvent
    {
        private GameLocation Location { get; }
        private int TileX { get; }
        private int TileY { get; }
        private int FacingDirection { get; }
        private bool IsStructure { get; }

        public WarpFarmerEvent(GameLocation location, int tileX, int tileY, int facingDirection, bool isStructure)
        {
            this.Location = location;
            this.TileX = tileX;
            this.TileY = tileY;
            this.FacingDirection = facingDirection;
            this.IsStructure = isStructure;
        }
    }
}
