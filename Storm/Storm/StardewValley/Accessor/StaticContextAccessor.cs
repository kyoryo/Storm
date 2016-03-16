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
using System.Collections;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using xTile.Display;
using Rectangle = xTile.Dimensions.Rectangle;

namespace Storm.StardewValley.Accessor
{
    public interface StaticContextAccessor
    {
        void _AddHUDMessage(HUDMessageAccessor val);

        int _GetPixelZoom();
        void _SetPixelZoom(int val);

        int _GetTileSize();
        void _SetTileSize(int val);

        string _GetVersion();
        void _SetVersion(string val);

        GraphicsDeviceManager _GetGraphics();
        void _SetGraphics(GraphicsDeviceManager val);

        ContentManager _GetContent();
        void _SetContent(ContentManager val);

        ContentManager _GetTemporaryContent();
        void _SetTemporaryContent(ContentManager val);

        SpriteBatch _GetSpriteBatch();
        void _SetSpriteBatch(SpriteBatch val);

        GamePadState _GetOldPadState();
        void _SetOldPadState(GamePadState val);

        float _GetThumbStickSensitivity();
        void _SetThumbStickSensitivity(float val);

        float _GetRunThreshold();
        void _SetRunThreshold(float val);

        KeyboardState _GetOldKBState();
        void _SetOldKBState(KeyboardState val);

        MouseState _GetOldMouseState();
        void _SetOldMouseState(MouseState val);

        IList _GetLocations();
        void _SetLocations(IList val);

        GameLocationAccessor _GetCurrentLocation();
        void _SetCurrentLocation(GameLocationAccessor val);

        GameLocationAccessor _GetLocationAfterWarp();
        void _SetLocationAfterWarp(GameLocationAccessor val);

        IDisplayDevice _GetMapDisplayDevice();
        void _SetMapDisplayDevice(IDisplayDevice val);

        FarmerAccessor _GetPlayer();
        void _SetPlayer(FarmerAccessor val);

        FarmerAccessor _GetServerHost();
        void _SetServerHost(FarmerAccessor val);

        Rectangle _GetViewport();
        void _SetViewport(Rectangle val);

        Texture2D _GetObjectSpriteSheet();
        void _SetObjectSpriteSheet(Texture2D val);

        Texture2D _GetToolSpriteSheet();
        void _SetToolSpriteSheet(Texture2D val);

        Texture2D _GetCropSpriteSheet();
        void _SetCropSpriteSheet(Texture2D val);

        Texture2D _GetMailboxTexture();
        void _SetMailboxTexture(Texture2D val);

        Texture2D _GetEmoteSpriteSheet();
        void _SetEmoteSpriteSheet(Texture2D val);

        Texture2D _GetDebrisSpriteSheet();
        void _SetDebrisSpriteSheet(Texture2D val);

        Texture2D _GetToolIconBox();
        void _SetToolIconBox(Texture2D val);

        Texture2D _GetRainTexture();
        void _SetRainTexture(Texture2D val);

        Texture2D _GetBigCraftableSpriteSheet();
        void _SetBigCraftableSpriteSheet(Texture2D val);

        Texture2D _GetSwordSwipe();
        void _SetSwordSwipe(Texture2D val);

        Texture2D _GetSwordSwipeDark();
        void _SetSwordSwipeDark(Texture2D val);

        Texture2D _GetBuffsIcons();
        void _SetBuffsIcons(Texture2D val);

        Texture2D _GetDaybg();
        void _SetDaybg(Texture2D val);

        Texture2D _GetNightbg();
        void _SetNightbg(Texture2D val);

        Texture2D _GetLogoScreenTexture();
        void _SetLogoScreenTexture(Texture2D val);

        Texture2D _GetTvStationTexture();
        void _SetTvStationTexture(Texture2D val);

        Texture2D _GetCloud();
        void _SetCloud(Texture2D val);

        Texture2D _GetMenuTexture();
        void _SetMenuTexture(Texture2D val);

        Texture2D _GetLantern();
        void _SetLantern(Texture2D val);

        Texture2D _GetWindowLight();
        void _SetWindowLight(Texture2D val);

