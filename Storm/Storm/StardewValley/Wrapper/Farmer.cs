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

using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Storm.StardewValley.Accessor;
using Storm.Collections;

namespace Storm.StardewValley.Wrapper
{
    public class Farmer : Character
    {
        public Farmer(StaticContext parent, FarmerAccessor accessor) :
            base(parent, accessor)
        {
        }

        public Farmer()
        {
        }

        public WrappedProxyList<ItemAccessor, Item> Items
        {
            get
            {
                var tmp = Cast<FarmerAccessor>()._GetItems();
                if (tmp == null) return null;
                return new WrappedProxyList<ItemAccessor, Item>(tmp, i => i == null ? null : new Item(Parent, i));
            }
        }

        public ProxyDictionary<string, int[]> Friendships
        {
            get
            {
                var tmp = Cast<FarmerAccessor>()._GetFriendships();
                if (tmp == null) return null;
                return new ProxyDictionary<string, int[]>(tmp);
            }
        }
        
        public ProxyList<string> GetMailReceived
        {
            get
            {
                var tmp = Cast<FarmerAccessor>()._GetMailReceived();
                if (tmp == null) return null;
                return new ProxyList<string>(tmp);
            }        
        }

        public ProxyList<string> GetMailForTomorrow
        {
            get
            {
                var tmp = Cast<FarmerAccessor>()._GetMailForTomorrow();
                if (tmp == null) return null;
                return new ProxyList<string>(tmp);
            }
        }

        public int TileSlideThreshold
        {
            get { return Cast<FarmerAccessor>()._GetTileSlideThreshold(); }
            set { Cast<FarmerAccessor>()._SetTileSlideThreshold(value); }
        }

        public int ExperiencePoints
        {
            get { return Cast<FarmerAccessor>()._GetExperiencePoints(); }
            set { Cast<FarmerAccessor>()._SetExperiencePoints(value); }
        }

        public Item ActiveObject
        {
            get { return new Item(Parent, Cast<FarmerAccessor>()._GetActiveObject()); }
            set { Cast<FarmerAccessor>()._SetActiveObject(value?.Cast<ItemAccessor>()); }
        }

        public ProxyList<int> MovementDirections
        {
            get
            {
                var tmp = Cast<FarmerAccessor>()._GetMovementDirections();
                if (tmp == null) return null;
                return new ProxyList<int>(tmp);
            }
        }

        public Tool[] ToolBox
        {
            get
            {
                var arr = Cast<FarmerAccessor>()._GetToolBox();
                return Array.ConvertAll(arr, i => new Tool(Parent, i));
            }
            set { Cast<FarmerAccessor>()._SetToolBox(Array.ConvertAll(value, i => i.Cast<ToolAccessor>())); }
        }

        public ObjectItem Cupboard
        {
            get
            {
                var tmp = Cast<FarmerAccessor>()._GetCupboard();
                if (tmp == null) return null;
                return new ObjectItem(Parent, tmp);
            }
            set
            {
                Cast<FarmerAccessor>()._SetCupboard(value?.Cast<ObjectAccessor>());
            }
        }

        public string FarmName
        {
            get { return Cast<FarmerAccessor>()._GetFarmName(); }
            set { Cast<FarmerAccessor>()._SetFarmName(value); }
        }

        public string FavoriteThing
        {
            get { return Cast<FarmerAccessor>()._GetFavoriteThing(); }
            set { Cast<FarmerAccessor>()._SetFavoriteThing(value); }
        }

        public GameLocation CurrentLocation
        {
            get
            {
                var tmp = Cast<FarmerAccessor>()._GetCurrentLocation();
                if (tmp == null) return null;
                return new GameLocation(Parent, tmp);
            }
            set { Cast<FarmerAccessor>()._SetCurrentLocation(value?.Cast<GameLocationAccessor>()); }
        }

        public long UniqueMultiplayerID
        {
            get { return Cast<FarmerAccessor>()._GetUniqueMultiplayerID(); }
            set { Cast<FarmerAccessor>()._SetUniqueMultiplayerID(value); }
        }

        public string TmpLocationName
        {
            get { return Cast<FarmerAccessor>()._GetTmpLocationName(); }
            set { Cast<FarmerAccessor>()._SetTmpLocationName(value); }
        }

