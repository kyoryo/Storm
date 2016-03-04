﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
