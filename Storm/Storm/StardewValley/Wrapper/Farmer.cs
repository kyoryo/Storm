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

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Storm.StardewValley.Accessor;
using Storm.Collections;

namespace Storm.StardewValley.Wrapper
{
    public class Farmer : Character
    {
        private readonly FarmerAccessor accessor;

        public Farmer(StaticContext parent, FarmerAccessor accessor) : base(parent, accessor)
        {
            this.accessor = accessor;
        }

        public WrappedProxyList<ItemAccessor, Item> Items
        {
            get
            {
                return new WrappedProxyList<ItemAccessor, Item>(accessor._GetItems(), i => i == null ? null : new Item(Parent, i));
            }
        }

        public ProxyDictionary<string, int[]> Friendships
        {
            get { return new ProxyDictionary<string, int[]>(accessor._GetFriendships()); }
        }

        public int TileSlideThreshold
        {
            get { return accessor._GetTileSlideThreshold(); }
            set { accessor._SetTileSlideThreshold(value); }
        }

        public int ExperiencePoints
        {
            get { return accessor._GetExperiencePoints(); }
            set { accessor._SetExperiencePoints(value); }
        }

        public Item ActiveObject
        {
            get { return new Item(Parent, accessor._GetActiveObject()); }
            set { accessor._SetActiveObject(value.Cast<ItemAccessor>()); }
        }

        public ProxyList<int, int> MovementDirections
        {
            get { return new ProxyList<int, int>(accessor._GetMovementDirections()); }
        }

        public Tool[] ToolBox
        {
            get
            {
                var arr = accessor._GetToolBox();
                return Array.ConvertAll(arr, i => new Tool(Parent, i));
            }
            set { accessor._SetToolBox(Array.ConvertAll(value, i => i.Cast<ToolAccessor>())); }
        }

        public ObjectItem Cupboard
        {
            get { return new ObjectItem(Parent, accessor._GetCupboard()); }
            set { accessor._SetCupboard(value.Cast<ObjectAccessor>()); }
        }

        public string FarmName
        {
            get { return accessor._GetFarmName(); }
            set { accessor._SetFarmName(value); }
        }

        public string FavoriteThing
        {
            get { return accessor._GetFavoriteThing(); }
            set { accessor._SetFavoriteThing(value); }
        }

        public GameLocation CurrentLocation
        {
            get { return new GameLocation(Parent, accessor._GetCurrentLocation()); }
            set { accessor._SetCurrentLocation(value.Cast<GameLocationAccessor>()); }
        }

        public long UniqueMultiplayerID
        {
            get { return accessor._GetUniqueMultiplayerID(); }
            set { accessor._SetUniqueMultiplayerID(value); }
        }

        public string TmpLocationName
        {
            get { return accessor._GetTmpLocationName(); }
            set { accessor._SetTmpLocationName(value); }
        }

        public string PreviousLocationName
        {
            get { return accessor._GetPreviousLocationName(); }
            set { accessor._SetPreviousLocationName(value); }
        }

        public bool CatPerson
        {
            get { return accessor._GetCatPerson(); }
            set { accessor._SetCatPerson(value); }
        }

        public Item MostRecentlyGrabbedItem
        {
            get { return new Item(Parent, accessor._GetMostRecentlyGrabbedItem()); }
            set { accessor._SetMostRecentlyGrabbedItem(value.Cast<ItemAccessor>()); }
        }

        public Item ItemToEat
        {
            get { return new Item(Parent, accessor._GetItemToEat()); }
            set { accessor._SetItemToEat(value.Cast<ItemAccessor>()); }
        }

        public int ToolPower
        {
            get { return accessor._GetToolPower(); }
            set { accessor._SetToolPower(value); }
        }

        public int ToolHold
        {
            get { return accessor._GetToolHold(); }
            set { accessor._SetToolHold(value); }
        }

        public Vector2 MostRecentBed
        {
            get { return accessor._GetMostRecentBed(); }
            set { accessor._SetMostRecentBed(value); }
        }

