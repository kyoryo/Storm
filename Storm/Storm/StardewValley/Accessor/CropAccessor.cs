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
        double _GetChanceForExtraCrops();
        void _SetChanceForExtraCrops(double chance);

        int _GetCurrentPhase();
        void _SetCurrentPhase(int phase);

        int _GetDayOfCurrentPhase();
        void _SetDayOfCurrentPhase(int day);

        IList _GetPhaseDays();
        void _SetPhaseDays(IList days);

        bool _GetIsDead();
        void _SetIsDead(bool dead);

        bool _GetFlip();
        void _SetFlip(bool flip);

        bool _GetForageCrop();
        void _SetForageCrop(bool forageCrop);

        bool _GetIsFullyGrown();
        void _SetIsFullyGrown(bool fullyGrown);

        int _GetHarvestMethod();
        void _SetHarvestMethod(int harvestMethod);

        int _GetIndexOfHarvest();
        void _SetIndexOfHarvest(int index);

        int _GetMaxHarvest();
        void _SetMaxHarvest(int max);

        int _GetMaxHarvestIncreasePerFarmingLevel();
        void _SetMaxHarvestIncreasePerFarmingLevel(int max);

        int _GetMinHarvest();
        void _SetMinHarvest(int min);

        int _GetPhaseToShow();
        void _SetPhaseToShow(int phase);

        bool _GetProgramColored();
        void _SetProgramColored(bool colored);

        bool _GetHasRaisedSeeds();
        void _SetHasRaisedSeeds(bool has);

        int _GetRegrowAfterHarvest();
        void _SetRegrowAfterHarvest(int regrow);
    }
}