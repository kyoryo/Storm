using Storm.StardewValley.Accessor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storm.StardewValley.Wrapper
{
    public class Crop : Wrapper<CropAccessor>
    {
        private CropAccessor accessor;

        public Crop(CropAccessor accessor)
        {
            this.accessor = accessor;
        }

        public double ChanceForExtraCrops
        {
            get { return accessor._GetChanceForExtraCrops(); }
            set { accessor._SetChanceForExtraCrops(value); }
        }

        public int CurrentPhase
        {
            get { return accessor._GetCurrentPhase(); }
            set { accessor._SetCurrentPhase(value); }
        }

        public bool IsDead
        {
            get { return accessor._GetIsDead(); }
            set { accessor._SetIsDead(true); }
        }

        public bool Flip
        {
            get { return accessor._GetFlip(); }
            set { accessor._SetFlip(value); }
        }

        public bool ForageCrop
        {
            get { return accessor._GetForageCrop(); }
            set { accessor._SetForageCrop(value); }
        }

        public bool IsFullyGrown
        {
            get { return accessor._GetIsFullyGrown(); }
            set { accessor._SetIsFullyGrown(value); }
        }

        public int HarvestMethod
        {
            get { return accessor._GetHarvestMethod(); }
            set { accessor._SetHarvestMethod(value); }
        }

        public int IndexOfHarvest
        {
            get { return accessor._GetIndexOfHarvest(); }
            set { accessor._SetIndexOfHarvest(value); }
        }

        public int MaxHarvest
        {
            get { return accessor._GetMaxHarvest(); }
            set { accessor._SetMaxHarvest(value); }
        }

        public int MaxHarvestIncreasePerFarmingLevel
        {
            get { return accessor._GetMaxHarvestIncreasePerFarmingLevel(); }
            set { accessor._SetMaxHarvestIncreasePerFarmingLevel(value); }
        }

        public int MinHarvest
        {
            get { return accessor._GetMinHarvest(); }
            set { accessor._SetMinHarvest(value); }
        }

        public int PhaseToShow
        {
            get { return accessor._GetPhaseToShow(); }
            set { accessor._SetPhaseToShow(value); }
        }

        public bool ProgramColored
        {
            get { return accessor._GetProgramColored(); }
            set { accessor._SetProgramColored(value); }
        }

        public bool HasRaisedSeeds
        {
            get { return accessor._GetHasRaisedSeeds(); }
            set { accessor._SetHasRaisedSeeds(value); }
        }

        public int RegrowAfterHarvest
        {
            get { return accessor._GetRegrowAfterHarvest(); }
            set { accessor._SetRegrowAfterHarvest(value); }
        }

        public CropAccessor Expose() => accessor;
    }
}