        public int Shirt
        {
            get { return accessor._GetShirt(); }
            set { accessor._SetShirt(value); }
        }

        public int Hair
        {
            get { return accessor._GetHair(); }
            set { accessor._SetHair(value); }
        }

        public int Skin
        {
            get { return accessor._GetSkin(); }
            set { accessor._SetSkin(value); }
        }

        public int Accessory
        {
            get { return accessor._GetAccessory(); }
            set { accessor._SetAccessory(value); }
        }

        public int FacialHair
        {
            get { return accessor._GetFacialHair(); }
            set { accessor._SetFacialHair(value); }
        }

        public int CurrentEyes
        {
            get { return accessor._GetCurrentEyes(); }
            set { accessor._SetCurrentEyes(value); }
        }

        public int BlinkTimer
        {
            get { return accessor._GetBlinkTimer(); }
            set { accessor._SetBlinkTimer(value); }
        }

        public int FestivalScore
        {
            get { return accessor._GetFestivalScore(); }
            set { accessor._SetFestivalScore(value); }
        }

        public int TemporarySpeedBuff
        {
            get { return accessor._GetTemporarySpeedBuff(); }
            set { accessor._SetTemporarySpeedBuff(value); }
        }

        public Color HairstyleColor
        {
            get { return accessor._GetHairstyleColor(); }
            set { accessor._SetHairstyleColor(value); }
        }

        public Color PantsColor
        {
            get { return accessor._GetPantsColor(); }
            set { accessor._SetPantsColor(value); }
        }

        public Color NewEyeColor
        {
            get { return accessor._GetNewEyeColor(); }
            set { accessor._SetNewEyeColor(value); }
        }

        public NPC DancePartner
        {
            get { return new NPC(Parent, accessor._GetDancePartner()); }
            set { accessor._SetDancePartner(value.Cast<NPCAccessor>()); }
        }

        public bool RidingMineElevator
        {
            get { return accessor._GetRidingMineElevator(); }
            set { accessor._SetRidingMineElevator(value); }
        }

        public bool MineMovementDirectionWasUp
        {
            get { return accessor._GetMineMovementDirectionWasUp(); }
            set { accessor._SetMineMovementDirectionWasUp(value); }
        }

        public bool CameFromDungeon
        {
            get { return accessor._GetCameFromDungeon(); }
            set { accessor._SetCameFromDungeon(value); }
        }

        public bool ReadyConfirmation
        {
            get { return accessor._GetReadyConfirmation(); }
            set { accessor._SetReadyConfirmation(value); }
        }

        public bool Exhausted
        {
            get { return accessor._GetExhausted(); }
            set { accessor._SetExhausted(value); }
        }

        public int DeepestMineLevel
        {
            get { return accessor._GetDeepestMineLevel(); }
            set { accessor._SetDeepestMineLevel(value); }
        }

        public int CurrentToolIndex
        {
            get { return accessor._GetCurrentToolIndex(); }
            set { accessor._SetCurrentToolIndex(value); }
        }

        public int WoodPieces
        {
            get { return accessor._GetWoodPieces(); }
            set { accessor._SetWoodPieces(value); }
        }

        public int StonePieces
        {
            get { return accessor._GetStonePieces(); }
            set { accessor._SetStonePieces(value); }
        }

        public int CopperPieces
        {
            get { return accessor._GetCopperPieces(); }
            set { accessor._SetCopperPieces(value); }
        }

        public int IronPieces
        {
            get { return accessor._GetIronPieces(); }
            set { accessor._SetIronPieces(value); }
        }

        public int CoalPieces
        {
            get { return accessor._GetCoalPieces(); }
            set { accessor._SetCoalPieces(value); }
        }

        public int GoldPieces
        {
            get { return accessor._GetGoldPieces(); }
            set { accessor._SetGoldPieces(value); }
        }

        public int IridiumPieces
        {
            get { return accessor._GetIridiumPieces(); }
            set { accessor._SetIridiumPieces(value); }
        }

