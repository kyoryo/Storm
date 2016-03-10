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

namespace Storm.StardewValley.Accessor
{
    public interface FarmAnimalAccessor : CharacterAccessor
    {
        int _GetDefaultProduceIndex();
        void _SetDefaultProduceIndex(int val);

        int _GetDeluxeProduceIndex();
        void _SetDeluxeProduceIndex(int val);

        int _GetCurrentProduce();
        void _SetCurrentProduce(int val);

        int _GetFriendshipTowardFarmer();
        void _SetFriendshipTowardFarmer(int val);

        int _GetDaysSinceLastFed();
        void _SetDaysSinceLastFed(int val);

        int _GetPushAccumulator();
        void _SetPushAccumulator(int val);

        int _GetUniqueFrameAccumulator();
        void _SetUniqueFrameAccumulator(int val);

        int _GetAge();
        void _SetAge(int val);

        int _GetMeatIndex();
        void _SetMeatIndex(int val);

        int _GetHealth();
        void _SetHealth(int val);

        int _GetPrice();
        void _SetPrice(int val);

        int _GetProduceQuality();
        void _SetProduceQuality(int val);

        byte _GetDaysToLay();
        void _SetDaysToLay(byte val);

        byte _GetDaysSinceLastLay();
        void _SetDaysSinceLastLay(byte val);

        byte _GetAgeWhenMature();
        void _SetAgeWhenMature(byte val);

        byte _GetHarvestType();
        void _SetHarvestType(byte val);

        byte _GetHappiness();
        void _SetHappiness(byte val);

        byte _GetFullness();
        void _SetFullness(byte val);

        byte _GetHappinessDrain();
        void _SetHappinessDrain(byte val);

        byte _GetFullnessDrain();
        void _SetFullnessDrain(byte val);

        bool _GetWasPet();
        void _SetWasPet(bool val);

        bool _GetShowDifferentTextureWhenReadyForHarvest();
        void _SetShowDifferentTextureWhenReadyForHarvest(bool val);

        bool _GetAllowReproduction();
        void _SetAllowReproduction(bool val);

        System.String _GetSound();
        void _SetSound(System.String val);

        System.String _GetType();
        void _SetType(System.String val);

        System.String _GetBuildingTypeILiveIn();
        void _SetBuildingTypeILiveIn(System.String val);

        System.String _GetToolUsedForHarvest();
        void _SetToolUsedForHarvest(System.String val);

        Microsoft.Xna.Framework.Rectangle _GetFrontBackBoundingBox();
        void _SetFrontBackBoundingBox(Microsoft.Xna.Framework.Rectangle val);

        Microsoft.Xna.Framework.Rectangle _GetSidewaysBoundingBox();
        void _SetSidewaysBoundingBox(Microsoft.Xna.Framework.Rectangle val);

        Microsoft.Xna.Framework.Rectangle _GetFrontBackSourceRect();
        void _SetFrontBackSourceRect(Microsoft.Xna.Framework.Rectangle val);

        Microsoft.Xna.Framework.Rectangle _GetSidewaysSourceRect();
        void _SetSidewaysSourceRect(Microsoft.Xna.Framework.Rectangle val);

        long _GetMyID();
        void _SetMyID(long val);

        long _GetOwnerID();
        void _SetOwnerID(long val);

        long _GetParentId();
        void _SetParentId(long val);

        BuildingAccessor _GetHome();
        void _SetHome(BuildingAccessor val);

        Microsoft.Xna.Framework.Vector2 _GetHomeLocation();
        void _SetHomeLocation(Microsoft.Xna.Framework.Vector2 val);

        int _GetNoWarpTimer();
        void _SetNoWarpTimer(int val);

        int _GetHitGlowTimer();
        void _SetHitGlowTimer(int val);

        int _GetPauseTimer();
        void _SetPauseTimer(int val);

        System.Int16 _GetMoodMessage();
        void _SetMoodMessage(System.Int16 val);

        bool _GetIsEating();
        void _SetIsEating(bool val);
    }
}