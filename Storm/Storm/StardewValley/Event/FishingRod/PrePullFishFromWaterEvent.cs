/*
    Copyright 2016 Russell Long (InfinitySamurai), Zoey (Zoryn)

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

using Storm.StardewValley.Wrapper;

namespace Storm.StardewValley.Event
{
    public class PrePullFishFromWaterEvent : StaticContextEvent
    {
        public PrePullFishFromWaterEvent(FishingRod rod, int whichFish, int fishSize, int fishQuality, int fishDifficulty, bool treasureCaught, bool wasPerfect)
        {
            Rod = rod;
            WhichFish = whichFish;
            FishSize = fishSize;
            FishQuality = fishQuality;
            FishDifficulty = fishDifficulty;
            TreasureCaught = treasureCaught;
            WasPerfect = wasPerfect;
        }

        public FishingRod Rod { get; set; }
        public int WhichFish { get; }
        public int FishSize { get; }
        public int FishQuality { get; }
        public int FishDifficulty { get; }
        public bool TreasureCaught { get; }
        public bool WasPerfect { get; }
    }
}