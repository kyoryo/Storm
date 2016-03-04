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
using Microsoft.Xna.Framework;
using Storm.StardewValley.Accessor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storm.StardewValley.Wrapper
{
    public class Object : Item
    {
        private ObjectAccessor accessor;

        public Object(ObjectAccessor accessor) : base(accessor)
        {
            this.accessor = accessor;
        }

        public bool CanBeGrabbed
        {
            get { return accessor._GetCanBeGrabbed(); }
            set { accessor._SetCanBeGrabbed(value); }
        }

        public bool CanBeSetDown
        {
            get { return accessor._GetCanBeSetDown(); }
            set { accessor._SetCanBeSetDown(value); }
        }

        public int Edibility
        {
            get { return accessor._GetEdibility(); }
            set { accessor._SetEdibility(value); }
        }

        public bool Flipped
        {
            get { return accessor._GetFlipped(); }
            set { accessor._SetFlipped(value); }
        }

        public int Fragility
        {
            get { return accessor._GetFragility(); }
            set { accessor._SetFragility(value); }
        }

        public bool HasBeenPickedUpByFarmer
        {
            get { return accessor._GetHasBeenPickedUpByFarmer(); }
            set { accessor._SetHasBeenPickedUpByFarmer(value); }
        }

        public bool IsActive
        {
            get { return accessor._GetIsActive(); }
            set { accessor._SetIsActive(value); }
        }

        public bool IsHoeDirt
        {
            get { return accessor._GetIsHoeDirt(); }
            set { accessor._SetIsHoeDirt(value); }
        }

        public bool IsLamp
        {
            get { return accessor._GetIsLamp(); }
            set { accessor._SetIsLamp(true); }
        }

        public bool IsOn
        {
            get { return accessor._GetIsOn(); }
            set { accessor._SetIsOn(value); }
        }

        public bool IsRecipe
        {
            get { return accessor._GetIsRecipe(); }
            set { accessor._SetIsRecipe(value); }
        }

        public bool IsSpawned
        {
            get { return accessor._GetIsSpawnedObject(); }
            set { accessor._SetIsSpawnedObject(value); }
        }

        public string Name
        {
            get { return accessor._GetName(); }
            set { accessor._SetName(value); }
        }

        public long Owner
        {
            get { return accessor._GetOwner(); }
            set { accessor._SetOwner(value);  }
        }

        public int Price
        {
            get { return accessor._GetPrice(); }
            set { accessor._SetPrice(value); }
        }

        public int Quality
        {
            get { return accessor._GetQuality(); }
            set { accessor._SetQuality(value); }
        }

        public bool IsQuestItem
        {
            get { return accessor._GetIsQuestItem(); }
            set { accessor._SetIsQuestItem(value);  }
        }

        public bool ReadyForHarvest
        {
            get { return accessor._GetIsReadyForHarvest(); }
            set { accessor._SetIsReadyForHarvest(value); }
        }

        public Vector2 Scale
        {
            get { return accessor._GetScale(); }
            set { accessor._SetScale(value); }
        }

        public string Type
        {
            get { return accessor._GetType(); }
            set { accessor._SetType(value); }
        }
    }
}