        Texture2D _GetSconceLight();
        void _SetSconceLight(Texture2D val);

        Texture2D _GetCauldronLight();
        void _SetCauldronLight(Texture2D val);

        Texture2D _GetShadowTexture();
        void _SetShadowTexture(Texture2D val);

        Texture2D _GetMouseCursors();
        void _SetMouseCursors(Texture2D val);

        Texture2D _GetIndoorWindowLight();
        void _SetIndoorWindowLight(Texture2D val);

        Texture2D _GetAnimations();
        void _SetAnimations(Texture2D val);

        Texture2D _GetTitleScreenBG();
        void _SetTitleScreenBG(Texture2D val);

        Texture2D _GetLogo();
        void _SetLogo(Texture2D val);

        RenderTarget2D _GetLightmap();
        void _SetLightmap(RenderTarget2D val);

        Texture2D _GetFadeToBlackRect();
        void _SetFadeToBlackRect(Texture2D val);

        Texture2D _GetStaminaRect();
        void _SetStaminaRect(Texture2D val);

        Texture2D _GetCurrentCoopTexture();
        void _SetCurrentCoopTexture(Texture2D val);

        Texture2D _GetCurrentBarnTexture();
        void _SetCurrentBarnTexture(Texture2D val);

        Texture2D _GetCurrentHouseTexture();
        void _SetCurrentHouseTexture(Texture2D val);

        Texture2D _GetGreenhouseTexture();
        void _SetGreenhouseTexture(Texture2D val);

        Texture2D _GetLittleEffect();
        void _SetLittleEffect(Texture2D val);

        SpriteFont _GetDialogueFont();
        void _SetDialogueFont(SpriteFont val);

        SpriteFont _GetSmallFont();
        void _SetSmallFont(SpriteFont val);

        SpriteFont _GetBorderFont();
        void _SetBorderFont(SpriteFont val);

        SpriteFont _GetTinyFont();
        void _SetTinyFont(SpriteFont val);

        SpriteFont _GetTinyFontBorder();
        void _SetTinyFontBorder(SpriteFont val);

        SpriteFont _GetSmoothFont();
        void _SetSmoothFont(SpriteFont val);

        float _GetFadeToBlackAlpha();
        void _SetFadeToBlackAlpha(float val);

        float _GetPickToolInterval();
        void _SetPickToolInterval(float val);

        float _GetScreenGlowAlpha();
        void _SetScreenGlowAlpha(float val);

        float _GetFlashAlpha();
        void _SetFlashAlpha(float val);

        float _GetStarCropShimmerPause();
        void _SetStarCropShimmerPause(float val);

        float _GetNoteBlockTimer();
        void _SetNoteBlockTimer(float val);

        float _GetGlobalFadeSpeed();
        void _SetGlobalFadeSpeed(float val);

        bool _GetFadeToBlack();
        void _SetFadeToBlack(bool val);

        bool _GetFadeIn();
        void _SetFadeIn(bool val);

        bool _GetDialogueUp();
        void _SetDialogueUp(bool val);

        bool _GetDialogueTyping();
        void _SetDialogueTyping(bool val);

        bool _GetPickingTool();
        void _SetPickingTool(bool val);

        bool _GetIsQuestion();
        void _SetIsQuestion(bool val);

        bool _GetNonWarpFade();
        void _SetNonWarpFade(bool val);

        bool _GetParticleRaining();
        void _SetParticleRaining(bool val);

        bool _GetNewDay();
        void _SetNewDay(bool val);

        bool _GetInMine();
        void _SetInMine(bool val);

        bool _GetIsEating();
        void _SetIsEating(bool val);

        bool _GetMenuUp();
        void _SetMenuUp(bool val);

        bool _GetEventUp();
        void _SetEventUp(bool val);

        bool _GetViewportFreeze();
        void _SetViewportFreeze(bool val);

        bool _GetEventOver();
        void _SetEventOver(bool val);

        bool _GetNameSelectUp();
        void _SetNameSelectUp(bool val);

        bool _GetScreenGlow();
        void _SetScreenGlow(bool val);

        bool _GetScreenGlowHold();
        void _SetScreenGlowHold(bool val);

