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
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Storm.StardewValley.Accessor;
using xTile.Display;
using Rectangle = xTile.Dimensions.Rectangle;
using System.Collections.Generic;

namespace Storm.StardewValley.Wrapper
{
    public class StaticContext : Wrapper<StaticContextAccessor>
    {
        private readonly StaticContextAccessor accessor;

        public StaticContext(StaticContextAccessor accessor)
        {
            this.accessor = accessor;
        }

        public GameWindow Window
        {
            get { return ((Game) accessor).Window; }
        }

        public Rectangle Viewport
        {
            get { return accessor._GetViewport(); }
        }

        public Farmer Player
        {
            get
            {
                var farmer = accessor._GetPlayer();
                if (farmer == null) return null;
                return new Farmer(this, farmer);
            }
        }

        public GameLocation CurrentLocation
        {
            get
            {
                var location = accessor._GetCurrentLocation();
                return location == null ? null : new GameLocation(this, location);
            }
        }

        public int PixelZoom
        {
            get { return accessor._GetPixelZoom(); }
            set { accessor._SetPixelZoom(value); }
        }

        public int TileSize
        {
            get { return accessor._GetTileSize(); }
            set { accessor._SetTileSize(value); }
        }

        public string Version
        {
            get { return accessor._GetVersion(); }
            set { accessor._SetVersion(value); }
        }

        public GraphicsDeviceManager Graphics
        {
            get { return accessor._GetGraphics(); }
            set { accessor._SetGraphics(value); }
        }

        public ContentManager Content
        {
            get { return accessor._GetContent(); }
            set { accessor._SetContent(value); }
        }

        public ContentManager TemporaryContent
        {
            get { return accessor._GetTemporaryContent(); }
            set { accessor._SetTemporaryContent(value); }
        }

        public SpriteBatch SpriteBatch
        {
            get { return accessor._GetSpriteBatch(); }
            set { accessor._SetSpriteBatch(value); }
        }

        public GamePadState OldPadState
        {
            get { return accessor._GetOldPadState(); }
            set { accessor._SetOldPadState(value); }
        }

        public float ThumbStickSensitivity
        {
            get { return accessor._GetThumbStickSensitivity(); }
            set { accessor._SetThumbStickSensitivity(value); }
        }

        public float RunThreshold
        {
            get { return accessor._GetRunThreshold(); }
            set { accessor._SetRunThreshold(value); }
        }

        public KeyboardState OldKBState
        {
            get { return accessor._GetOldKBState(); }
            set { accessor._SetOldKBState(value); }
        }

        public MouseState OldMouseState
        {
            get { return accessor._GetOldMouseState(); }
            set { accessor._SetOldMouseState(value); }
        }

        public GameLocation LocationAfterWarp
        {
            get { return new GameLocation(this, accessor._GetLocationAfterWarp()); }
            set { accessor._SetLocationAfterWarp(value.Expose()); }
        }

        public IDisplayDevice MapDisplayDevice
        {
            get { return accessor._GetMapDisplayDevice(); }
            set { accessor._SetMapDisplayDevice(value); }
        }

        public Farmer ServerHost
        {
            get { return new Farmer(this, accessor._GetServerHost()); }
            set { accessor._SetServerHost(value.Expose()); }
        }

        public Texture2D ObjectSpriteSheet
        {
            get { return accessor._GetObjectSpriteSheet(); }
            set { accessor._SetObjectSpriteSheet(value); }
        }

        public Texture2D ToolSpriteSheet
        {
            get { return accessor._GetToolSpriteSheet(); }
            set { accessor._SetToolSpriteSheet(value); }
        }

        public Texture2D CropSpriteSheet
        {
            get { return accessor._GetCropSpriteSheet(); }
            set { accessor._SetCropSpriteSheet(value); }
        }

        public Texture2D MailboxTexture
        {
            get { return accessor._GetMailboxTexture(); }
            set { accessor._SetMailboxTexture(value); }
        }

        public Texture2D EmoteSpriteSheet
        {
            get { return accessor._GetEmoteSpriteSheet(); }
            set { accessor._SetEmoteSpriteSheet(value); }
        }

        public Texture2D DebrisSpriteSheet
        {
            get { return accessor._GetDebrisSpriteSheet(); }
            set { accessor._SetDebrisSpriteSheet(value); }
        }

        public Texture2D ToolIconBox
        {
            get { return accessor._GetToolIconBox(); }
            set { accessor._SetToolIconBox(value); }
        }

        public Texture2D RainTexture
        {
            get { return accessor._GetRainTexture(); }
            set { accessor._SetRainTexture(value); }
        }

        public Texture2D BigCraftableSpriteSheet
        {
            get { return accessor._GetBigCraftableSpriteSheet(); }
            set { accessor._SetBigCraftableSpriteSheet(value); }
        }