        public string PreviousLocationName
        {
            get { return Cast<FarmerAccessor>()._GetPreviousLocationName(); }
            set { Cast<FarmerAccessor>()._SetPreviousLocationName(value); }
        }

        public bool CatPerson
        {
            get { return Cast<FarmerAccessor>()._GetCatPerson(); }
            set { Cast<FarmerAccessor>()._SetCatPerson(value); }
        }

        public Item MostRecentlyGrabbedItem
        {
            get
            {
                var tmp = Cast<FarmerAccessor>()._GetMostRecentlyGrabbedItem();
                if (tmp == null) return null;
                return new Item(Parent, tmp);
            }
            set { Cast<FarmerAccessor>()._SetMostRecentlyGrabbedItem(value?.Cast<ItemAccessor>()); }
        }

        public Item ItemToEat
        {
            get
            {
                var tmp = Cast<FarmerAccessor>()._GetItemToEat();
                if (tmp == null) return null;
                return new Item(Parent, tmp);
            }
            set { Cast<FarmerAccessor>()._SetItemToEat(value?.Cast<ItemAccessor>()); }
        }

        public int ToolPower
        {
            get { return Cast<FarmerAccessor>()._GetToolPower(); }
            set { Cast<FarmerAccessor>()._SetToolPower(value); }
        }

        public int ToolHold
        {
            get { return Cast<FarmerAccessor>()._GetToolHold(); }
            set { Cast<FarmerAccessor>()._SetToolHold(value); }
        }

        public Vector2 MostRecentBed
        {
            get { return Cast<FarmerAccessor>()._GetMostRecentBed(); }
            set { Cast<FarmerAccessor>()._SetMostRecentBed(value); }
        }

        public int Shirt
        {
            get { return Cast<FarmerAccessor>()._GetShirt(); }
            set { Cast<FarmerAccessor>()._SetShirt(value); }
        }

        public int Hair
        {
            get { return Cast<FarmerAccessor>()._GetHair(); }
            set { Cast<FarmerAccessor>()._SetHair(value); }
        }

        public int Skin
        {
            get { return Cast<FarmerAccessor>()._GetSkin(); }
            set { Cast<FarmerAccessor>()._SetSkin(value); }
        }

        public int Accessory
        {
            get { return Cast<FarmerAccessor>()._GetAccessory(); }
            set { Cast<FarmerAccessor>()._SetAccessory(value); }
        }

        public int FacialHair
        {
            get { return Cast<FarmerAccessor>()._GetFacialHair(); }
            set { Cast<FarmerAccessor>()._SetFacialHair(value); }
        }

        public int CurrentEyes
        {
            get { return Cast<FarmerAccessor>()._GetCurrentEyes(); }
            set { Cast<FarmerAccessor>()._SetCurrentEyes(value); }
        }

        public int BlinkTimer
        {
            get { return Cast<FarmerAccessor>()._GetBlinkTimer(); }
            set { Cast<FarmerAccessor>()._SetBlinkTimer(value); }
        }

        public int FestivalScore
        {
            get { return Cast<FarmerAccessor>()._GetFestivalScore(); }
            set { Cast<FarmerAccessor>()._SetFestivalScore(value); }
        }

        public float TemporarySpeedBuff
        {
            get { return Cast<FarmerAccessor>()._GetTemporarySpeedBuff(); }
            set { Cast<FarmerAccessor>()._SetTemporarySpeedBuff(value); }
        }

        public Color HairstyleColor
        {
            get { return Cast<FarmerAccessor>()._GetHairstyleColor(); }
            set { Cast<FarmerAccessor>()._SetHairstyleColor(value); }
        }

        public Color PantsColor
        {
            get { return Cast<FarmerAccessor>()._GetPantsColor(); }
            set { Cast<FarmerAccessor>()._SetPantsColor(value); }
        }

        public Color NewEyeColor
        {
            get { return Cast<FarmerAccessor>()._GetNewEyeColor(); }
            set { Cast<FarmerAccessor>()._SetNewEyeColor(value); }
        }

