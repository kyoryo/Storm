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

using System.Collections;

namespace Storm.StardewValley.Accessor
{
    public interface CropAccessor
    {
        System.Collections.IList _GetPhaseDays();
        void _SetPhaseDays(System.Collections.IList val);

        int _GetRowInSpriteSheet();
        void _SetRowInSpriteSheet(int val);

        int _GetPhaseToShow();
        void _SetPhaseToShow(int val);

        int _GetCurrentPhase();
        void _SetCurrentPhase(int val);

        int _GetHarvestMethod();
        void _SetHarvestMethod(int val);

        int _GetIndexOfHarvest();
        void _SetIndexOfHarvest(int val);

        int _GetRegrowAfterHarvest();
        void _SetRegrowAfterHarvest(int val);

        int _GetDayOfCurrentPhase();
        void _SetDayOfCurrentPhase(int val);

        int _GetMinHarvest();
        void _SetMinHarvest(int val);

        int _GetMaxHarvest();
        void _SetMaxHarvest(int val);

        int _GetMaxHarvestIncreasePerFarmingLevel();
        void _SetMaxHarvestIncreasePerFarmingLevel(int val);

        int _GetDaysOfUnclutteredGrowth();
        void _SetDaysOfUnclutteredGrowth(int val);

        int _GetWhichForageCrop();
        void _SetWhichForageCrop(int val);

        System.Collections.IList _GetSeasonsToGrowIn();
        void _SetSeasonsToGrowIn(System.Collections.IList val);

        Microsoft.Xna.Framework.Color _GetTintColor();
        void _SetTintColor(Microsoft.Xna.Framework.Color val);

        bool _GetFlip();
        void _SetFlip(bool val);

        bool _GetFullyGrown();
        void _SetFullyGrown(bool val);

        bool _GetRaisedSeeds();
        void _SetRaisedSeeds(bool val);

        bool _GetProgramColored();
        void _SetProgramColored(bool val);

        bool _GetDead();
        void _SetDead(bool val);

        bool _GetForageCrop();
        void _SetForageCrop(bool val);

        double _GetChanceForExtraCrops();
        void _SetChanceForExtraCrops(double val);

        void _GrowCompletely();

        bool _Harvest(int xTile, int yTile, HoeDirtAccessor soil);
    }
}