        public Texture2D SwordSwipe
        {
            get { return accessor._GetSwordSwipe(); }
            set { accessor._SetSwordSwipe(value); }
        }

        public Texture2D SwordSwipeDark
        {
            get { return accessor._GetSwordSwipeDark(); }
            set { accessor._SetSwordSwipeDark(value); }
        }

        public Texture2D BuffsIcons
        {
            get { return accessor._GetBuffsIcons(); }
            set { accessor._SetBuffsIcons(value); }
        }

        public Texture2D Daybg
        {
            get { return accessor._GetDaybg(); }
            set { accessor._SetDaybg(value); }
        }

        public Texture2D Nightbg
        {
            get { return accessor._GetNightbg(); }
            set { accessor._SetNightbg(value); }
        }

        public Texture2D LogoScreenTexture
        {
            get { return accessor._GetLogoScreenTexture(); }
            set { accessor._SetLogoScreenTexture(value); }
        }

        public Texture2D TvStationTexture
        {
            get { return accessor._GetTvStationTexture(); }
            set { accessor._SetTvStationTexture(value); }
        }

        public Texture2D Cloud
        {
            get { return accessor._GetCloud(); }
            set { accessor._SetCloud(value); }
        }

        public Texture2D MenuTexture
        {
            get { return accessor._GetMenuTexture(); }
            set { accessor._SetMenuTexture(value); }
        }

        public Texture2D Lantern
        {
            get { return accessor._GetLantern(); }
            set { accessor._SetLantern(value); }
        }

        public Texture2D WindowLight
        {
            get { return accessor._GetWindowLight(); }
            set { accessor._SetWindowLight(value); }
        }

        public Texture2D SconceLight
        {
            get { return accessor._GetSconceLight(); }
            set { accessor._SetSconceLight(value); }
        }

        public Texture2D CauldronLight
        {
            get { return accessor._GetCauldronLight(); }
            set { accessor._SetCauldronLight(value); }
        }

        public Texture2D ShadowTexture
        {
            get { return accessor._GetShadowTexture(); }
            set { accessor._SetShadowTexture(value); }
        }

        public Texture2D MouseCursors
        {
            get { return accessor._GetMouseCursors(); }
            set { accessor._SetMouseCursors(value); }
        }

        public Texture2D IndoorWindowLight
        {
            get { return accessor._GetIndoorWindowLight(); }
            set { accessor._SetIndoorWindowLight(value); }
        }

        public Texture2D Animations
        {
            get { return accessor._GetAnimations(); }
            set { accessor._SetAnimations(value); }
        }

        public Texture2D TitleScreenBG
        {
            get { return accessor._GetTitleScreenBG(); }
            set { accessor._SetTitleScreenBG(value); }
        }

        public Texture2D Logo
        {
            get { return accessor._GetLogo(); }
            set { accessor._SetLogo(value); }
        }

        public RenderTarget2D Lightmap
        {
            get { return accessor._GetLightmap(); }
            set { accessor._SetLightmap(value); }
        }

        public Texture2D FadeToBlackRect
        {
            get { return accessor._GetFadeToBlackRect(); }
            set { accessor._SetFadeToBlackRect(value); }
        }

        public Texture2D StaminaRect
        {
            get { return accessor._GetStaminaRect(); }
            set { accessor._SetStaminaRect(value); }
        }

        public Texture2D CurrentCoopTexture
        {
            get { return accessor._GetCurrentCoopTexture(); }
            set { accessor._SetCurrentCoopTexture(value); }
        }

        public Texture2D CurrentBarnTexture
        {
            get { return accessor._GetCurrentBarnTexture(); }
            set { accessor._SetCurrentBarnTexture(value); }
        }

        public Texture2D CurrentHouseTexture
        {
            get { return accessor._GetCurrentHouseTexture(); }
            set { accessor._SetCurrentHouseTexture(value); }
        }

        public Texture2D GreenhouseTexture
        {
            get { return accessor._GetGreenhouseTexture(); }
            set { accessor._SetGreenhouseTexture(value); }
        }

        public Texture2D LittleEffect
        {
            get { return accessor._GetLittleEffect(); }
            set { accessor._SetLittleEffect(value); }
        }

        public SpriteFont DialogueFont
        {
            get { return accessor._GetDialogueFont(); }
            set { accessor._SetDialogueFont(value); }
        }

        public SpriteFont SmallFont
        {
            get { return accessor._GetSmallFont(); }
            set { accessor._SetSmallFont(value); }
        }

        public SpriteFont BorderFont
        {
            get { return accessor._GetBorderFont(); }
            set { accessor._SetBorderFont(value); }
        }

        public SpriteFont TinyFont
        {
            get { return accessor._GetTinyFont(); }
            set { accessor._SetTinyFont(value); }
        }