        public NPC DancePartner
        {
            get
            {
                var tmp = Cast<FarmerAccessor>()._GetDancePartner();
                if (tmp == null) return null;
                return new NPC(Parent, tmp);
            }
            set { Cast<FarmerAccessor>()._SetDancePartner(value?.Cast<NPCAccessor>()); }
        }

        public bool RidingMineElevator
        {
            get { return Cast<FarmerAccessor>()._GetRidingMineElevator(); }
            set { Cast<FarmerAccessor>()._SetRidingMineElevator(value); }
        }

        public bool MineMovementDirectionWasUp
        {
            get { return Cast<FarmerAccessor>()._GetMineMovementDirectionWasUp(); }
            set { Cast<FarmerAccessor>()._SetMineMovementDirectionWasUp(value); }
        }

        public bool CameFromDungeon
        {
            get { return Cast<FarmerAccessor>()._GetCameFromDungeon(); }
            set { Cast<FarmerAccessor>()._SetCameFromDungeon(value); }
        }

        public bool ReadyConfirmation
        {
            get { return Cast<FarmerAccessor>()._GetReadyConfirmation(); }
            set { Cast<FarmerAccessor>()._SetReadyConfirmation(value); }
        }

        public bool Exhausted
        {
            get { return Cast<FarmerAccessor>()._GetExhausted(); }
            set { Cast<FarmerAccessor>()._SetExhausted(value); }
        }

        public int DeepestMineLevel
        {
            get { return Cast<FarmerAccessor>()._GetDeepestMineLevel(); }
            set { Cast<FarmerAccessor>()._SetDeepestMineLevel(value); }
        }

        public int CurrentToolIndex
        {
            get { return Cast<FarmerAccessor>()._GetCurrentToolIndex(); }
            set { Cast<FarmerAccessor>()._SetCurrentToolIndex(value); }
        }

        public int WoodPieces
        {
            get { return Cast<FarmerAccessor>()._GetWoodPieces(); }
            set { Cast<FarmerAccessor>()._SetWoodPieces(value); }
        }

        public int StonePieces
        {
            get { return Cast<FarmerAccessor>()._GetStonePieces(); }
            set { Cast<FarmerAccessor>()._SetStonePieces(value); }
        }

        public int CopperPieces
        {
            get { return Cast<FarmerAccessor>()._GetCopperPieces(); }
            set { Cast<FarmerAccessor>()._SetCopperPieces(value); }
        }

        public int IronPieces
        {
            get { return Cast<FarmerAccessor>()._GetIronPieces(); }
            set { Cast<FarmerAccessor>()._SetIronPieces(value); }
        }

        public int CoalPieces
        {
            get { return Cast<FarmerAccessor>()._GetCoalPieces(); }
            set { Cast<FarmerAccessor>()._SetCoalPieces(value); }
        }

        public int GoldPieces
        {
            get { return Cast<FarmerAccessor>()._GetGoldPieces(); }
            set { Cast<FarmerAccessor>()._SetGoldPieces(value); }
        }

        public int IridiumPieces
        {
            get { return Cast<FarmerAccessor>()._GetIridiumPieces(); }
            set { Cast<FarmerAccessor>()._SetIridiumPieces(value); }
        }

        public int QuartzPieces
        {
            get { return Cast<FarmerAccessor>()._GetQuartzPieces(); }
            set { Cast<FarmerAccessor>()._SetQuartzPieces(value); }
        }

        public int CaveChoice
        {
            get { return Cast<FarmerAccessor>()._GetCaveChoice(); }
            set { Cast<FarmerAccessor>()._SetCaveChoice(value); }
        }

        public int Feed
        {
            get { return Cast<FarmerAccessor>()._GetFeed(); }
            set { Cast<FarmerAccessor>()._SetFeed(value); }
        }

        public int FarmingLevel
        {
            get { return Cast<FarmerAccessor>()._GetFarmingLevel(); }
            set { Cast<FarmerAccessor>()._SetFarmingLevel(value); }
        }

        public int MiningLevel
        {
            get { return Cast<FarmerAccessor>()._GetMiningLevel(); }
            set { Cast<FarmerAccessor>()._SetMiningLevel(value); }
        }