        bool _GetScreenGlowUp();
        void _SetScreenGlowUp(bool val);

        bool _GetProgressBar();
        void _SetProgressBar(bool val);

        bool _GetIsRaining();
        void _SetIsRaining(bool val);

        bool _GetIsSnowing();
        void _SetIsSnowing(bool val);

        bool _GetKillScreen();
        void _SetKillScreen(bool val);

        bool _GetCoopDwellerBorn();
        void _SetCoopDwellerBorn(bool val);

        bool _GetMessagePause();
        void _SetMessagePause(bool val);

        bool _GetIsDebrisWeather();
        void _SetIsDebrisWeather(bool val);

        bool _GetBoardingBus();
        void _SetBoardingBus(bool val);

        bool _GetListeningForKeyControlDefinitions();
        void _SetListeningForKeyControlDefinitions(bool val);

        bool _GetWeddingToday();
        void _SetWeddingToday(bool val);

        bool _GetExitToTitle();
        void _SetExitToTitle(bool val);

        bool _GetDebugMode();
        void _SetDebugMode(bool val);

        bool _GetIsLightning();
        void _SetIsLightning(bool val);

        bool _GetDisplayHUD();
        void _SetDisplayHUD(bool val);

        bool _GetDisplayFarmer();
        void _SetDisplayFarmer(bool val);

        bool _GetShowKeyHelp();
        void _SetShowKeyHelp(bool val);

        bool _GetInputMode();
        void _SetInputMode(bool val);

        bool _GetShippingTax();
        void _SetShippingTax(bool val);

        bool _GetDialogueButtonShrinking();
        void _SetDialogueButtonShrinking(bool val);

        bool _GetJukeboxPlaying();
        void _SetJukeboxPlaying(bool val);

        bool _GetDrawLighting();
        void _SetDrawLighting(bool val);

        bool _GetBloomDay();
        void _SetBloomDay(bool val);

        bool _GetQuit();
        void _SetQuit(bool val);

        bool _GetIsChatting();
        void _SetIsChatting(bool val);

        bool _GetGlobalFade();
        void _SetGlobalFade(bool val);

        bool _GetDrawGrid();
        void _SetDrawGrid(bool val);

        bool _GetFreezeControls();
        void _SetFreezeControls(bool val);

        bool _GetSaveOnNewDay();
        void _SetSaveOnNewDay(bool val);

        bool _GetPanMode();
        void _SetPanMode(bool val);

        bool _GetShowingEndOfNightStuff();
        void _SetShowingEndOfNightStuff(bool val);

        bool _GetWasRainingYesterday();
        void _SetWasRainingYesterday(bool val);

        bool _GetHasLoadedGame();
        void _SetHasLoadedGame(bool val);

        bool _GetIsActionAtCurrentCursorTile();
        void _SetIsActionAtCurrentCursorTile(bool val);

        bool _GetIsInspectionAtCurrentCursorTile();
        void _SetIsInspectionAtCurrentCursorTile(bool val);

        bool _GetPaused();
        void _SetPaused(bool val);

        bool _GetLastCursorMotionWasMouse();
        void _SetLastCursorMotionWasMouse(bool val);

        string _GetCurrentSeason();
        void _SetCurrentSeason(string val);

        string _GetDebugOutput();
        void _SetDebugOutput(string val);

        string _GetNextMusicTrack();
        void _SetNextMusicTrack(string val);

        string _GetSelectedItemsType();
        void _SetSelectedItemsType(string val);

        string _GetNameSelectType();
        void _SetNameSelectType(string val);

        string _GetMessageAfterPause();
        void _SetMessageAfterPause(string val);

        string _GetFertilizer();
        void _SetFertilizer(string val);

        string _GetSamBandName();
        void _SetSamBandName(string val);

        string _GetElliottBookName();
        void _SetElliottBookName(string val);

        string _GetSlotResult();
        void _SetSlotResult(string val);

        string _GetKeyHelpString();
        void _SetKeyHelpString(string val);

        string _GetDebugInput();
        void _SetDebugInput(string val);

        string _GetLoadingMessage();
        void _SetLoadingMessage(string val);