        public SpriteFont TinyFontBorder
        {
            get { return accessor._GetTinyFontBorder(); }
            set { accessor._SetTinyFontBorder(value); }
        }

        public SpriteFont SmoothFont
        {
            get { return accessor._GetSmoothFont(); }
            set { accessor._SetSmoothFont(value); }
        }

        public float FadeToBlackAlpha
        {
            get { return accessor._GetFadeToBlackAlpha(); }
            set { accessor._SetFadeToBlackAlpha(value); }
        }

        public float PickToolInterval
        {
            get { return accessor._GetPickToolInterval(); }
            set { accessor._SetPickToolInterval(value); }
        }

        public float ScreenGlowAlpha
        {
            get { return accessor._GetScreenGlowAlpha(); }
            set { accessor._SetScreenGlowAlpha(value); }
        }

        public float FlashAlpha
        {
            get { return accessor._GetFlashAlpha(); }
            set { accessor._SetFlashAlpha(value); }
        }

        public float StarCropShimmerPause
        {
            get { return accessor._GetStarCropShimmerPause(); }
            set { accessor._SetStarCropShimmerPause(value); }
        }

        public float NoteBlockTimer
        {
            get { return accessor._GetNoteBlockTimer(); }
            set { accessor._SetNoteBlockTimer(value); }
        }

        public float GlobalFadeSpeed
        {
            get { return accessor._GetGlobalFadeSpeed(); }
            set { accessor._SetGlobalFadeSpeed(value); }
        }

        public bool FadeToBlack
        {
            get { return accessor._GetFadeToBlack(); }
            set { accessor._SetFadeToBlack(value); }
        }

        public bool FadeIn
        {
            get { return accessor._GetFadeIn(); }
            set { accessor._SetFadeIn(value); }
        }

        public bool DialogueUp
        {
            get { return accessor._GetDialogueUp(); }
            set { accessor._SetDialogueUp(value); }
        }

        public bool DialogueTyping
        {
            get { return accessor._GetDialogueTyping(); }
            set { accessor._SetDialogueTyping(value); }
        }

        public bool PickingTool
        {
            get { return accessor._GetPickingTool(); }
            set { accessor._SetPickingTool(value); }
        }

        public bool IsQuestion
        {
            get { return accessor._GetIsQuestion(); }
            set { accessor._SetIsQuestion(value); }
        }

        public bool NonWarpFade
        {
            get { return accessor._GetNonWarpFade(); }
            set { accessor._SetNonWarpFade(value); }
        }

        public bool ParticleRaining
        {
            get { return accessor._GetParticleRaining(); }
            set { accessor._SetParticleRaining(value); }
        }

        public bool NewDay
        {
            get { return accessor._GetNewDay(); }
            set { accessor._SetNewDay(value); }
        }

        public bool InMine
        {
            get { return accessor._GetInMine(); }
            set { accessor._SetInMine(value); }
        }

        public bool IsEating
        {
            get { return accessor._GetIsEating(); }
            set { accessor._SetIsEating(value); }
        }

        public bool MenuUp
        {
            get { return accessor._GetMenuUp(); }
            set { accessor._SetMenuUp(value); }
        }

        public bool EventUp
        {
            get { return accessor._GetEventUp(); }
            set { accessor._SetEventUp(value); }
        }

        public bool ViewportFreeze
        {
            get { return accessor._GetViewportFreeze(); }
            set { accessor._SetViewportFreeze(value); }
        }

        public bool EventOver
        {
            get { return accessor._GetEventOver(); }
            set { accessor._SetEventOver(value); }
        }

        public bool NameSelectUp
        {
            get { return accessor._GetNameSelectUp(); }
            set { accessor._SetNameSelectUp(value); }
        }

        public bool ScreenGlow
        {
            get { return accessor._GetScreenGlow(); }
            set { accessor._SetScreenGlow(value); }
        }

        public bool ScreenGlowHold
        {
            get { return accessor._GetScreenGlowHold(); }
            set { accessor._SetScreenGlowHold(value); }
        }

        public bool ScreenGlowUp
        {
            get { return accessor._GetScreenGlowUp(); }
            set { accessor._SetScreenGlowUp(value); }
        }

        public bool ProgressBar
        {
            get { return accessor._GetProgressBar(); }
            set { accessor._SetProgressBar(value); }
        }

        public bool IsRaining
        {
            get { return accessor._GetIsRaining(); }
            set { accessor._SetIsRaining(value); }
        }

        public bool IsSnowing
        {
            get { return accessor._GetIsSnowing(); }
            set { accessor._SetIsSnowing(value); }
        }

        public bool KillScreen
        {
            get { return accessor._GetKillScreen(); }
            set { accessor._SetKillScreen(value); }
        }

        public bool CoopDwellerBorn
        {
            get { return accessor._GetCoopDwellerBorn(); }
            set { accessor._SetCoopDwellerBorn(value); }
        }