        public int CombatLevel
        {
            get { return Cast<FarmerAccessor>()._GetCombatLevel(); }
            set { Cast<FarmerAccessor>()._SetCombatLevel(value); }
        }

        public int ForagingLevel
        {
            get { return Cast<FarmerAccessor>()._GetForagingLevel(); }
            set { Cast<FarmerAccessor>()._SetForagingLevel(value); }
        }

        public int FishingLevel
        {
            get { return Cast<FarmerAccessor>()._GetFishingLevel(); }
            set { Cast<FarmerAccessor>()._SetFishingLevel(value); }
        }

        public int LuckLevel
        {
            get { return Cast<FarmerAccessor>()._GetLuckLevel(); }
            set { Cast<FarmerAccessor>()._SetLuckLevel(value); }
        }

        public int NewSkillPointsToSpend
        {
            get { return Cast<FarmerAccessor>()._GetNewSkillPointsToSpend(); }
            set { Cast<FarmerAccessor>()._SetNewSkillPointsToSpend(value); }
        }

        public int AddedFarmingLevel
        {
            get { return Cast<FarmerAccessor>()._GetAddedFarmingLevel(); }
            set { Cast<FarmerAccessor>()._SetAddedFarmingLevel(value); }
        }

        public int AddedMiningLevel
        {
            get { return Cast<FarmerAccessor>()._GetAddedMiningLevel(); }
            set { Cast<FarmerAccessor>()._SetAddedMiningLevel(value); }
        }

        public int AddedCombatLevel
        {
            get { return Cast<FarmerAccessor>()._GetAddedCombatLevel(); }
            set { Cast<FarmerAccessor>()._SetAddedCombatLevel(value); }
        }

        public int AddedForagingLevel
        {
            get { return Cast<FarmerAccessor>()._GetAddedForagingLevel(); }
            set { Cast<FarmerAccessor>()._SetAddedForagingLevel(value); }
        }

        public int AddedFishingLevel
        {
            get { return Cast<FarmerAccessor>()._GetAddedFishingLevel(); }
            set { Cast<FarmerAccessor>()._SetAddedFishingLevel(value); }
        }

        public int AddedLuckLevel
        {
            get { return Cast<FarmerAccessor>()._GetAddedLuckLevel(); }
            set { Cast<FarmerAccessor>()._SetAddedLuckLevel(value); }
        }

        public int MaxStamina
        {
            get { return Cast<FarmerAccessor>()._GetMaxStamina(); }
            set { Cast<FarmerAccessor>()._SetMaxStamina(value); }
        }

        public int MaxItems
        {
            get { return Cast<FarmerAccessor>()._GetMaxItems(); }
            set { Cast<FarmerAccessor>()._SetMaxItems(value); }
        }

        public float Stamina
        {
            get { return Cast<FarmerAccessor>()._GetStamina(); }
            set { Cast<FarmerAccessor>()._SetStamina(value); }
        }

        public int Resilience
        {
            get { return Cast<FarmerAccessor>()._GetResilience(); }
            set { Cast<FarmerAccessor>()._SetResilience(value); }
        }

        public int Attack
        {
            get { return Cast<FarmerAccessor>()._GetAttack(); }
            set { Cast<FarmerAccessor>()._SetAttack(value); }
        }

        public int Immunity
        {
            get { return Cast<FarmerAccessor>()._GetImmunity(); }
            set { Cast<FarmerAccessor>()._SetImmunity(value); }
        }

        public float AttackIncreaseModifier
        {
            get { return Cast<FarmerAccessor>()._GetAttackIncreaseModifier(); }
            set { Cast<FarmerAccessor>()._SetAttackIncreaseModifier(value); }
        }

        public float KnockbackModifier
        {
            get { return Cast<FarmerAccessor>()._GetKnockbackModifier(); }
            set { Cast<FarmerAccessor>()._SetKnockbackModifier(value); }
        }

        public float WeaponSpeedModifier
        {
            get { return Cast<FarmerAccessor>()._GetWeaponSpeedModifier(); }
            set { Cast<FarmerAccessor>()._SetWeaponSpeedModifier(value); }
        }

        public float CritChanceModifier
        {
            get { return Cast<FarmerAccessor>()._GetCritChanceModifier(); }
            set { Cast<FarmerAccessor>()._SetCritChanceModifier(value); }
        }

