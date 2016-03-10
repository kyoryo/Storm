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

using System.Collections;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace Storm.StardewValley.Accessor
{
    public interface FarmerAccessor : CharacterAccessor
    {
        int _GetTileSlideThreshold();
        void _SetTileSlideThreshold(int val);

        IList _GetQuestLog();
        void _SetQuestLog(IList val);

        IList _GetProfessions();
        void _SetProfessions(IList val);

        IList _GetNewLevels();
        void _SetNewLevels(IList val);

        ICollection _GetNewLevelSparklingTexts();
        void _SetNewLevelSparklingTexts(ICollection val);

        int _GetExperiencePoints();
        void _SetExperiencePoints(int val);

        ItemAccessor _GetActiveObject();
        void _SetActiveObject(ItemAccessor val);

        IList _GetItems();
        void _SetItems(IList val);

        IList _GetDialogueQuestionsAnswered();
        void _SetDialogueQuestionsAnswered(IList val);

        IList _GetFurnitureOwned();
        void _SetFurnitureOwned(IList val);

        IDictionary _GetCookingRecipes();
        void _SetCookingRecipes(IDictionary val);

        IDictionary _GetCraftingRecipes();
        void _SetCraftingRecipes(IDictionary val);

        IDictionary _GetActiveDialogueEvents();
        void _SetActiveDialogueEvents(IDictionary val);

        IList _GetEventsSeen();
        void _SetEventsSeen(IList val);

        IList _GetSongsHeard();
        void _SetSongsHeard(IList val);

        IList _GetAchievements();
        void _SetAchievements(IList val);

        IList _GetSpecialItems();
        void _SetSpecialItems(IList val);

        IList _GetSpecialBigCraftables();
        void _SetSpecialBigCraftables(IList val);

        IList _GetMailReceived();
        void _SetMailReceived(IList val);

        IList _GetMailForTomorrow();
        void _SetMailForTomorrow(IList val);

        IList _GetBlueprints();
        void _SetBlueprints(IList val);

        IList _GetCoopDwellers();
        void _SetCoopDwellers(IList val);

        IList _GetBarnDwellers();
        void _SetBarnDwellers(IList val);

        ToolAccessor[] _GetToolBox();
        void _SetToolBox(ToolAccessor[] val);

        ObjectAccessor _GetCupboard();
        void _SetCupboard(ObjectAccessor val);

        IList _GetMovementDirections();
        void _SetMovementDirections(IList val);

        string _GetFarmName();
        void _SetFarmName(string val);

        string _GetFavoriteThing();
        void _SetFavoriteThing(string val);

        IList _GetBuffs();
        void _SetBuffs(IList val);

        IList _GetMultiplayerMessage();
        void _SetMultiplayerMessage(IList val);

        GameLocationAccessor _GetCurrentLocation();
        void _SetCurrentLocation(GameLocationAccessor val);

        long _GetUniqueMultiplayerID();
        void _SetUniqueMultiplayerID(long val);

        string _GetTmpLocationName();
        void _SetTmpLocationName(string val);

        string _GetPreviousLocationName();
        void _SetPreviousLocationName(string val);

        bool _GetCatPerson();
        void _SetCatPerson(bool val);

        ItemAccessor _GetMostRecentlyGrabbedItem();
        void _SetMostRecentlyGrabbedItem(ItemAccessor val);

        ItemAccessor _GetItemToEat();
        void _SetItemToEat(ItemAccessor val);

        int _GetToolPower();
        void _SetToolPower(int val);

        int _GetToolHold();
        void _SetToolHold(int val);

        Vector2 _GetMostRecentBed();
        void _SetMostRecentBed(Vector2 val);

        int _GetShirt();
        void _SetShirt(int val);

        int _GetHair();
        void _SetHair(int val);

        int _GetSkin();
        void _SetSkin(int val);

        int _GetAccessory();
        void _SetAccessory(int val);

        int _GetFacialHair();
        void _SetFacialHair(int val);

        int _GetCurrentEyes();
        void _SetCurrentEyes(int val);

        int _GetBlinkTimer();
        void _SetBlinkTimer(int val);

        int _GetFestivalScore();
        void _SetFestivalScore(int val);

        float _GetTemporarySpeedBuff();
        void _SetTemporarySpeedBuff(float val);

        Color _GetHairstyleColor();
        void _SetHairstyleColor(Color val);

        Color _GetPantsColor();
        void _SetPantsColor(Color val);

        Color _GetNewEyeColor();
        void _SetNewEyeColor(Color val);

        NPCAccessor _GetDancePartner();
        void _SetDancePartner(NPCAccessor val);

        bool _GetRidingMineElevator();
        void _SetRidingMineElevator(bool val);

        bool _GetMineMovementDirectionWasUp();
        void _SetMineMovementDirectionWasUp(bool val);

        bool _GetCameFromDungeon();
        void _SetCameFromDungeon(bool val);

        bool _GetReadyConfirmation();
        void _SetReadyConfirmation(bool val);

        bool _GetExhausted();
        void _SetExhausted(bool val);

        int _GetDeepestMineLevel();
        void _SetDeepestMineLevel(int val);

        int _GetCurrentToolIndex();
        void _SetCurrentToolIndex(int val);

        int _GetWoodPieces();
        void _SetWoodPieces(int val);

        int _GetStonePieces();
        void _SetStonePieces(int val);

        int _GetCopperPieces();
        void _SetCopperPieces(int val);

        int _GetIronPieces();
        void _SetIronPieces(int val);

        int _GetCoalPieces();
        void _SetCoalPieces(int val);

        int _GetGoldPieces();
        void _SetGoldPieces(int val);

        int _GetIridiumPieces();
        void _SetIridiumPieces(int val);

        int _GetQuartzPieces();
        void _SetQuartzPieces(int val);

        int _GetCaveChoice();
        void _SetCaveChoice(int val);

        int _GetFeed();
        void _SetFeed(int val);

        int _GetFarmingLevel();
        void _SetFarmingLevel(int val);

        int _GetMiningLevel();
        void _SetMiningLevel(int val);

        int _GetCombatLevel();
        void _SetCombatLevel(int val);

        int _GetForagingLevel();
        void _SetForagingLevel(int val);

        int _GetFishingLevel();
        void _SetFishingLevel(int val);

        int _GetLuckLevel();
        void _SetLuckLevel(int val);

        int _GetNewSkillPointsToSpend();
        void _SetNewSkillPointsToSpend(int val);

        int _GetAddedFarmingLevel();
        void _SetAddedFarmingLevel(int val);

        int _GetAddedMiningLevel();
        void _SetAddedMiningLevel(int val);

        int _GetAddedCombatLevel();
        void _SetAddedCombatLevel(int val);

        int _GetAddedForagingLevel();
        void _SetAddedForagingLevel(int val);

        int _GetAddedFishingLevel();
        void _SetAddedFishingLevel(int val);

        int _GetAddedLuckLevel();
        void _SetAddedLuckLevel(int val);

        int _GetMaxStamina();
        void _SetMaxStamina(int val);

        int _GetMaxItems();
        void _SetMaxItems(int val);

        float _GetStamina();
        void _SetStamina(float val);

        int _GetResilience();
        void _SetResilience(int val);

        int _GetAttack();
        void _SetAttack(int val);

        int _GetImmunity();
        void _SetImmunity(int val);

        float _GetAttackIncreaseModifier();
        void _SetAttackIncreaseModifier(float val);

        float _GetKnockbackModifier();
        void _SetKnockbackModifier(float val);

        float _GetWeaponSpeedModifier();
        void _SetWeaponSpeedModifier(float val);

        float _GetCritChanceModifier();
        void _SetCritChanceModifier(float val);

        float _GetCritPowerModifier();
        void _SetCritPowerModifier(float val);

        float _GetWeaponPrecisionModifier();
        void _SetWeaponPrecisionModifier(float val);

        int _GetMoney();
        void _SetMoney(int val);

        int _GetClubCoins();
        void _SetClubCoins(int val);

        uint _GetTotalMoneyEarned();
        void _SetTotalMoneyEarned(uint val);

        uint _GetMillisecondsPlayed();
        void _SetMillisecondsPlayed(uint val);

        ToolAccessor _GetToolBeingUpgraded();
        void _SetToolBeingUpgraded(ToolAccessor val);

        int _GetDaysLeftForToolUpgrade();
        void _SetDaysLeftForToolUpgrade(int val);

        float _GetTimeOfLastPositionPacket();
        void _SetTimeOfLastPositionPacket(float val);

        int _GetNumUpdatesSinceLastDraw();
        void _SetNumUpdatesSinceLastDraw(int val);

        int _GetHouseUpgradeLevel();
        void _SetHouseUpgradeLevel(int val);

        int _GetDaysUntilHouseUpgrade();
        void _SetDaysUntilHouseUpgrade(int val);

        int _GetCoopUpgradeLevel();
        void _SetCoopUpgradeLevel(int val);

        int _GetBarnUpgradeLevel();
        void _SetBarnUpgradeLevel(int val);

        bool _GetHasGreenhouse();
        void _SetHasGreenhouse(bool val);

        bool _GetHasRustyKey();
        void _SetHasRustyKey(bool val);

        bool _GetHasSkullKey();
        void _SetHasSkullKey(bool val);

        bool _GetHasUnlockedSkullDoor();
        void _SetHasUnlockedSkullDoor(bool val);

        int _GetMagneticRadius();
        void _SetMagneticRadius(int val);

        int _GetTemporaryInvincibilityTimer();
        void _SetTemporaryInvincibilityTimer(int val);

        float _GetRotation();
        void _SetRotation(float val);

        int _GetCraftingTime();
        void _SetCraftingTime(int val);

        int _GetRaftPuddleCounter();
        void _SetRaftPuddleCounter(int val);

        int _GetRaftBobCounter();
        void _SetRaftBobCounter(int val);

        int _GetHealth();
        void _SetHealth(int val);

        int _GetMaxHealth();
        void _SetMaxHealth(int val);

        int _GetTimesReachedMineBottom();
        void _SetTimesReachedMineBottom(int val);

        Vector2 _GetJitter();
        void _SetJitter(Vector2 val);

        Vector2 _GetLastPosition();
        void _SetLastPosition(Vector2 val);

        Vector2 _GetLastGrabTile();
        void _SetLastGrabTile(Vector2 val);

        float _GetJitterStrength();
        void _SetJitterStrength(float val);

        float _GetXOffset();
        void _SetXOffset(float val);

        bool _GetIsMale();
        void _SetIsMale(bool val);

        bool _GetCanMove();
        void _SetCanMove(bool val);

        bool _GetRunning();
        void _SetRunning(bool val);

        bool _GetUsingTool();
        void _SetUsingTool(bool val);

        bool _GetForceTimePass();
        void _SetForceTimePass(bool val);

        bool _GetIsRafting();
        void _SetIsRafting(bool val);

        bool _GetUsingSlingshot();
        void _SetUsingSlingshot(bool val);

        bool _GetBathingClothes();
        void _SetBathingClothes(bool val);

        bool _GetCanOnlyWalk();
        void _SetCanOnlyWalk(bool val);

        bool _GetTemporarilyInvincible();
        void _SetTemporarilyInvincible(bool val);

        bool _GetHasBusTicket();
        void _SetHasBusTicket(bool val);

        bool _GetStardewHero();
        void _SetStardewHero(bool val);

        bool _GetHasClubCard();
        void _SetHasClubCard(bool val);

        bool _GetHasSpecialCharm();
        void _SetHasSpecialCharm(bool val);

        bool _GetCanReleaseTool();
        void _SetCanReleaseTool(bool val);

        bool _GetIsCrafting();
        void _SetIsCrafting(bool val);

        Rectangle _GetTemporaryImpassableTile();
        void _SetTemporaryImpassableTile(Rectangle val);

        bool _GetCanUnderstandDwarves();
        void _SetCanUnderstandDwarves(bool val);

        IDictionary _GetBasicShipped();
        void _SetBasicShipped(IDictionary val);

        IDictionary _GetMineralsFound();
        void _SetMineralsFound(IDictionary val);

        IDictionary _GetRecipesCooked();
        void _SetRecipesCooked(IDictionary val);

        IDictionary _GetArchaeologyFound();
        void _SetArchaeologyFound(IDictionary val);

        IDictionary _GetFishCaught();
        void _SetFishCaught(IDictionary val);

        IDictionary _GetFriendships();
        void _SetFriendships(IDictionary val);

        Vector2 _GetPositionBeforeEvent();
        void _SetPositionBeforeEvent(Vector2 val);

        Vector2 _GetRemotePosition();
        void _SetRemotePosition(Vector2 val);

        int _GetOrientationBeforeEvent();
        void _SetOrientationBeforeEvent(int val);

        int _GetSwimTimer();
        void _SetSwimTimer(int val);

        int _GetTimerSinceLastMovement();
        void _SetTimerSinceLastMovement(int val);

        int _GetNoMovementPause();
        void _SetNoMovementPause(int val);

        int _GetFreezePause();
        void _SetFreezePause(int val);

        float _GetYOffset();
        void _SetYOffset(float val);

        string _GetSpouse();
        void _SetSpouse(string val);

        string _GetDateStringForSaveGame();
        void _SetDateStringForSaveGame(string val);

        int _GetOverallsColor();
        void _SetOverallsColor(int val);

        int _GetShirtColor();
        void _SetShirtColor(int val);

        int _GetSkinColor();
        void _SetSkinColor(int val);

        int _GetHairColor();
        void _SetHairColor(int val);

        int _GetEyeColor();
        void _SetEyeColor(int val);

        Vector2 _GetArmOffset();
        void _SetArmOffset(Vector2 val);

        string _GetBobber();
        void _SetBobber(string val);

        ContentManager _GetFarmerTextureManager();
        void _SetFarmerTextureManager(ContentManager val);

        int _GetSaveTime();
        void _SetSaveTime(int val);

        int _GetDaysMarried();
        void _SetDaysMarried(int val);

        int _GetToolPitchAccumulator();
        void _SetToolPitchAccumulator(int val);

        int _GetCharactercollisionTimer();
        void _SetCharactercollisionTimer(int val);

        NPCAccessor _GetCollisionNPC();
        void _SetCollisionNPC(NPCAccessor val);

        float _GetMovementMultiplier();
        void _SetMovementMultiplier(float val);
    }
}