        public bool MessagePause
        {
            get { return accessor._GetMessagePause(); }
            set { accessor._SetMessagePause(value); }
        }

        public bool IsDebrisWeather
        {
            get { return accessor._GetIsDebrisWeather(); }
            set { accessor._SetIsDebrisWeather(value); }
        }

        public bool BoardingBus
        {
            get { return accessor._GetBoardingBus(); }
            set { accessor._SetBoardingBus(value); }
        }

        public bool ListeningForKeyControlDefinitions
        {
            get { return accessor._GetListeningForKeyControlDefinitions(); }
            set { accessor._SetListeningForKeyControlDefinitions(value); }
        }

        public bool WeddingToday
        {
            get { return accessor._GetWeddingToday(); }
            set { accessor._SetWeddingToday(value); }
        }

        public bool ExitToTitle
        {
            get { return accessor._GetExitToTitle(); }
            set { accessor._SetExitToTitle(value); }
        }

        public bool DebugMode
        {
            get { return accessor._GetDebugMode(); }
            set { accessor._SetDebugMode(value); }
        }

        public bool IsLightning
        {
            get { return accessor._GetIsLightning(); }
            set { accessor._SetIsLightning(value); }
        }

        public bool DisplayHUD
        {
            get { return accessor._GetDisplayHUD(); }
            set { accessor._SetDisplayHUD(value); }
        }

        public bool DisplayFarmer
        {
            get { return accessor._GetDisplayFarmer(); }
            set { accessor._SetDisplayFarmer(value); }
        }

        public bool ShowKeyHelp
        {
            get { return accessor._GetShowKeyHelp(); }
            set { accessor._SetShowKeyHelp(value); }
        }

        public bool InputMode
        {
            get { return accessor._GetInputMode(); }
            set { accessor._SetInputMode(value); }
        }

        public bool ShippingTax
        {
            get { return accessor._GetShippingTax(); }
            set { accessor._SetShippingTax(value); }
        }

        public bool DialogueButtonShrinking
        {
            get { return accessor._GetDialogueButtonShrinking(); }
            set { accessor._SetDialogueButtonShrinking(value); }
        }

        public bool JukeboxPlaying
        {
            get { return accessor._GetJukeboxPlaying(); }
            set { accessor._SetJukeboxPlaying(value); }
        }

        public bool DrawLighting
        {
            get { return accessor._GetDrawLighting(); }
            set { accessor._SetDrawLighting(value); }
        }

        public bool BloomDay
        {
            get { return accessor._GetBloomDay(); }
            set { accessor._SetBloomDay(value); }
        }

        public bool Quit
        {
            get { return accessor._GetQuit(); }
            set { accessor._SetQuit(value); }
        }

        public bool IsChatting
        {
            get { return accessor._GetIsChatting(); }
            set { accessor._SetIsChatting(value); }
        }

        public bool GlobalFade
        {
            get { return accessor._GetGlobalFade(); }
            set { accessor._SetGlobalFade(value); }
        }

        public bool DrawGrid
        {
            get { return accessor._GetDrawGrid(); }
            set { accessor._SetDrawGrid(value); }
        }

        public bool FreezeControls
        {
            get { return accessor._GetFreezeControls(); }
            set { accessor._SetFreezeControls(value); }
        }

        public bool SaveOnNewDay
        {
            get { return accessor._GetSaveOnNewDay(); }
            set { accessor._SetSaveOnNewDay(value); }
        }

        public bool PanMode
        {
            get { return accessor._GetPanMode(); }
            set { accessor._SetPanMode(value); }
        }

        public bool ShowingEndOfNightStuff
        {
            get { return accessor._GetShowingEndOfNightStuff(); }
            set { accessor._SetShowingEndOfNightStuff(value); }
        }

        public bool WasRainingYesterday
        {
            get { return accessor._GetWasRainingYesterday(); }
            set { accessor._SetWasRainingYesterday(value); }
        }

        public bool HasLoadedGame
        {
            get { return accessor._GetHasLoadedGame(); }
            set { accessor._SetHasLoadedGame(value); }
        }

        public bool IsActionAtCurrentCursorTile
        {
            get { return accessor._GetIsActionAtCurrentCursorTile(); }
            set { accessor._SetIsActionAtCurrentCursorTile(value); }
        }

        public bool IsInspectionAtCurrentCursorTile
        {
            get { return accessor._GetIsInspectionAtCurrentCursorTile(); }
            set { accessor._SetIsInspectionAtCurrentCursorTile(value); }
        }

        public bool Paused
        {
            get { return accessor._GetPaused(); }
            set { accessor._SetPaused(value); }
        }

        public bool LastCursorMotionWasMouse
        {
            get { return accessor._GetLastCursorMotionWasMouse(); }
            set { accessor._SetLastCursorMotionWasMouse(value); }
        }