        public float CritPowerModifier
        {
            get { return Cast<FarmerAccessor>()._GetCritPowerModifier(); }
            set { Cast<FarmerAccessor>()._SetCritPowerModifier(value); }
        }

        public float WeaponPrecisionModifier
        {
            get { return Cast<FarmerAccessor>()._GetWeaponPrecisionModifier(); }
            set { Cast<FarmerAccessor>()._SetWeaponPrecisionModifier(value); }
        }

        public int Money
        {
            get { return Cast<FarmerAccessor>()._GetMoney(); }
            set { Cast<FarmerAccessor>()._SetMoney(value); }
        }

        public int ClubCoins
        {
            get { return Cast<FarmerAccessor>()._GetClubCoins(); }
            set { Cast<FarmerAccessor>()._SetClubCoins(value); }
        }

        public uint TotalMoneyEarned
        {
            get { return Cast<FarmerAccessor>()._GetTotalMoneyEarned(); }
            set { Cast<FarmerAccessor>()._SetTotalMoneyEarned(value); }
        }

        public uint MillisecondsPlayed
        {
            get { return Cast<FarmerAccessor>()._GetMillisecondsPlayed(); }
            set { Cast<FarmerAccessor>()._SetMillisecondsPlayed(value); }
        }

        public Tool ToolBeingUpgraded
        {
            get
            {
                var tmp = Cast<FarmerAccessor>()._GetToolBeingUpgraded();
                if (tmp == null) return null;
                return new Tool(Parent, tmp);
            }
            set { Cast<FarmerAccessor>()._SetToolBeingUpgraded(value?.Cast<ToolAccessor>()); }
        }

        public int DaysLeftForToolUpgrade
        {
            get { return Cast<FarmerAccessor>()._GetDaysLeftForToolUpgrade(); }
            set { Cast<FarmerAccessor>()._SetDaysLeftForToolUpgrade(value); }
        }

        public float TimeOfLastPositionPacket
        {
            get { return Cast<FarmerAccessor>()._GetTimeOfLastPositionPacket(); }
            set { Cast<FarmerAccessor>()._SetTimeOfLastPositionPacket(value); }
        }

        public int NumUpdatesSinceLastDraw
        {
            get { return Cast<FarmerAccessor>()._GetNumUpdatesSinceLastDraw(); }
            set { Cast<FarmerAccessor>()._SetNumUpdatesSinceLastDraw(value); }
        }

        public int HouseUpgradeLevel
        {
            get { return Cast<FarmerAccessor>()._GetHouseUpgradeLevel(); }
            set { Cast<FarmerAccessor>()._SetHouseUpgradeLevel(value); }
        }

        public int DaysUntilHouseUpgrade
        {
            get { return Cast<FarmerAccessor>()._GetDaysUntilHouseUpgrade(); }
            set { Cast<FarmerAccessor>()._SetDaysUntilHouseUpgrade(value); }
        }

        public int CoopUpgradeLevel
        {
            get { return Cast<FarmerAccessor>()._GetCoopUpgradeLevel(); }
            set { Cast<FarmerAccessor>()._SetCoopUpgradeLevel(value); }
        }

        public int BarnUpgradeLevel
        {
            get { return Cast<FarmerAccessor>()._GetBarnUpgradeLevel(); }
            set { Cast<FarmerAccessor>()._SetBarnUpgradeLevel(value); }
        }

        public bool HasGreenhouse
        {
            get { return Cast<FarmerAccessor>()._GetHasGreenhouse(); }
            set { Cast<FarmerAccessor>()._SetHasGreenhouse(value); }
        }

        public bool HasRustyKey
        {
            get { return Cast<FarmerAccessor>()._GetHasRustyKey(); }
            set { Cast<FarmerAccessor>()._SetHasRustyKey(value); }
        }

        public bool HasSkullKey
        {
            get { return Cast<FarmerAccessor>()._GetHasSkullKey(); }
            set { Cast<FarmerAccessor>()._SetHasSkullKey(value); }
        }