        string _GetErrorMessage();
        void _SetErrorMessage(string val);

        ICollection _GetCurrentObjectDialogue();
        void _SetCurrentObjectDialogue(ICollection val);

        ICollection _GetMailbox();
        void _SetMailbox(ICollection val);

        IList _GetQuestionChoices();
        void _SetQuestionChoices(IList val);

        int _GetXLocationAfterWarp();
        void _SetXLocationAfterWarp(int val);

        int _GetYLocationAfterWarp();
        void _SetYLocationAfterWarp(int val);

        int _GetGameTimeInterval();
        void _SetGameTimeInterval(int val);

        int _GetCurrentQuestionChoice();
        void _SetCurrentQuestionChoice(int val);

        int _GetCurrentDialogueCharacterIndex();
        void _SetCurrentDialogueCharacterIndex(int val);

        int _GetDialogueTypingInterval();
        void _SetDialogueTypingInterval(int val);

        int _GetDayOfMonth();
        void _SetDayOfMonth(int val);

        int _GetYear();
        void _SetYear(int val);

        int _GetTimeOfDay();
        void _SetTimeOfDay(int val);

        int _GetNumberOfSelectedItems();
        void _SetNumberOfSelectedItems(int val);

        int _GetPriceOfSelectedItem();
        void _SetPriceOfSelectedItem(int val);

        int _GetCurrentWallpaper();
        void _SetCurrentWallpaper(int val);

        int _GetFarmerWallpaper();
        void _SetFarmerWallpaper(int val);

        int _GetWallpaperPrice();
        void _SetWallpaperPrice(int val);

        int _GetCurrentFloor();
        void _SetCurrentFloor(int val);

        int _GetFarmerFloor();
        void _SetFarmerFloor(int val);

        int _GetFloorPrice();
        void _SetFloorPrice(int val);

        int _GetDialogueWidth();
        void _SetDialogueWidth(int val);

        int _GetCountdownToWedding();
        void _SetCountdownToWedding(int val);

        int _GetMenuChoice();
        void _SetMenuChoice(int val);

        int _GetTvStation();
        void _SetTvStation(int val);

        int _GetCurrentBillboard();
        void _SetCurrentBillboard(int val);

        int _GetFacingDirectionAfterWarp();
        void _SetFacingDirectionAfterWarp(int val);

        int _GetTmpTimeOfDay();
        void _SetTmpTimeOfDay(int val);

        int _GetPercentageToWinStardewHero();
        void _SetPercentageToWinStardewHero(int val);

        int _GetMouseClickPolling();
        void _SetMouseClickPolling(int val);

        int _GetWeatherIcon();
        void _SetWeatherIcon(int val);

        int _GetHitShakeTimer();
        void _SetHitShakeTimer(int val);

        int _GetStaminaShakeTimer();
        void _SetStaminaShakeTimer(int val);

        int _GetPauseThenDoFunctionTimer();
        void _SetPauseThenDoFunctionTimer(int val);

        int _GetWeatherForTomorrow();
        void _SetWeatherForTomorrow(int val);

        int _GetCurrentSongIndex();
        void _SetCurrentSongIndex(int val);

        int _GetCursorTileHintCheckTimer();
        void _SetCursorTileHintCheckTimer(int val);

        int _GetTimerUntilMouseFade();
        void _SetTimerUntilMouseFade(int val);

        int _GetMinecartHighScore();
        void _SetMinecartHighScore(int val);

        IList _GetDealerCalicoJackTotal();
        void _SetDealerCalicoJackTotal(IList val);

        Color _GetMorningColor();
        void _SetMorningColor(Color val);

        Color _GetEveningColor();
        void _SetEveningColor(Color val);

        Color _GetUnselectedOptionColor();
        void _SetUnselectedOptionColor(Color val);

        Color _GetScreenGlowColor();
        void _SetScreenGlowColor(Color val);

        NPCAccessor _GetCurrentSpeaker();
        void _SetCurrentSpeaker(NPCAccessor val);

        Random _GetRandom();
        void _SetRandom(Random val);

        Random _GetRecentMultiplayerRandom();
        void _SetRecentMultiplayerRandom(Random val);