        public string CurrentSeason
        {
            get { return accessor._GetCurrentSeason(); }
            set { accessor._SetCurrentSeason(value); }
        }

        public string DebugOutput
        {
            get { return accessor._GetDebugOutput(); }
            set { accessor._SetDebugOutput(value); }
        }

        public string NextMusicTrack
        {
            get { return accessor._GetNextMusicTrack(); }
            set { accessor._SetNextMusicTrack(value); }
        }

        public string SelectedItemsType
        {
            get { return accessor._GetSelectedItemsType(); }
            set { accessor._SetSelectedItemsType(value); }
        }

        public string NameSelectType
        {
            get { return accessor._GetNameSelectType(); }
            set { accessor._SetNameSelectType(value); }
        }

        public string MessageAfterPause
        {
            get { return accessor._GetMessageAfterPause(); }
            set { accessor._SetMessageAfterPause(value); }
        }

        public string Fertilizer
        {
            get { return accessor._GetFertilizer(); }
            set { accessor._SetFertilizer(value); }
        }

        public string SamBandName
        {
            get { return accessor._GetSamBandName(); }
            set { accessor._SetSamBandName(value); }
        }

        public string ElliottBookName
        {
            get { return accessor._GetElliottBookName(); }
            set { accessor._SetElliottBookName(value); }
        }

        public string SlotResult
        {
            get { return accessor._GetSlotResult(); }
            set { accessor._SetSlotResult(value); }
        }

        public string KeyHelpString
        {
            get { return accessor._GetKeyHelpString(); }
            set { accessor._SetKeyHelpString(value); }
        }

        public string DebugInput
        {
            get { return accessor._GetDebugInput(); }
            set { accessor._SetDebugInput(value); }
        }

        public string LoadingMessage
        {
            get { return accessor._GetLoadingMessage(); }
            set { accessor._SetLoadingMessage(value); }
        }

        public string ErrorMessage
        {
            get { return accessor._GetErrorMessage(); }
            set { accessor._SetErrorMessage(value); }
        }

        public int XLocationAfterWarp
        {
            get { return accessor._GetXLocationAfterWarp(); }
            set { accessor._SetXLocationAfterWarp(value); }
        }

        public int YLocationAfterWarp
        {
            get { return accessor._GetYLocationAfterWarp(); }
            set { accessor._SetYLocationAfterWarp(value); }
        }

        public int GameTimeInterval
        {
            get { return accessor._GetGameTimeInterval(); }
            set { accessor._SetGameTimeInterval(value); }
        }

        public int CurrentQuestionChoice
        {
            get { return accessor._GetCurrentQuestionChoice(); }
            set { accessor._SetCurrentQuestionChoice(value); }
        }

        public int CurrentDialogueCharacterIndex
        {
            get { return accessor._GetCurrentDialogueCharacterIndex(); }
            set { accessor._SetCurrentDialogueCharacterIndex(value); }
        }

        public int DialogueTypingInterval
        {
            get { return accessor._GetDialogueTypingInterval(); }
            set { accessor._SetDialogueTypingInterval(value); }
        }

        public int DayOfMonth
        {
            get { return accessor._GetDayOfMonth(); }
            set { accessor._SetDayOfMonth(value); }
        }

        public int Year
        {
            get { return accessor._GetYear(); }
            set { accessor._SetYear(value); }
        }

        public int TimeOfDay
        {
            get { return accessor._GetTimeOfDay(); }
            set { accessor._SetTimeOfDay(value); }
        }

        public int NumberOfSelectedItems
        {
            get { return accessor._GetNumberOfSelectedItems(); }
            set { accessor._SetNumberOfSelectedItems(value); }
        }

        public int PriceOfSelectedItem
        {
            get { return accessor._GetPriceOfSelectedItem(); }
            set { accessor._SetPriceOfSelectedItem(value); }
        }

        public int CurrentWallpaper
        {
            get { return accessor._GetCurrentWallpaper(); }
            set { accessor._SetCurrentWallpaper(value); }
        }

        public int FarmerWallpaper
        {
            get { return accessor._GetFarmerWallpaper(); }
            set { accessor._SetFarmerWallpaper(value); }
        }

        public int WallpaperPrice
        {
            get { return accessor._GetWallpaperPrice(); }
            set { accessor._SetWallpaperPrice(value); }
        }

        public int CurrentFloor
        {
            get { return accessor._GetCurrentFloor(); }
            set { accessor._SetCurrentFloor(value); }
        }

        public int FarmerFloor
        {
            get { return accessor._GetFarmerFloor(); }
            set { accessor._SetFarmerFloor(value); }
        }

        public int FloorPrice
        {
            get { return accessor._GetFloorPrice(); }
            set { accessor._SetFloorPrice(value); }
        }