        public bool HasUnlockedSkullDoor
        {
            get { return Cast<FarmerAccessor>()._GetHasUnlockedSkullDoor(); }
            set { Cast<FarmerAccessor>()._SetHasUnlockedSkullDoor(value); }
        }

        public int MagneticRadius
        {
            get { return Cast<FarmerAccessor>()._GetMagneticRadius(); }
            set { Cast<FarmerAccessor>()._SetMagneticRadius(value); }
        }

        public int TemporaryInvincibilityTimer
        {
            get { return Cast<FarmerAccessor>()._GetTemporaryInvincibilityTimer(); }
            set { Cast<FarmerAccessor>()._SetTemporaryInvincibilityTimer(value); }
        }

        public float Rotation
        {
            get { return Cast<FarmerAccessor>()._GetRotation(); }
            set { Cast<FarmerAccessor>()._SetRotation(value); }
        }

        public int CraftingTime
        {
            get { return Cast<FarmerAccessor>()._GetCraftingTime(); }
            set { Cast<FarmerAccessor>()._SetCraftingTime(value); }
        }

        public int RaftPuddleCounter
        {
            get { return Cast<FarmerAccessor>()._GetRaftPuddleCounter(); }
            set { Cast<FarmerAccessor>()._SetRaftPuddleCounter(value); }
        }

        public int RaftBobCounter
        {
            get { return Cast<FarmerAccessor>()._GetRaftBobCounter(); }
            set { Cast<FarmerAccessor>()._SetRaftBobCounter(value); }
        }

        public int Health
        {
            get { return Cast<FarmerAccessor>()._GetHealth(); }
            set { Cast<FarmerAccessor>()._SetHealth(value); }
        }

        public int MaxHealth
        {
            get { return Cast<FarmerAccessor>()._GetMaxHealth(); }
            set { Cast<FarmerAccessor>()._SetMaxHealth(value); }
        }

        public int TimesReachedMineBottom
        {
            get { return Cast<FarmerAccessor>()._GetTimesReachedMineBottom(); }
            set { Cast<FarmerAccessor>()._SetTimesReachedMineBottom(value); }
        }

        public Vector2 Jitter
        {
            get { return Cast<FarmerAccessor>()._GetJitter(); }
            set { Cast<FarmerAccessor>()._SetJitter(value); }
        }

        public Vector2 LastPosition
        {
            get { return Cast<FarmerAccessor>()._GetLastPosition(); }
            set { Cast<FarmerAccessor>()._SetLastPosition(value); }
        }

        public Vector2 LastGrabTile
        {
            get { return Cast<FarmerAccessor>()._GetLastGrabTile(); }
            set { Cast<FarmerAccessor>()._SetLastGrabTile(value); }
        }

        public float JitterStrength
        {
            get { return Cast<FarmerAccessor>()._GetJitterStrength(); }
            set { Cast<FarmerAccessor>()._SetJitterStrength(value); }
        }

        public float XOffset
        {
            get { return Cast<FarmerAccessor>()._GetXOffset(); }
            set { Cast<FarmerAccessor>()._SetXOffset(value); }
        }

        public bool IsMale
        {
            get { return Cast<FarmerAccessor>()._GetIsMale(); }
            set { Cast<FarmerAccessor>()._SetIsMale(value); }
        }

        public bool CanMove
        {
            get { return Cast<FarmerAccessor>()._GetCanMove(); }
            set { Cast<FarmerAccessor>()._SetCanMove(value); }
        }

        public bool Running
        {
            get { return Cast<FarmerAccessor>()._GetRunning(); }
            set { Cast<FarmerAccessor>()._SetRunning(value); }
        }

        public bool UsingTool
        {
            get { return Cast<FarmerAccessor>()._GetUsingTool(); }
            set { Cast<FarmerAccessor>()._SetUsingTool(value); }
        }

        public bool ForceTimePass
        {
            get { return Cast<FarmerAccessor>()._GetForceTimePass(); }
            set { Cast<FarmerAccessor>()._SetForceTimePass(value); }
        }

        public bool IsRafting
        {
            get { return Cast<FarmerAccessor>()._GetIsRafting(); }
            set { Cast<FarmerAccessor>()._SetIsRafting(value); }
        }