        public int QuartzPieces
        {
            get { return accessor._GetQuartzPieces(); }
            set { accessor._SetQuartzPieces(value); }
        }

        public int CaveChoice
        {
            get { return accessor._GetCaveChoice(); }
            set { accessor._SetCaveChoice(value); }
        }

        public int Feed
        {
            get { return accessor._GetFeed(); }
            set { accessor._SetFeed(value); }
        }

        public int FarmingLevel
        {
            get { return accessor._GetFarmingLevel(); }
            set { accessor._SetFarmingLevel(value); }
        }

        public int MiningLevel
        {
            get { return accessor._GetMiningLevel(); }
            set { accessor._SetMiningLevel(value); }
        }

        public int CombatLevel
        {
            get { return accessor._GetCombatLevel(); }
            set { accessor._SetCombatLevel(value); }
        }

        public int ForagingLevel
        {
            get { return accessor._GetForagingLevel(); }
            set { accessor._SetForagingLevel(value); }
        }

        public int FishingLevel
        {
            get { return accessor._GetFishingLevel(); }
            set { accessor._SetFishingLevel(value); }
        }

        public int LuckLevel
        {
            get { return accessor._GetLuckLevel(); }
            set { accessor._SetLuckLevel(value); }
        }

        public int NewSkillPointsToSpend
        {
            get { return accessor._GetNewSkillPointsToSpend(); }
            set { accessor._SetNewSkillPointsToSpend(value); }
        }

        public int AddedFarmingLevel
        {
            get { return accessor._GetAddedFarmingLevel(); }
            set { accessor._SetAddedFarmingLevel(value); }
        }

        public int AddedMiningLevel
        {
            get { return accessor._GetAddedMiningLevel(); }
            set { accessor._SetAddedMiningLevel(value); }
        }

        public int AddedCombatLevel
        {
            get { return accessor._GetAddedCombatLevel(); }
            set { accessor._SetAddedCombatLevel(value); }
        }

        public int AddedForagingLevel
        {
            get { return accessor._GetAddedForagingLevel(); }
            set { accessor._SetAddedForagingLevel(value); }
        }

        public int AddedFishingLevel
        {
            get { return accessor._GetAddedFishingLevel(); }
            set { accessor._SetAddedFishingLevel(value); }
        }

        public int AddedLuckLevel
        {
            get { return accessor._GetAddedLuckLevel(); }
            set { accessor._SetAddedLuckLevel(value); }
        }

        public int MaxStamina
        {
            get { return accessor._GetMaxStamina(); }
            set { accessor._SetMaxStamina(value); }
        }

        public int MaxItems
        {
            get { return accessor._GetMaxItems(); }
            set { accessor._SetMaxItems(value); }
        }

        public float Stamina
        {
            get { return accessor._GetStamina(); }
            set { accessor._SetStamina(value); }
        }

        public int Resilience
        {
            get { return accessor._GetResilience(); }
            set { accessor._SetResilience(value); }
        }

        public int Attack
        {
            get { return accessor._GetAttack(); }
            set { accessor._SetAttack(value); }
        }

        public int Immunity
        {
            get { return accessor._GetImmunity(); }
            set { accessor._SetImmunity(value); }
        }

        public float AttackIncreaseModifier
        {
            get { return accessor._GetAttackIncreaseModifier(); }
            set { accessor._SetAttackIncreaseModifier(value); }
        }

        public float KnockbackModifier
        {
            get { return accessor._GetKnockbackModifier(); }
            set { accessor._SetKnockbackModifier(value); }
        }

        public float WeaponSpeedModifier
        {
            get { return accessor._GetWeaponSpeedModifier(); }
            set { accessor._SetWeaponSpeedModifier(value); }
        }

        public float CritChanceModifier
        {
            get { return accessor._GetCritChanceModifier(); }
            set { accessor._SetCritChanceModifier(value); }
        }

        public float CritPowerModifier
        {
            get { return accessor._GetCritPowerModifier(); }
            set { accessor._SetCritPowerModifier(value); }
        }