        public int DialogueWidth
        {
            get { return accessor._GetDialogueWidth(); }
            set { accessor._SetDialogueWidth(value); }
        }

        public int CountdownToWedding
        {
            get { return accessor._GetCountdownToWedding(); }
            set { accessor._SetCountdownToWedding(value); }
        }

        public int MenuChoice
        {
            get { return accessor._GetMenuChoice(); }
            set { accessor._SetMenuChoice(value); }
        }

        public int TvStation
        {
            get { return accessor._GetTvStation(); }
            set { accessor._SetTvStation(value); }
        }

        public int CurrentBillboard
        {
            get { return accessor._GetCurrentBillboard(); }
            set { accessor._SetCurrentBillboard(value); }
        }

        public int FacingDirectionAfterWarp
        {
            get { return accessor._GetFacingDirectionAfterWarp(); }
            set { accessor._SetFacingDirectionAfterWarp(value); }
        }

        public int TmpTimeOfDay
        {
            get { return accessor._GetTmpTimeOfDay(); }
            set { accessor._SetTmpTimeOfDay(value); }
        }

        public int PercentageToWinStardewHero
        {
            get { return accessor._GetPercentageToWinStardewHero(); }
            set { accessor._SetPercentageToWinStardewHero(value); }
        }

        public int MouseClickPolling
        {
            get { return accessor._GetMouseClickPolling(); }
            set { accessor._SetMouseClickPolling(value); }
        }

        public int WeatherIcon
        {
            get { return accessor._GetWeatherIcon(); }
            set { accessor._SetWeatherIcon(value); }
        }

        public int HitShakeTimer
        {
            get { return accessor._GetHitShakeTimer(); }
            set { accessor._SetHitShakeTimer(value); }
        }

        public int StaminaShakeTimer
        {
            get { return accessor._GetStaminaShakeTimer(); }
            set { accessor._SetStaminaShakeTimer(value); }
        }

        public int PauseThenDoFunctionTimer
        {
            get { return accessor._GetPauseThenDoFunctionTimer(); }
            set { accessor._SetPauseThenDoFunctionTimer(value); }
        }

        public int WeatherForTomorrow
        {
            get { return accessor._GetWeatherForTomorrow(); }
            set { accessor._SetWeatherForTomorrow(value); }
        }

        public int CurrentSongIndex
        {
            get { return accessor._GetCurrentSongIndex(); }
            set { accessor._SetCurrentSongIndex(value); }
        }

        public int CursorTileHintCheckTimer
        {
            get { return accessor._GetCursorTileHintCheckTimer(); }
            set { accessor._SetCursorTileHintCheckTimer(value); }
        }

        public int TimerUntilMouseFade
        {
            get { return accessor._GetTimerUntilMouseFade(); }
            set { accessor._SetTimerUntilMouseFade(value); }
        }

        public int MinecartHighScore
        {
            get { return accessor._GetMinecartHighScore(); }
            set { accessor._SetMinecartHighScore(value); }
        }

        public Color MorningColor
        {
            get { return accessor._GetMorningColor(); }
            set { accessor._SetMorningColor(value); }
        }

        public Color EveningColor
        {
            get { return accessor._GetEveningColor(); }
            set { accessor._SetEveningColor(value); }
        }

        public Color UnselectedOptionColor
        {
            get { return accessor._GetUnselectedOptionColor(); }
            set { accessor._SetUnselectedOptionColor(value); }
        }

        public Color ScreenGlowColor
        {
            get { return accessor._GetScreenGlowColor(); }
            set { accessor._SetScreenGlowColor(value); }
        }

        public NPC CurrentSpeaker
        {
            get { return new NPC(this, accessor._GetCurrentSpeaker()); }
            set { accessor._SetCurrentSpeaker(value.Expose()); }
        }

        public Random Random
        {
            get { return accessor._GetRandom(); }
            set { accessor._SetRandom(value); }
        }

        public Random RecentMultiplayerRandom
        {
            get { return accessor._GetRecentMultiplayerRandom(); }
            set { accessor._SetRecentMultiplayerRandom(value); }
        }

        public float MusicPlayerVolume
        {
            get { return accessor._GetMusicPlayerVolume(); }
            set { accessor._SetMusicPlayerVolume(value); }
        }

        public float PauseAccumulator
        {
            get { return accessor._GetPauseAccumulator(); }
            set { accessor._SetPauseAccumulator(value); }
        }

        public float PauseTime
        {
            get { return accessor._GetPauseTime(); }
            set { accessor._SetPauseTime(value); }
        }

        public float UpPolling
        {
            get { return accessor._GetUpPolling(); }
            set { accessor._SetUpPolling(value); }
        }

        public float DownPolling
        {
            get { return accessor._GetDownPolling(); }
            set { accessor._SetDownPolling(value); }
        }