        public bool UsingSlingshot
        {
            get { return Cast<FarmerAccessor>()._GetUsingSlingshot(); }
            set { Cast<FarmerAccessor>()._SetUsingSlingshot(value); }
        }

        public bool BathingClothes
        {
            get { return Cast<FarmerAccessor>()._GetBathingClothes(); }
            set { Cast<FarmerAccessor>()._SetBathingClothes(value); }
        }

        public bool CanOnlyWalk
        {
            get { return Cast<FarmerAccessor>()._GetCanOnlyWalk(); }
            set { Cast<FarmerAccessor>()._SetCanOnlyWalk(value); }
        }

        public bool TemporarilyInvincible
        {
            get { return Cast<FarmerAccessor>()._GetTemporarilyInvincible(); }
            set { Cast<FarmerAccessor>()._SetTemporarilyInvincible(value); }
        }

        public bool HasBusTicket
        {
            get { return Cast<FarmerAccessor>()._GetHasBusTicket(); }
            set { Cast<FarmerAccessor>()._SetHasBusTicket(value); }
        }

        public bool StardewHero
        {
            get { return Cast<FarmerAccessor>()._GetStardewHero(); }
            set { Cast<FarmerAccessor>()._SetStardewHero(value); }
        }

        public bool HasClubCard
        {
            get { return Cast<FarmerAccessor>()._GetHasClubCard(); }
            set { Cast<FarmerAccessor>()._SetHasClubCard(value); }
        }

        public bool HasSpecialCharm
        {
            get { return Cast<FarmerAccessor>()._GetHasSpecialCharm(); }
            set { Cast<FarmerAccessor>()._SetHasSpecialCharm(value); }
        }

        public bool CanReleaseTool
        {
            get { return Cast<FarmerAccessor>()._GetCanReleaseTool(); }
            set { Cast<FarmerAccessor>()._SetCanReleaseTool(value); }
        }

        public bool IsCrafting
        {
            get { return Cast<FarmerAccessor>()._GetIsCrafting(); }
            set { Cast<FarmerAccessor>()._SetIsCrafting(value); }
        }

        public Rectangle TemporaryImpassableTile
        {
            get { return Cast<FarmerAccessor>()._GetTemporaryImpassableTile(); }
            set { Cast<FarmerAccessor>()._SetTemporaryImpassableTile(value); }
        }

        public bool CanUnderstandDwarves
        {
            get { return Cast<FarmerAccessor>()._GetCanUnderstandDwarves(); }
            set { Cast<FarmerAccessor>()._SetCanUnderstandDwarves(value); }
        }

        public Vector2 PositionBeforeEvent
        {
            get { return Cast<FarmerAccessor>()._GetPositionBeforeEvent(); }
            set { Cast<FarmerAccessor>()._SetPositionBeforeEvent(value); }
        }

        public Vector2 RemotePosition
        {
            get { return Cast<FarmerAccessor>()._GetRemotePosition(); }
            set { Cast<FarmerAccessor>()._SetRemotePosition(value); }
        }

        public int OrientationBeforeEvent
        {
            get { return Cast<FarmerAccessor>()._GetOrientationBeforeEvent(); }
            set { Cast<FarmerAccessor>()._SetOrientationBeforeEvent(value); }
        }

        public int SwimTimer
        {
            get { return Cast<FarmerAccessor>()._GetSwimTimer(); }
            set { Cast<FarmerAccessor>()._SetSwimTimer(value); }
        }

        public int TimerSinceLastMovement
        {
            get { return Cast<FarmerAccessor>()._GetTimerSinceLastMovement(); }
            set { Cast<FarmerAccessor>()._SetTimerSinceLastMovement(value); }
        }

        public int NoMovementPause
        {
            get { return Cast<FarmerAccessor>()._GetNoMovementPause(); }
            set { Cast<FarmerAccessor>()._SetNoMovementPause(value); }
        }

        public int FreezePause
        {
            get { return Cast<FarmerAccessor>()._GetFreezePause(); }
            set { Cast<FarmerAccessor>()._SetFreezePause(value); }
        }

        public float YOffset
        {
            get { return Cast<FarmerAccessor>()._GetYOffset(); }
            set { Cast<FarmerAccessor>()._SetYOffset(value); }
        }

