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

using Microsoft.Xna.Framework;
using Storm.StardewValley.Accessor;

namespace Storm.StardewValley.Wrapper
{
    public class ObjectItem : Item
    {
        public ObjectItem(StaticContext parent, ObjectAccessor accessor) :
            base(parent, accessor)
        {
        }

        public ObjectItem()
        {
        }

        public int SellToStorePrice
        {
            get { return Cast<ObjectAccessor>()._GetSellToStorePrice(); }
        }

        public Vector2 TileLocation
        {
            get { return Cast<ObjectAccessor>()._GetTileLocation(); }
            set { Cast<ObjectAccessor>()._SetTileLocation(value); }
        }

        public bool CanBeGrabbed
        {
            get { return Cast<ObjectAccessor>()._GetCanBeGrabbed(); }
            set { Cast<ObjectAccessor>()._SetCanBeGrabbed(value); }
        }

        public bool CanBeSetDown
        {
            get { return Cast<ObjectAccessor>()._GetCanBeSetDown(); }
            set { Cast<ObjectAccessor>()._SetCanBeSetDown(value); }
        }

        public int Edibility
        {
            get { return Cast<ObjectAccessor>()._GetEdibility(); }
            set { Cast<ObjectAccessor>()._SetEdibility(value); }
        }

        public bool Flipped
        {
            get { return Cast<ObjectAccessor>()._GetFlipped(); }
            set { Cast<ObjectAccessor>()._SetFlipped(value); }
        }

        public int Fragility
        {
            get { return Cast<ObjectAccessor>()._GetFragility(); }
            set { Cast<ObjectAccessor>()._SetFragility(value); }
        }

        public bool HasBeenPickedUpByFarmer
        {
            get { return Cast<ObjectAccessor>()._GetHasBeenPickedUpByFarmer(); }
            set { Cast<ObjectAccessor>()._SetHasBeenPickedUpByFarmer(value); }
        }

        public bool IsActive
        {
            get { return Cast<ObjectAccessor>()._GetIsActive(); }
            set { Cast<ObjectAccessor>()._SetIsActive(value); }
        }

        public bool IsHoeDirt
        {
            get { return Cast<ObjectAccessor>()._GetIsHoedirt(); }
            set { Cast<ObjectAccessor>()._SetIsHoedirt(value); }
        }

        public bool IsLamp
        {
            get { return Cast<ObjectAccessor>()._GetIsLamp(); }
            set { Cast<ObjectAccessor>()._SetIsLamp(true); }
        }

        public bool IsOn
        {
            get { return Cast<ObjectAccessor>()._GetIsOn(); }
            set { Cast<ObjectAccessor>()._SetIsOn(value); }
        }

        public bool IsRecipe
        {
            get { return Cast<ObjectAccessor>()._GetIsRecipe(); }
            set { Cast<ObjectAccessor>()._SetIsRecipe(value); }
        }

        public bool IsSpawned
        {
            get { return Cast<ObjectAccessor>()._GetIsSpawnedObject(); }
            set { Cast<ObjectAccessor>()._SetIsSpawnedObject(value); }
        }

        public string Name
        {
            get { return Cast<ObjectAccessor>()._GetName(); }
            set { Cast<ObjectAccessor>()._SetName(value); }
        }

        public long Owner
        {
            get { return Cast<ObjectAccessor>()._GetOwner(); }
            set { Cast<ObjectAccessor>()._SetOwner(value); }
        }

        public int Price
        {
            get { return Cast<ObjectAccessor>()._GetPrice(); }
            set { Cast<ObjectAccessor>()._SetPrice(value); }
        }

        public int Quality
        {
            get { return Cast<ObjectAccessor>()._GetQuality(); }
            set { Cast<ObjectAccessor>()._SetQuality(value); }
        }

        public int Stack
        {
            get { return Cast<ObjectAccessor>()._GetStack(); }
            set { Cast<ObjectAccessor>()._SetStack(value); }
        }


        public bool IsQuestItem
        {
            get { return Cast<ObjectAccessor>()._GetQuestItem(); }
            set { Cast<ObjectAccessor>()._SetQuestItem(value); }
        }

        public bool ReadyForHarvest
        {
            get { return Cast<ObjectAccessor>()._GetReadyForHarvest(); }
            set { Cast<ObjectAccessor>()._SetReadyForHarvest(value); }
        }

        public Vector2 Scale
        {
            get { return Cast<ObjectAccessor>()._GetScale(); }
            set { Cast<ObjectAccessor>()._SetScale(value); }
        }

        public string Type
        {
            get { return Cast<ObjectAccessor>()._GetType(); }
            set { Cast<ObjectAccessor>()._SetType(value); }
        }

        public ObjectItem HeldObject
        {
            get
            {
                var tmp = Cast<ObjectAccessor>()._GetHeldObject();
                if (tmp == null) return null;
                return new ObjectItem(Parent, tmp);
            }
            set { Cast<ObjectAccessor>()._SetHeldObject(value?.Cast<ObjectAccessor>()); }
        }

        public int MinutesUntilReady
        {
            get { return Cast<ObjectAccessor>()._GetMinutesUntilReady(); }
            set { Cast<ObjectAccessor>()._SetMinutesUntilReady(value); }
        }

        public Rectangle BoundingBox
        {
            get { return Cast<ObjectAccessor>()._GetBoundingBox(); }
            set { Cast<ObjectAccessor>()._SetBoundingBox(value); }
        }

    }
}