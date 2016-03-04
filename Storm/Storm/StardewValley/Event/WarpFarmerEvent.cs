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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storm.StardewValley.Event
{
    public class WarpFarmerEvent : StaticContextEvent
    {
        private GameLocationAccessor location;
        private int tileX;
        private int tileY;
        private int facingDirection;
        private bool isStructure;

        public WarpFarmerEvent(GameLocationAccessor location, int tileX, int tileY, int facingDirection, bool isStructure)
        {
            this.location = location;
            this.tileX = tileX;
            this.tileY = tileY;
            this.facingDirection = facingDirection;
            this.isStructure = isStructure;
        }

        public GameLocationAccessor Location {get { return location; } }
        public int TileX { get { return tileX; } }
        public int TileY { get { return tileY; } }
        public int FacingDirection { get { return facingDirection; } }
        public bool IsStructure { get { return isStructure; } }
    }
}