        public float RightPolling
        {
            get { return accessor._GetRightPolling(); }
            set { accessor._SetRightPolling(value); }
        }

        public float LeftPolling
        {
            get { return accessor._GetLeftPolling(); }
            set { accessor._SetLeftPolling(value); }
        }

        public float DebrisSoundInterval
        {
            get { return accessor._GetDebrisSoundInterval(); }
            set { accessor._SetDebrisSoundInterval(value); }
        }

        public float ToolHold
        {
            get { return accessor._GetToolHold(); }
            set { accessor._SetToolHold(value); }
        }

        public float WindGust
        {
            get { return accessor._GetWindGust(); }
            set { accessor._SetWindGust(value); }
        }

        public float DialogueButtonScale
        {
            get { return accessor._GetDialogueButtonScale(); }
            set { accessor._SetDialogueButtonScale(value); }
        }

        public float CreditsTimer
        {
            get { return accessor._GetCreditsTimer(); }
            set { accessor._SetCreditsTimer(value); }
        }

        public float GlobalOutdoorLighting
        {
            get { return accessor._GetGlobalOutdoorLighting(); }
            set { accessor._SetGlobalOutdoorLighting(value); }
        }

        public PlayerIndex PlayerOneIndex
        {
            get { return accessor._GetPlayerOneIndex(); }
            set { accessor._SetPlayerOneIndex(value); }
        }

        public Vector2 Shiny
        {
            get { return accessor._GetShiny(); }
            set { accessor._SetShiny(value); }
        }

        public Vector2 PreviousViewportPosition
        {
            get { return accessor._GetPreviousViewportPosition(); }
            set { accessor._SetPreviousViewportPosition(value); }
        }

        public Vector2 CurrentCursorTile
        {
            get { return accessor._GetCurrentCursorTile(); }
            set { accessor._SetCurrentCursorTile(value); }
        }

        public Vector2 LastCursorTile
        {
            get { return accessor._GetLastCursorTile(); }
            set { accessor._SetLastCursorTile(value); }
        }

        public double ChanceToRainTomorrow
        {
            get { return accessor._GetChanceToRainTomorrow(); }
            set { accessor._SetChanceToRainTomorrow(value); }
        }

        public double DailyLuck
        {
            get { return accessor._GetDailyLuck(); }
            set { accessor._SetDailyLuck(value); }
        }

        public byte GameMode
        {
            get { return accessor._GetGameMode(); }
            set { accessor._SetGameMode(value); }
        }

        public byte MultiplayerMode
        {
            get { return accessor._GetMultiplayerMode(); }
            set { accessor._SetMultiplayerMode(value); }
        }

        public ulong UniqueIDForThisGame
        {
            get { return accessor._GetUniqueIDForThisGame(); }
            set { accessor._SetUniqueIDForThisGame(value); }
        }

        public int CropsOfTheWeek
        {
            get { return accessor._GetCropsOfTheWeek(); }
            set { accessor._SetCropsOfTheWeek(value); }
        }

        public Color AmbientLight
        {
            get { return accessor._GetAmbientLight(); }
            set { accessor._SetAmbientLight(value); }
        }

        public Color OutdoorLight
        {
            get { return accessor._GetOutdoorLight(); }
            set { accessor._SetOutdoorLight(value); }
        }

        public Color TextColor
        {
            get { return accessor._GetTextColor(); }
            set { accessor._SetTextColor(value); }
        }

        public Color TextShadowColor
        {
            get { return accessor._GetTextShadowColor(); }
            set { accessor._SetTextShadowColor(value); }
        }

        public ClickableMenu ActiveClickableMenu
        {
            get { return new ClickableMenu(this, accessor._GetActiveClickableMenu()); }
            set { accessor._SetActiveClickableMenu(value.Expose()); }
        }

        public int FramesThisSecond
        {
            get { return accessor._GetFramesThisSecond(); }
            set { accessor._SetFramesThisSecond(value); }
        }

        public int SecondCounter
        {
            get { return accessor._GetSecondCounter(); }
            set { accessor._SetSecondCounter(value); }
        }

        public int Currentfps
        {
            get { return accessor._GetCurrentfps(); }
            set { accessor._SetCurrentfps(value); }
        }
        
        public Object DishOfTheDay
        {
            get { return new Object(this, accessor._GetDishOfTheDay()); }
            set { accessor._SetDishOfTheDay(value.Expose()); }
        }

        public GameTime CurrentGameTime
        {
            get { return accessor._GetCurrentGameTime(); }
            set { accessor._SetCurrentGameTime(value); }
        }

        public Stack EndOfNightMenus
        {
            get { return accessor._GetEndOfNightMenus(); }
            set { accessor._SetEndOfNightMenus(value); }
        }

        public Point LastMousePositionBeforeFade
        {
            get { return accessor._GetLastMousePositionBeforeFade(); }
            set { accessor._SetLastMousePositionBeforeFade(value); }
        }

