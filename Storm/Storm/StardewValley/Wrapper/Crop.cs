/*
    Copyright 2016 Cody R. (Demmonic), Inari-Whitebear

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

using Storm.Collections;
using Storm.StardewValley.Accessor;

namespace Storm.StardewValley.Wrapper
{
    public class Crop : StaticContextWrapper
    {
        public Crop(StaticContext parent, CropAccessor accessor) :
            base(parent)
        {
            Underlying = accessor;
        }

        public Crop()
        {
        }

        /// <summary>
        /// The chance for this crop to drop extra products
        /// </summary>
        /// <value>The ChanceForExtraCrops property gets/sets the value of the double field ChanceForExtraCrops </value>
        public double ChanceForExtraCrops
        {
            get { return Cast<CropAccessor>()._GetChanceForExtraCrops(); }
            set { Cast<CropAccessor>()._SetChanceForExtraCrops(value); }
        }

        /// <summary>
        /// The current phase of this crops growth cycle
        /// Typical crops have 5 phases of growth, as visualised by their growing sprites
        /// </summary>
        /// <value>The CurrentPhase property gets/sets the value of the int field currentPhase</value>
        public int CurrentPhase
        {
            get { return Cast<CropAccessor>()._GetCurrentPhase(); }
            set { Cast<CropAccessor>()._SetCurrentPhase(value); }
        }

        /// <summary>
        /// The current day of the current phase of the Crop.
        /// </summary>
        /// <value>The DayOfCurrentPhase property gets/sets the value of the int field dayOfCurrentPhase</value>
        public int DayOfCurrentPhase
        {
            get { return Cast<CropAccessor>()._GetDayOfCurrentPhase(); }
            set { Cast<CropAccessor>()._SetCurrentPhase(value); }
        }

        /// <summary>
        /// A list of phase days of the Crop.
        /// </summary>
        /// <value>The PhaseDays property gets/sets the value of the List<int> field phaseDays</value>
        public ProxyList<int> PhaseDays
        {
            get
            {
                var tmp = Cast<CropAccessor>()._GetPhaseDays();
                if (tmp == null) return null;
                return new ProxyList<int>(tmp);
            }
        }

        /// <summary>
        /// Whether this crop is dead or not
        /// </summary>
        /// <value>The IsDead property gets/sets the value of the bool field IsDead</value>
        public bool IsDead
        {
            get { return Cast<CropAccessor>()._GetDead(); }
            set { Cast<CropAccessor>()._SetDead(true); }
        }

        public bool Flip
        {
            get { return Cast<CropAccessor>()._GetFlip(); }
            set { Cast<CropAccessor>()._SetFlip(value); }
        }

        public bool ForageCrop
        {
            get { return Cast<CropAccessor>()._GetForageCrop(); }
            set { Cast<CropAccessor>()._SetForageCrop(value); }
        }

        /// <summary>
        /// Whether this crop is fully grown or not
        /// </summary>
        /// <value>The IsFullyGrown property gets/sets the value of the bool field IsFullyGrown</value>
        public bool IsFullyGrown
        {
            get { return Cast<CropAccessor>()._GetFullyGrown(); }
            set { Cast<CropAccessor>()._SetFullyGrown(value); }
        }

        public int HarvestMethod
        {
            get { return Cast<CropAccessor>()._GetHarvestMethod(); }
            set { Cast<CropAccessor>()._SetHarvestMethod(value); }
        }

        public int IndexOfHarvest
        {
            get { return Cast<CropAccessor>()._GetIndexOfHarvest(); }
            set { Cast<CropAccessor>()._SetIndexOfHarvest(value); }
        }

        public int MaxHarvest
        {
            get { return Cast<CropAccessor>()._GetMaxHarvest(); }
            set { Cast<CropAccessor>()._SetMaxHarvest(value); }
        }

        public int MaxHarvestIncreasePerFarmingLevel
        {
            get { return Cast<CropAccessor>()._GetMaxHarvestIncreasePerFarmingLevel(); }
            set { Cast<CropAccessor>()._SetMaxHarvestIncreasePerFarmingLevel(value); }
        }

        public int MinHarvest
        {
            get { return Cast<CropAccessor>()._GetMinHarvest(); }
            set { Cast<CropAccessor>()._SetMinHarvest(value); }
        }

        public int PhaseToShow
        {
            get { return Cast<CropAccessor>()._GetPhaseToShow(); }
            set { Cast<CropAccessor>()._SetPhaseToShow(value); }
        }

        public bool ProgramColored
        {
            get { return Cast<CropAccessor>()._GetProgramColored(); }
            set { Cast<CropAccessor>()._SetProgramColored(value); }
        }

        public bool HasRaisedSeeds
        {
            get { return Cast<CropAccessor>()._GetRaisedSeeds(); }
            set { Cast<CropAccessor>()._SetRaisedSeeds(value); }
        }

        public int RegrowAfterHarvest
        {
            get { return Cast<CropAccessor>()._GetRegrowAfterHarvest(); }
            set { Cast<CropAccessor>()._SetRegrowAfterHarvest(value); }
        }

        public int RowInSpriteSheet
        {
            get { return Cast<CropAccessor>()._GetRowInSpriteSheet(); }
            set { Cast<CropAccessor>()._SetRowInSpriteSheet(value); }
        }

        public ProxyList<string> SeasonsToGrowIn
        {
            get
            {
                var tmp = Cast<CropAccessor>()._GetSeasonsToGrowIn();
                if (tmp == null) return null;
                return new ProxyList<string>(tmp);
            }
        }

        /// <summary>
        /// Grows the crop completely instantly
        /// </summary>
        public void GrowCompletely()
        {
            Cast<CropAccessor>()._GrowCompletely();
        }

        public bool Harvest(int xTile, int yTile, HoeDirtAccessor soil)
        {
            return Cast<CropAccessor>()._Harvest(xTile, yTile, soil);
        }

        public bool Harvest(int xTile, int yTile, HoeDirt soil)
        {
            return Harvest(xTile, yTile, soil.Cast<HoeDirtAccessor>());
        }
    }
}