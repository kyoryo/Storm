using Microsoft.Xna.Framework;
using Storm.StardewValley.Accessor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storm.StardewValley.Wrapper
{
    public class FarmAnimal : Character
    {    
        public FarmAnimal(StaticContext parent, CharacterAccessor accessor) :
            base(parent, accessor)
        {
        }

        public FarmAnimal()
        {
        }

        public int DefaultProduceIndex
        {
            get { return Cast<FarmAnimalAccessor>()._GetDefaultProduceIndex(); }
            set { Cast<FarmAnimalAccessor>()._SetDefaultProduceIndex(value); }
        }

        public int DeluxeProduceIndex
        {
            get { return Cast<FarmAnimalAccessor>()._GetDeluxeProduceIndex(); }
            set { Cast<FarmAnimalAccessor>()._SetDeluxeProduceIndex(value); }
        }

        public int CurrentProduce
        {
            get { return Cast<FarmAnimalAccessor>()._GetCurrentProduce(); }
            set { Cast<FarmAnimalAccessor>()._SetCurrentProduce(value); }
        }

        public int FriendshipTowardsFarmer
        {
            get { return Cast<FarmAnimalAccessor>()._GetFriendshipTowardFarmer(); }
            set { Cast<FarmAnimalAccessor>()._SetFriendshipTowardFarmer(value); }
        }

        public int DaysSinceLastFed
        {
            get { return Cast<FarmAnimalAccessor>()._GetDaysSinceLastFed(); }
            set { Cast<FarmAnimalAccessor>()._SetDaysSinceLastFed(value); }
        }

        public int PushAccumulator
        {
            get { return Cast<FarmAnimalAccessor>()._GetPushAccumulator(); }
            set { Cast<FarmAnimalAccessor>()._SetPushAccumulator(value); }
        }

        public int UniqueFrameAccumulator
        {
            get { return Cast<FarmAnimalAccessor>()._GetUniqueFrameAccumulator(); }
            set { Cast<FarmAnimalAccessor>()._SetUniqueFrameAccumulator(value); }
        }

        public int Age
        {
            get { return Cast<FarmAnimalAccessor>()._GetAge(); }
            set { Cast<FarmAnimalAccessor>()._SetAge(value); }
        }

        public int MeatIndex
        {
            get { return Cast<FarmAnimalAccessor>()._GetMeatIndex(); }
            set { Cast<FarmAnimalAccessor>()._SetMeatIndex(value); }
        }

        public int Health
        {
            get { return Cast<FarmAnimalAccessor>()._GetHealth(); }
            set { Cast<FarmAnimalAccessor>()._SetHealth(value); }
        }

        public int Price
        {
            get { return Cast<FarmAnimalAccessor>()._GetPrice(); }
            set { Cast<FarmAnimalAccessor>()._SetPrice(value); }
        }

        public int ProduceQuality
        {
            get { return Cast<FarmAnimalAccessor>()._GetProduceQuality(); }
            set { Cast<FarmAnimalAccessor>()._SetProduceQuality(value); }
        }

        public byte DaysToLay
        {
            get { return Cast<FarmAnimalAccessor>()._GetDaysToLay(); }
            set { Cast<FarmAnimalAccessor>()._SetDaysToLay(value); }
        }

        public byte DaysSinceLastLay
        {
            get { return Cast<FarmAnimalAccessor>()._GetDaysSinceLastLay(); }
            set { Cast<FarmAnimalAccessor>()._SetDaysSinceLastLay(value); }
        }

        public byte AgeWhenMature
        {
            get { return Cast<FarmAnimalAccessor>()._GetAgeWhenMature(); }
            set { Cast<FarmAnimalAccessor>()._SetAgeWhenMature(value); }
        }

        public byte HarvestType
        {
            get { return Cast<FarmAnimalAccessor>()._GetHarvestType(); }
            set { Cast<FarmAnimalAccessor>()._SetHarvestType(value); }
        }
        public byte Happiness
        {
            get { return Cast<FarmAnimalAccessor>()._GetHappiness(); }
            set { Cast<FarmAnimalAccessor>()._SetHappiness(value); }
        }
        public byte Fullness
        {
            get { return Cast<FarmAnimalAccessor>()._GetFullness(); }
            set { Cast<FarmAnimalAccessor>()._SetFullness(value); }
        }

        public byte HappinessDrain
        {
            get { return Cast<FarmAnimalAccessor>()._GetHappinessDrain(); }
            set { Cast<FarmAnimalAccessor>()._SetHappinessDrain(value); }
        }

        public byte FullnessDrain
        {
            get { return Cast<FarmAnimalAccessor>()._GetFullnessDrain(); }
            set { Cast<FarmAnimalAccessor>()._SetFullnessDrain(value); }
        }

        public bool WasPet
        {
            get { return Cast<FarmAnimalAccessor>()._GetWasPet(); }
            set { Cast<FarmAnimalAccessor>()._SetWasPet(value); }
        }

        public bool ShowDifferentTextureWhenReadyForHarvest
        {
            get { return Cast<FarmAnimalAccessor>()._GetShowDifferentTextureWhenReadyForHarvest(); }
            set { Cast<FarmAnimalAccessor>()._SetShowDifferentTextureWhenReadyForHarvest(value); }
        }

        public bool AllowReproduction
        {
            get { return Cast<FarmAnimalAccessor>()._GetAllowReproduction(); }
            set { Cast<FarmAnimalAccessor>()._SetAllowReproduction(value); }
        }

        public String Sound
        {
            get { return Cast<FarmAnimalAccessor>()._GetSound(); }
            set { Cast<FarmAnimalAccessor>()._SetSound(value); }
        }

        public String Type
        {
            get { return Cast<FarmAnimalAccessor>()._GetType(); }
            set { Cast<FarmAnimalAccessor>()._SetType(value); }
        }

        public String BuildingTypeILiveIn
        {
            get { return Cast<FarmAnimalAccessor>()._GetBuildingTypeILiveIn(); }
            set { Cast<FarmAnimalAccessor>()._SetBuildingTypeILiveIn(value); }
        }

        public String ToolUsedForHarvest
        {
            get { return Cast<FarmAnimalAccessor>()._GetToolUsedForHarvest(); }
            set { Cast<FarmAnimalAccessor>()._SetToolUsedForHarvest(value); }
        }

        public Rectangle FrontBackBoundingBox
        {
            get { return Cast<FarmAnimalAccessor>()._GetFrontBackBoundingBox(); }
            set { Cast<FarmAnimalAccessor>()._SetFrontBackBoundingBox(value); }
        }

        public Rectangle SidewaysBoundingBox
        {
            get { return Cast<FarmAnimalAccessor>()._GetSidewaysBoundingBox(); }
            set { Cast<FarmAnimalAccessor>()._SetSidewaysBoundingBox(value); }
        }

        public Rectangle FrontBackSourceRect
        {
            get { return Cast<FarmAnimalAccessor>()._GetFrontBackSourceRect(); }
            set { Cast<FarmAnimalAccessor>()._SetFrontBackSourceRect(value); }
        }

        public Rectangle SidewaysSourceRect
        {
            get { return Cast<FarmAnimalAccessor>()._GetSidewaysSourceRect(); }
            set { Cast<FarmAnimalAccessor>()._SetSidewaysSourceRect(value); }
        }

        public long MyID
        {
            get { return Cast<FarmAnimalAccessor>()._GetMyID(); }
            set { Cast<FarmAnimalAccessor>()._SetMyID(value); }
        }

        public long OwnerID
        {
            get { return Cast<FarmAnimalAccessor>()._GetOwnerID(); }
            set { Cast<FarmAnimalAccessor>()._SetOwnerID(value); }
        }

        public long ParentID
        {
            get { return Cast<FarmAnimalAccessor>()._GetParentId(); }
            set { Cast<FarmAnimalAccessor>()._SetParentId(value); }
        }

        public Vector2 HomeLocation
        {
            get { return Cast<FarmAnimalAccessor>()._GetHomeLocation(); }
            set { Cast<FarmAnimalAccessor>()._SetHomeLocation(value); }
        }

        public int NoWarpTime
        {
            get { return Cast<FarmAnimalAccessor>()._GetNoWarpTimer(); }
            set { Cast<FarmAnimalAccessor>()._SetNoWarpTimer(value); }
        }

        public int HitGlowTimer
        {
            get { return Cast<FarmAnimalAccessor>()._GetHitGlowTimer(); }
            set { Cast<FarmAnimalAccessor>()._SetHitGlowTimer(value); }
        }

        public int PauseTimer
        {
            get { return Cast<FarmAnimalAccessor>()._GetPauseTimer(); }
            set { Cast<FarmAnimalAccessor>()._SetPauseTimer(value); }
        }

        public Int16 MoodMessage
        {
            get { return Cast<FarmAnimalAccessor>()._GetMoodMessage(); }
            set { Cast<FarmAnimalAccessor>()._SetMoodMessage(value); }
        }

        public bool IsEating
        {
            get { return Cast<FarmAnimalAccessor>()._GetIsEating(); }
            set { Cast<FarmAnimalAccessor>()._SetIsEating(value); }
        }




    }
}
