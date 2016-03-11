/*
    Copyright 2016 Shane Filiatrault

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

namespace Storm.StardewValley.Event
{
    public class PostFishingRodTickUpdateEvent : StaticContextEvent
    {
        public PostFishingRodTickUpdateEvent(Wrapper.FishingRod rod, Microsoft.Xna.Framework.GameTime time, Wrapper.Farmer who)
        {
            Rod = rod;
            Time = time;
            Who = who;
        }

        public Wrapper.FishingRod Rod { set; get; }
        public Microsoft.Xna.Framework.GameTime Time { set; get; }
        public Wrapper.Farmer Who { set; get; }
    }
}