        public Point ViewportCenter
        {
            get { return accessor._GetViewportCenter(); }
            set { accessor._SetViewportCenter(value); }
        }

        public Vector2 ViewportTarget
        {
            get { return accessor._GetViewportTarget(); }
            set { accessor._SetViewportTarget(value); }
        }

        public float ViewportSpeed
        {
            get { return accessor._GetViewportSpeed(); }
            set { accessor._SetViewportSpeed(value); }
        }

        public int ViewportHold
        {
            get { return accessor._GetViewportHold(); }
            set { accessor._SetViewportHold(value); }
        }

        public int ThumbstickPollingTimer
        {
            get { return accessor._GetThumbstickPollingTimer(); }
            set { accessor._SetThumbstickPollingTimer(value); }
        }

        public bool ToggleFullScreen
        {
            get { return accessor._GetToggleFullScreen(); }
            set { accessor._SetToggleFullScreen(value); }
        }

        public bool IsFullscreen
        {
            get { return accessor._GetIsFullscreen(); }
            set { accessor._SetIsFullscreen(value); }
        }

        public bool SetToWindowedMode
        {
            get { return accessor._GetSetToWindowedMode(); }
            set { accessor._SetSetToWindowedMode(value); }
        }

        public bool SetToFullscreen
        {
            get { return accessor._GetSetToFullscreen(); }
            set { accessor._SetSetToFullscreen(value); }
        }

        public string WhereIsTodaysFest
        {
            get { return accessor._GetWhereIsTodaysFest(); }
            set { accessor._SetWhereIsTodaysFest(value); }
        }

        public bool FarmerShouldPassOut
        {
            get { return accessor._GetFarmerShouldPassOut(); }
            set { accessor._SetFarmerShouldPassOut(value); }
        }

        public Vector2 CurrentViewportTarget
        {
            get { return accessor._GetCurrentViewportTarget(); }
            set { accessor._SetCurrentViewportTarget(value); }
        }

        public Vector2 ViewportPositionLerp
        {
            get { return accessor._GetViewportPositionLerp(); }
            set { accessor._SetViewportPositionLerp(value); }
        }

        public float ScreenGlowRate
        {
            get { return accessor._GetScreenGlowRate(); }
            set { accessor._SetScreenGlowRate(value); }
        }

        public float ScreenGlowMax
        {
            get { return accessor._GetScreenGlowMax(); }
            set { accessor._SetScreenGlowMax(value); }
        }

        public bool HaltAfterCheck
        {
            get { return accessor._GetHaltAfterCheck(); }
            set { accessor._SetHaltAfterCheck(value); }
        }

        public string PanModeString
        {
            get { return accessor._GetPanModeString(); }
            set { accessor._SetPanModeString(value); }
        }

        public bool PanFacingDirectionWait
        {
            get { return accessor._GetPanFacingDirectionWait(); }
            set { accessor._SetPanFacingDirectionWait(value); }
        }

        public int ThumbstickMotionMargin
        {
            get { return accessor._GetThumbstickMotionMargin(); }
            set { accessor._SetThumbstickMotionMargin(value); }
        }

        public int TriggerPolling
        {
            get { return accessor._GetTriggerPolling(); }
            set { accessor._SetTriggerPolling(value); }
        }

        public int RightClickPolling
        {
            get { return accessor._GetRightClickPolling(); }
            set { accessor._SetRightClickPolling(value); }
        }

        public Matrix ScaleMatrix
        {
            get { return accessor._GetScaleMatrix(); }
            set { accessor._SetScaleMatrix(value); }
        }

        public Color BgColor
        {
            get { return accessor._GetBgColor(); }
            set { accessor._SetBgColor(value); }
        }

        public int MouseCursor
        {
            get { return accessor._GetMouseCursor(); }
            set { accessor._SetMouseCursor(value); }
        }

        public float MouseCursorTransparency
        {
            get { return accessor._GetMouseCursorTransparency(); }
            set { accessor._SetMouseCursorTransparency(value); }
        }

        public NPC ObjectDialoguePortraitPerson
        {
            get { return new NPC(this, accessor._GetObjectDialoguePortraitPerson()); }
            set { accessor._SetObjectDialoguePortraitPerson(value.Expose()); }
        }

        public Texture2D LoadResource(string path)
        {
            var fs = new FileStream(path, FileMode.Open);
            var tex = Texture2D.FromStream(Graphics.GraphicsDevice, fs);
            fs.Close();
            return tex;
        }

        public bool IsFestivalDay(int day, string season)
        {
            var key = day + season;
            var map = TemporaryContent?.Load<Dictionary<string, string>>(@"Data\Festivals\FestivalDates");
            return map != null && map.ContainsKey(key);
        }

        public StaticContextAccessor Expose() => accessor;
    }
}