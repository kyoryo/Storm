/*
    Copyright 2016

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
using Storm.StardewValley.Wrapper;

namespace Storm.StardewValley.Event
{
    public class PostDayUpdateHoeDirtEvent : StaticContextEvent
    {
        public PostDayUpdateHoeDirtEvent(HoeDirt hoeDirt, GameLocation environment, Vector2 tilelocation)
        {
            HoeDirt = hoeDirt;
            Environment = environment;
            TileLocation = tilelocation;
        }

        public HoeDirt HoeDirt { get; }
        public GameLocation Environment { get; }
        public Vector2 TileLocation { get; }
    }
}