        IDictionary _GetObjectInformation();
        void _SetObjectInformation(IDictionary val);

        IDictionary _GetBigCraftablesInformation();
        void _SetBigCraftablesInformation(IDictionary val);

        IList _GetShippingBin();
        void _SetShippingBin(IList val);

        IList _GetHudMessages();
        void _SetHudMessages(IList val);

        IDictionary _GetEventConditions();
        void _SetEventConditions(IDictionary val);

        IDictionary _GetNPCGiftTastes();
        void _SetNPCGiftTastes(IDictionary val);

        float _GetMusicPlayerVolume();
        void _SetMusicPlayerVolume(float val);

        float _GetPauseAccumulator();
        void _SetPauseAccumulator(float val);

        float _GetPauseTime();
        void _SetPauseTime(float val);

        float _GetUpPolling();
        void _SetUpPolling(float val);

        float _GetDownPolling();
        void _SetDownPolling(float val);

        float _GetRightPolling();
        void _SetRightPolling(float val);

        float _GetLeftPolling();
        void _SetLeftPolling(float val);

        float _GetDebrisSoundInterval();
        void _SetDebrisSoundInterval(float val);

        float _GetToolHold();
        void _SetToolHold(float val);

        float _GetWindGust();
        void _SetWindGust(float val);

        float _GetDialogueButtonScale();
        void _SetDialogueButtonScale(float val);

        float _GetCreditsTimer();
        void _SetCreditsTimer(float val);

        float _GetGlobalOutdoorLighting();
        void _SetGlobalOutdoorLighting(float val);

        PlayerIndex _GetPlayerOneIndex();
        void _SetPlayerOneIndex(PlayerIndex val);

        Vector2 _GetShiny();
        void _SetShiny(Vector2 val);

        Vector2 _GetPreviousViewportPosition();
        void _SetPreviousViewportPosition(Vector2 val);

        Vector2 _GetCurrentCursorTile();
        void _SetCurrentCursorTile(Vector2 val);

        Vector2 _GetLastCursorTile();
        void _SetLastCursorTile(Vector2 val);

        double _GetChanceToRainTomorrow();
        void _SetChanceToRainTomorrow(double val);

        double _GetDailyLuck();
        void _SetDailyLuck(double val);

        IList _GetDebrisWeather();
        void _SetDebrisWeather(IList val);

        IList _GetScreenOverlayTempSprites();
        void _SetScreenOverlayTempSprites(IList val);

        byte _GetGameMode();
        void _SetGameMode(byte val);

        byte _GetMultiplayerMode();
        void _SetMultiplayerMode(byte val);

        IEnumerator _GetCurrentLoader();
        void _SetCurrentLoader(IEnumerator val);

        ulong _GetUniqueIDForThisGame();
        void _SetUniqueIDForThisGame(ulong val);

        int _GetCropsOfTheWeek();
        void _SetCropsOfTheWeek(int val);

        Color _GetAmbientLight();
        void _SetAmbientLight(Color val);

        Color _GetOutdoorLight();
        void _SetOutdoorLight(Color val);

        Color _GetTextColor();
        void _SetTextColor(Color val);

        Color _GetTextShadowColor();
        void _SetTextShadowColor(Color val);

        ClickableMenuAccessor _GetActiveClickableMenu();
        void _SetActiveClickableMenu(ClickableMenuAccessor val);

        IList _GetOnScreenMenus();
        void _SetOnScreenMenus(IList val);

        int _GetFramesThisSecond();
        void _SetFramesThisSecond(int val);

        int _GetSecondCounter();
        void _SetSecondCounter(int val);

        int _GetCurrentfps();
        void _SetCurrentfps(int val);

        IDictionary _GetAchievements();
        void _SetAchievements(IDictionary val);

        ObjectAccessor _GetDishOfTheDay();
        void _SetDishOfTheDay(ObjectAccessor val);

        IDictionary _GetOtherFarmers();
        void _SetOtherFarmers(IDictionary val);

        GameTime _GetCurrentGameTime();
        void _SetCurrentGameTime(GameTime val);