        public string Spouse
        {
            get { return Cast<FarmerAccessor>()._GetSpouse(); }
            set { Cast<FarmerAccessor>()._SetSpouse(value); }
        }

        public string DateStringForSaveGame
        {
            get { return Cast<FarmerAccessor>()._GetDateStringForSaveGame(); }
            set { Cast<FarmerAccessor>()._SetDateStringForSaveGame(value); }
        }

        public int OverallsColor
        {
            get { return Cast<FarmerAccessor>()._GetOverallsColor(); }
            set { Cast<FarmerAccessor>()._SetOverallsColor(value); }
        }

        public int ShirtColor
        {
            get { return Cast<FarmerAccessor>()._GetShirtColor(); }
            set { Cast<FarmerAccessor>()._SetShirtColor(value); }
        }

        public int SkinColor
        {
            get { return Cast<FarmerAccessor>()._GetSkinColor(); }
            set { Cast<FarmerAccessor>()._SetSkinColor(value); }
        }

        public int HairColor
        {
            get { return Cast<FarmerAccessor>()._GetHairColor(); }
            set { Cast<FarmerAccessor>()._SetHairColor(value); }
        }

        public int EyeColor
        {
            get { return Cast<FarmerAccessor>()._GetEyeColor(); }
            set { Cast<FarmerAccessor>()._SetEyeColor(value); }
        }

        public Vector2 ArmOffset
        {
            get { return Cast<FarmerAccessor>()._GetArmOffset(); }
            set { Cast<FarmerAccessor>()._SetArmOffset(value); }
        }

        public string Bobber
        {
            get { return Cast<FarmerAccessor>()._GetBobber(); }
            set { Cast<FarmerAccessor>()._SetBobber(value); }
        }

        public ContentManager FarmerTextureManager
        {
            get { return Cast<FarmerAccessor>()._GetFarmerTextureManager(); }
            set { Cast<FarmerAccessor>()._SetFarmerTextureManager(value); }
        }

        public int SaveTime
        {
            get { return Cast<FarmerAccessor>()._GetSaveTime(); }
            set { Cast<FarmerAccessor>()._SetSaveTime(value); }
        }

        public int DaysMarried
        {
            get { return Cast<FarmerAccessor>()._GetDaysMarried(); }
            set { Cast<FarmerAccessor>()._SetDaysMarried(value); }
        }

        public int ToolPitchAccumulator
        {
            get { return Cast<FarmerAccessor>()._GetToolPitchAccumulator(); }
            set { Cast<FarmerAccessor>()._SetToolPitchAccumulator(value); }
        }

        public int CharacterCollisionTimer
        {
            get { return Cast<FarmerAccessor>()._GetCharactercollisionTimer(); }
            set { Cast<FarmerAccessor>()._SetCharactercollisionTimer(value); }
        }

        public NPC CollisionNPC
        {
            get
            {
                var tmp = Cast<FarmerAccessor>()._GetCollisionNPC();
                if (tmp == null) return null;
                return new NPC(Parent, tmp);
            }
            set { Cast<FarmerAccessor>()._SetCollisionNPC(value?.Cast<NPCAccessor>()); }
        }

        public float MovementMultiplier
        {
            get { return Cast<FarmerAccessor>()._GetMovementMultiplier(); }
            set { Cast<FarmerAccessor>()._SetMovementMultiplier(value); }
        }

        public int AddedSpeed
        {
            get { return Cast<FarmerAccessor>()._GetAddedSpeed(); }
            set { Cast<FarmerAccessor>()._SetAddedSpeed(value); }
        }

        public void SetToolInToolBox(int idx, Tool t)
        {
            Cast<FarmerAccessor>()._GetToolBox()[idx] = t?.Cast<ToolAccessor>();
        }

        public void SetItem(int idx, Item item)
        {
            var set = item == null ? null : item.Underlying;
            Cast<FarmerAccessor>()._GetItems()[idx] = set;
        }

        public ProxyDictionary<int, int[]> FishCaught
        {
            get
            {
                var tmp = Cast<FarmerAccessor>()._GetFishCaught();
                if (tmp == null) return null;
                return new ProxyDictionary<int, int[]>(tmp);
            }
        }
    }
}