        public float WeaponPrecisionModifier
        {
            get { return accessor._GetWeaponPrecisionModifier(); }
            set { accessor._SetWeaponPrecisionModifier(value); }
        }

        public int Money
        {
            get { return accessor._GetMoney(); }
            set { accessor._SetMoney(value); }
        }

        public int ClubCoins
        {
            get { return accessor._GetClubCoins(); }
            set { accessor._SetClubCoins(value); }
        }

        public uint TotalMoneyEarned
        {
            get { return accessor._GetTotalMoneyEarned(); }
            set { accessor._SetTotalMoneyEarned(value); }
        }

        public uint MillisecondsPlayed
        {
            get { return accessor._GetMillisecondsPlayed(); }
            set { accessor._SetMillisecondsPlayed(value); }
        }

        public Tool ToolBeingUpgraded
        {
            get { return new Tool(Parent, accessor._GetToolBeingUpgraded()); }
            set { accessor._SetToolBeingUpgraded(value.Cast<ToolAccessor>()); }
        }

        public int DaysLeftForToolUpgrade
        {
            get { return accessor._GetDaysLeftForToolUpgrade(); }
            set { accessor._SetDaysLeftForToolUpgrade(value); }
        }

        public float TimeOfLastPositionPacket
        {
            get { return accessor._GetTimeOfLastPositionPacket(); }
            set { accessor._SetTimeOfLastPositionPacket(value); }
        }

        public int NumUpdatesSinceLastDraw
        {
            get { return accessor._GetNumUpdatesSinceLastDraw(); }
            set { accessor._SetNumUpdatesSinceLastDraw(value); }
        }

        public int HouseUpgradeLevel
        {
            get { return accessor._GetHouseUpgradeLevel(); }
            set { accessor._SetHouseUpgradeLevel(value); }
        }

        public int DaysUntilHouseUpgrade
        {
            get { return accessor._GetDaysUntilHouseUpgrade(); }
            set { accessor._SetDaysUntilHouseUpgrade(value); }
        }

        public int CoopUpgradeLevel
        {
            get { return accessor._GetCoopUpgradeLevel(); }
            set { accessor._SetCoopUpgradeLevel(value); }
        }

        public int BarnUpgradeLevel
        {
            get { return accessor._GetBarnUpgradeLevel(); }
            set { accessor._SetBarnUpgradeLevel(value); }
        }

        public bool HasGreenhouse
        {
            get { return accessor._GetHasGreenhouse(); }
            set { accessor._SetHasGreenhouse(value); }
        }

        public bool HasRustyKey
        {
            get { return accessor._GetHasRustyKey(); }
            set { accessor._SetHasRustyKey(value); }
        }

        public bool HasSkullKey
        {
            get { return accessor._GetHasSkullKey(); }
            set { accessor._SetHasSkullKey(value); }
        }

        public bool HasUnlockedSkullDoor
        {
            get { return accessor._GetHasUnlockedSkullDoor(); }
            set { accessor._SetHasUnlockedSkullDoor(value); }
        }

        public int MagneticRadius
        {
            get { return accessor._GetMagneticRadius(); }
            set { accessor._SetMagneticRadius(value); }
        }

        public int TemporaryInvincibilityTimer
        {
            get { return accessor._GetTemporaryInvincibilityTimer(); }
            set { accessor._SetTemporaryInvincibilityTimer(value); }
        }

        public float Rotation
        {
            get { return accessor._GetRotation(); }
            set { accessor._SetRotation(value); }
        }

        public int CraftingTime
        {
            get { return accessor._GetCraftingTime(); }
            set { accessor._SetCraftingTime(value); }
        }

        public int RaftPuddleCounter
        {
            get { return accessor._GetRaftPuddleCounter(); }
            set { accessor._SetRaftPuddleCounter(value); }
        }

        public int RaftBobCounter
        {
            get { return accessor._GetRaftBobCounter(); }
            set { accessor._SetRaftBobCounter(value); }
        }

        public int Health
        {
            get { return accessor._GetHealth(); }
            set { accessor._SetHealth(value); }
        }