        IList _GetDelayedActions();
        void _SetDelayedActions(IList val);

        Stack _GetEndOfNightMenus();
        void _SetEndOfNightMenus(Stack val);

        StaticContextAccessor _GetGame1();
        void _SetGame1(StaticContextAccessor val);

        Point _GetLastMousePositionBeforeFade();
        void _SetLastMousePositionBeforeFade(Point val);

        Point _GetViewportCenter();
        void _SetViewportCenter(Point val);

        Vector2 _GetViewportTarget();
        void _SetViewportTarget(Vector2 val);

        float _GetViewportSpeed();
        void _SetViewportSpeed(float val);

        int _GetViewportHold();
        void _SetViewportHold(int val);

        int _GetThumbstickPollingTimer();
        void _SetThumbstickPollingTimer(int val);

        bool _GetToggleFullScreen();
        void _SetToggleFullScreen(bool val);

        bool _GetIsFullscreen();
        void _SetIsFullscreen(bool val);

        bool _GetSetToWindowedMode();
        void _SetSetToWindowedMode(bool val);

        bool _GetSetToFullscreen();
        void _SetSetToFullscreen(bool val);

        string _GetWhereIsTodaysFest();
        void _SetWhereIsTodaysFest(string val);

        bool _GetFarmerShouldPassOut();
        void _SetFarmerShouldPassOut(bool val);

        Vector2 _GetCurrentViewportTarget();
        void _SetCurrentViewportTarget(Vector2 val);

        Vector2 _GetViewportPositionLerp();
        void _SetViewportPositionLerp(Vector2 val);

        float _GetScreenGlowRate();
        void _SetScreenGlowRate(float val);

        float _GetScreenGlowMax();
        void _SetScreenGlowMax(float val);

        bool _GetHaltAfterCheck();
        void _SetHaltAfterCheck(bool val);

        string _GetPanModeString();
        void _SetPanModeString(string val);

        bool _GetPanFacingDirectionWait();
        void _SetPanFacingDirectionWait(bool val);

        int _GetThumbstickMotionMargin();
        void _SetThumbstickMotionMargin(int val);

        int _GetTriggerPolling();
        void _SetTriggerPolling(int val);

        int _GetRightClickPolling();
        void _SetRightClickPolling(int val);

        Matrix _GetScaleMatrix();
        void _SetScaleMatrix(Matrix val);

        Color _GetBgColor();
        void _SetBgColor(Color val);

        int _GetMouseCursor();
        void _SetMouseCursor(int val);

        float _GetMouseCursorTransparency();
        void _SetMouseCursorTransparency(float val);

        NPCAccessor _GetObjectDialoguePortraitPerson();
        void _SetObjectDialoguePortraitPerson(NPCAccessor val);

        void _DrawBoldText(SpriteBatch b, string text, SpriteFont font, Vector2 position, Color color, float scale = 1f, float layerDepth = -1f, int boldnessOffset = 1);
        void _DrawWithShadow(SpriteBatch b, Texture2D texture, Vector2 position, Microsoft.Xna.Framework.Rectangle sourceRect, Color color, float rotation, Vector2 origin, float scale = -1f, bool flipped = false, float layerDepth = -1f, int horizontalShadowOffset = -1, int verticalShadowOffset = -1, float shadowIntensity = 0.35f);
        void _DrawTextWithShadow(SpriteBatch b, string text, SpriteFont font, Vector2 position, Color color, float scale = 1f, float layerDepth = -1f, int horizontalShadowOffset = -1, int verticalShadowOffset = -1, float shadowIntensity = 1f, int numShadows = 3);

        void _DrawHoverText(SpriteBatch b, string text, SpriteFont font, int xOffset = 0, int yOffset = 0, int moneyAmountToDisplayAtBottom = -1, string boldTitleText = null, int healAmountToDisplay = -1, string[] buffIconsToDisplay = null, ItemAccessor hoveredItem = null, int currencySymbol = 0, int extraItemToShowIndex = -1, int extraItemToShowAmount = -1, int overrideX = -1, int overrideY = -1, float alpha = 1f, CraftingRecipeAccessor craftingIngredients = null);
    }
} 
