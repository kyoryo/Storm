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

namespace Storm.StardewValley.Wrapper
{
    public class Crop : Wrapper<CropAccessor>
    {
        public StaticContext Parent { get; }
        private CropAccessor accessor;

        public Crop(StaticContext parent, CropAccessor accessor)
        {
            this.Parent = parent;
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