        public int MaxHealth
        {
            get { return accessor._GetMaxHealth(); }
            set { accessor._SetMaxHealth(value); }
        }

        public int TimesReachedMineBottom
        {
            get { return accessor._GetTimesReachedMineBottom(); }
            set { accessor._SetTimesReachedMineBottom(value); }
        }

        public Vector2 Jitter
        {
            get { return accessor._GetJitter(); }
            set { accessor._SetJitter(value); }
        }

        public Vector2 LastPosition
        {
            get { return accessor._GetLastPosition(); }
            set { accessor._SetLastPosition(value); }
        }

        public Vector2 LastGrabTile
        {
            get { return accessor._GetLastGrabTile(); }
            set { accessor._SetLastGrabTile(value); }
        }

        public float JitterStrength
        {
            get { return accessor._GetJitterStrength(); }
            set { accessor._SetJitterStrength(value); }
        }

        public float XOffset
        {
            get { return accessor._GetXOffset(); }
            set { accessor._SetXOffset(value); }
        }

        public bool IsMale
        {
            get { return accessor._GetIsMale(); }
            set { accessor._SetIsMale(value); }
        }

        public bool CanMove
        {
            get { return accessor._GetCanMove(); }
            set { accessor._SetCanMove(value); }
        }

        public bool Running
        {
            get { return accessor._GetRunning(); }
            set { accessor._SetRunning(value); }
        }

        public bool UsingTool
        {
            get { return accessor._GetUsingTool(); }
            set { accessor._SetUsingTool(value); }
        }

        public bool ForceTimePass
        {
            get { return accessor._GetForceTimePass(); }
            set { accessor._SetForceTimePass(value); }
        }

        public bool IsRafting
        {
            get { return accessor._GetIsRafting(); }
            set { accessor._SetIsRafting(value); }
        }

        public bool UsingSlingshot
        {
            get { return accessor._GetUsingSlingshot(); }
            set { accessor._SetUsingSlingshot(value); }
        }

        public bool BathingClothes
        {
            get { return accessor._GetBathingClothes(); }
            set { accessor._SetBathingClothes(value); }
        }

        public bool CanOnlyWalk
        {
            get { return accessor._GetCanOnlyWalk(); }
            set { accessor._SetCanOnlyWalk(value); }
        }

        public bool TemporarilyInvincible
        {
            get { return accessor._GetTemporarilyInvincible(); }
            set { accessor._SetTemporarilyInvincible(value); }
        }

        public bool HasBusTicket
        {
            get { return accessor._GetHasBusTicket(); }
            set { accessor._SetHasBusTicket(value); }
        }

        public bool StardewHero
        {
            get { return accessor._GetStardewHero(); }
            set { accessor._SetStardewHero(value); }
        }

        public bool HasClubCard
        {
            get { return accessor._GetHasClubCard(); }
            set { accessor._SetHasClubCard(value); }
        }

        public bool HasSpecialCharm
        {
            get { return accessor._GetHasSpecialCharm(); }
            set { accessor._SetHasSpecialCharm(value); }
        }

        public bool CanReleaseTool
        {
            get { return accessor._GetCanReleaseTool(); }
            set { accessor._SetCanReleaseTool(value); }
        }

        public bool IsCrafting
        {
            get { return accessor._GetIsCrafting(); }
            set { accessor._SetIsCrafting(value); }
        }

        public Rectangle TemporaryImpassableTile
        {
            get { return accessor._GetTemporaryImpassableTile(); }
            set { accessor._SetTemporaryImpassableTile(value); }
        }

        public bool CanUnderstandDwarves
        {
            get { return accessor._GetCanUnderstandDwarves(); }
            set { accessor._SetCanUnderstandDwarves(value); }
        }

        public Vector2 PositionBeforeEvent
        {
            get { return accessor._GetPositionBeforeEvent(); }
            set { accessor._SetPositionBeforeEvent(value); }
        }

        public Vector2 RemotePosition
        {
            get { return accessor._GetRemotePosition(); }
            set { accessor._SetRemotePosition(value); }
        }

        public int OrientationBeforeEvent
        {
            get { return accessor._GetOrientationBeforeEvent(); }
            set { accessor._SetOrientationBeforeEvent(value); }
        }

        public int SwimTimer
        {
            get { return accessor._GetSwimTimer(); }
            set { accessor._SetSwimTimer(value); }
        }

        public int TimerSinceLastMovement
        {
            get { return accessor._GetTimerSinceLastMovement(); }
            set { accessor._SetTimerSinceLastMovement(value); }
        }

        public int NoMovementPause
        {
            get { return accessor._GetNoMovementPause(); }
            set { accessor._SetNoMovementPause(value); }
        }

        public int FreezePause
        {
            get { return accessor._GetFreezePause(); }
            set { accessor._SetFreezePause(value); }
        }

        public float YOffset
        {
            get { return accessor._GetYOffset(); }
            set { accessor._SetYOffset(value); }
        }

        public string Spouse
        {
            get { return accessor._GetSpouse(); }
            set { accessor._SetSpouse(value); }
        }

        public string DateStringForSaveGame
        {
            get { return accessor._GetDateStringForSaveGame(); }
            set { accessor._SetDateStringForSaveGame(value); }
        }

        public int OverallsColor
        {
            get { return accessor._GetOverallsColor(); }
            set { accessor._SetOverallsColor(value); }
        }

        public int ShirtColor
        {
            get { return accessor._GetShirtColor(); }
            set { accessor._SetShirtColor(value); }
        }

        public int SkinColor
        {
            get { return accessor._GetSkinColor(); }
            set { accessor._SetSkinColor(value); }
        }

        public int HairColor
        {
            get { return accessor._GetHairColor(); }
            set { accessor._SetHairColor(value); }
        }

        public int EyeColor
        {
            get { return accessor._GetEyeColor(); }
            set { accessor._SetEyeColor(value); }
        }

        public Vector2 ArmOffset
        {
            get { return accessor._GetArmOffset(); }
            set { accessor._SetArmOffset(value); }
        }

        public string Bobber
        {
            get { return accessor._GetBobber(); }
            set { accessor._SetBobber(value); }
        }

        public ContentManager FarmerTextureManager
        {
            get { return accessor._GetFarmerTextureManager(); }
            set { accessor._SetFarmerTextureManager(value); }
        }

        public int SaveTime
        {
            get { return accessor._GetSaveTime(); }
            set { accessor._SetSaveTime(value); }
        }

        public int DaysMarried
        {
            get { return accessor._GetDaysMarried(); }
            set { accessor._SetDaysMarried(value); }
        }

        public int ToolPitchAccumulator
        {
            get { return accessor._GetToolPitchAccumulator(); }
            set { accessor._SetToolPitchAccumulator(value); }
        }

        public int CharactercollisionTimer
        {
            get { return accessor._GetCharactercollisionTimer(); }
            set { accessor._SetCharactercollisionTimer(value); }
        }

        public NPC CollisionNPC
        {
            get { return new NPC(Parent, accessor._GetCollisionNPC()); }
            set { accessor._SetCollisionNPC(value.Cast<NPCAccessor>()); }
        }

        public float MovementMultiplier
        {
            get { return accessor._GetMovementMultiplier(); }
            set { accessor._SetMovementMultiplier(value); }
        }

        public int AddedSpeed
        {
            get { return accessor._GetAddedSpeed(); }
            set { accessor._SetAddedSpeed(value); }
        }

        public new FarmerAccessor Expose() => accessor;

        public void AddMovementDirection(int direction)
        {
            accessor._GetMovementDirections().Add(direction);
        }

        public void ClearMovementDirections()
        {
            accessor._GetMovementDirections().Clear();
        }

        public void SetToolInToolBox(int idx, Tool t)
        {
            accessor._GetToolBox()[idx] = t.Cast<ToolAccessor>();
        }

        public void SetItem(int idx, Item item)
        {
            accessor._GetItems()[idx] = item.Expose();
        }
    }
}