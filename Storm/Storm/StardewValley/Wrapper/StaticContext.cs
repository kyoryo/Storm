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
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Storm.StardewValley.Accessor;
using xTile.Display;
using Rectangle = xTile.Dimensions.Rectangle;
using Storm.Collections;

namespace Storm.StardewValley.Wrapper
{
    public class StaticContext : Wrapper
    {
        public StaticContext(StaticContextAccessor accessor)
        {
            Underlying = accessor;
        }

        public StaticContext()
        {
        }

        public GameWindow Window
        {
            get { return ((Game)Cast<StaticContextAccessor>()).Window; }
        }

        public Rectangle Viewport
        {
            get { return Cast<StaticContextAccessor>()._GetViewport(); }
        }

        /// <summary>
        /// The Farmer Cast<StaticContextAccessor>() for this game
        /// </summary>
        /// <value>The Player property gets the value of the Farmer field Farmer</value>
        public Farmer Player
        {
            get
            {
                var farmer = Cast<StaticContextAccessor>()._GetPlayer();
                if (farmer == null) return null;
                return new Farmer(this, farmer);
            }
        }

        /// <summary>
        /// The current location of the player in the world
        /// </summary>
        /// <value>The CurrentLocation property gets the value of the GameLocation field CurrentLocation</value>
        public GameLocation CurrentLocation
        {
            get
            {
                var tmp = Cast<StaticContextAccessor>()._GetCurrentLocation();
                if (tmp == null) return null;
                return new GameLocation(this, Cast<StaticContextAccessor>()._GetCurrentLocation());
            }
        }

        public void AddHUDMessage(HUDMessage value)
        {
            Cast<StaticContextAccessor>()._AddHUDMessage(value?.Cast<HUDMessageAccessor>());
        }

        public bool IsActive
        {
            get { return Cast<Game>().IsActive; }
        }

        public WrappedProxyList<GameLocationAccessor, GameLocation> Locations
        {
            get
            {
                var locations = Cast<StaticContextAccessor>()._GetLocations();
                if (locations == null) return null;
                return new WrappedProxyList<GameLocationAccessor, GameLocation>(
                    locations, c => new GameLocation(this, c));
            }
            set
            {
                Cast<StaticContextAccessor>()._SetLocations(value.Real);
            }
        }

        public int PixelZoom
        {
            get { return Cast<StaticContextAccessor>()._GetPixelZoom(); }
            set { Cast<StaticContextAccessor>()._SetPixelZoom(value); }
        }

        public int TileSize
        {
            get { return Cast<StaticContextAccessor>()._GetTileSize(); }
            set { Cast<StaticContextAccessor>()._SetTileSize(value); }
        }

        public string Version
        {
            get { return Cast<StaticContextAccessor>()._GetVersion(); }
            set { Cast<StaticContextAccessor>()._SetVersion(value); }
        }

        public GraphicsDeviceManager Graphics
        {
            get { return Cast<StaticContextAccessor>()._GetGraphics(); }
            set { Cast<StaticContextAccessor>()._SetGraphics(value); }
        }

        public ContentManager Content
        {
            get { return Cast<StaticContextAccessor>()._GetContent(); }
            set { Cast<StaticContextAccessor>()._SetContent(value); }
        }

        public ContentManager TemporaryContent
        {
            get { return Cast<StaticContextAccessor>()._GetTemporaryContent(); }
            set { Cast<StaticContextAccessor>()._SetTemporaryContent(value); }
        }

        public SpriteBatch SpriteBatch
        {
            get { return Cast<StaticContextAccessor>()._GetSpriteBatch(); }
            set { Cast<StaticContextAccessor>()._SetSpriteBatch(value); }
        }

        public GamePadState OldPadState
        {
            get { return Cast<StaticContextAccessor>()._GetOldPadState(); }
            set { Cast<StaticContextAccessor>()._SetOldPadState(value); }
        }

        public float ThumbStickSensitivity
        {
            get { return Cast<StaticContextAccessor>()._GetThumbStickSensitivity(); }
            set { Cast<StaticContextAccessor>()._SetThumbStickSensitivity(value); }
        }

        public float RunThreshold
        {
            get { return Cast<StaticContextAccessor>()._GetRunThreshold(); }
            set { Cast<StaticContextAccessor>()._SetRunThreshold(value); }
        }

        public KeyboardState OldKBState
        {
            get { return Cast<StaticContextAccessor>()._GetOldKBState(); }
            set { Cast<StaticContextAccessor>()._SetOldKBState(value); }
        }

        public MouseState OldMouseState
        {
            get { return Cast<StaticContextAccessor>()._GetOldMouseState(); }
            set { Cast<StaticContextAccessor>()._SetOldMouseState(value); }
        }

        public GameLocation LocationAfterWarp
        {
            get
            {
                var tmp = Cast<StaticContextAccessor>()._GetLocationAfterWarp();
                if (tmp == null) return null;
                return new GameLocation(this, tmp);
            }
            set { Cast<StaticContextAccessor>()._SetLocationAfterWarp(value?.Cast<GameLocationAccessor>()); }
        }

        public IDisplayDevice MapDisplayDevice
        {
            get { return Cast<StaticContextAccessor>()._GetMapDisplayDevice(); }
            set { Cast<StaticContextAccessor>()._SetMapDisplayDevice(value); }
        }

        public Farmer ServerHost
        {
            get
            {
                var tmp = Cast<StaticContextAccessor>()._GetServerHost();
                if (tmp == null) return null;
                return new Farmer(this, tmp);
            }
            set { Cast<StaticContextAccessor>()._SetServerHost(value?.Cast<FarmerAccessor>()); }
        }

        public Texture2D ObjectSpriteSheet
        {
            get { return Cast<StaticContextAccessor>()._GetObjectSpriteSheet(); }
            set { Cast<StaticContextAccessor>()._SetObjectSpriteSheet(value); }
        }

        public Texture2D ToolSpriteSheet
        {
            get { return Cast<StaticContextAccessor>()._GetToolSpriteSheet(); }
            set { Cast<StaticContextAccessor>()._SetToolSpriteSheet(value); }
        }

        public Texture2D CropSpriteSheet
        {
            get { return Cast<StaticContextAccessor>()._GetCropSpriteSheet(); }
            set { Cast<StaticContextAccessor>()._SetCropSpriteSheet(value); }
        }

        public Texture2D MailboxTexture
        {
            get { return Cast<StaticContextAccessor>()._GetMailboxTexture(); }
            set { Cast<StaticContextAccessor>()._SetMailboxTexture(value); }
        }

        public Texture2D EmoteSpriteSheet
        {
            get { return Cast<StaticContextAccessor>()._GetEmoteSpriteSheet(); }
            set { Cast<StaticContextAccessor>()._SetEmoteSpriteSheet(value); }
        }

        public Texture2D DebrisSpriteSheet
        {
            get { return Cast<StaticContextAccessor>()._GetDebrisSpriteSheet(); }
            set { Cast<StaticContextAccessor>()._SetDebrisSpriteSheet(value); }
        }

        public Texture2D ToolIconBox
        {
            get { return Cast<StaticContextAccessor>()._GetToolIconBox(); }
            set { Cast<StaticContextAccessor>()._SetToolIconBox(value); }
        }

        public Texture2D RainTexture
        {
            get { return Cast<StaticContextAccessor>()._GetRainTexture(); }
            set { Cast<StaticContextAccessor>()._SetRainTexture(value); }
        }

        public Texture2D BigCraftableSpriteSheet
        {
            get { return Cast<StaticContextAccessor>()._GetBigCraftableSpriteSheet(); }
            set { Cast<StaticContextAccessor>()._SetBigCraftableSpriteSheet(value); }
        }

        public Texture2D SwordSwipe
        {
            get { return Cast<StaticContextAccessor>()._GetSwordSwipe(); }
            set { Cast<StaticContextAccessor>()._SetSwordSwipe(value); }
        }

        public Texture2D SwordSwipeDark
        {
            get { return Cast<StaticContextAccessor>()._GetSwordSwipeDark(); }
            set { Cast<StaticContextAccessor>()._SetSwordSwipeDark(value); }
        }

        public Texture2D BuffsIcons
        {
            get { return Cast<StaticContextAccessor>()._GetBuffsIcons(); }
            set { Cast<StaticContextAccessor>()._SetBuffsIcons(value); }
        }

        public BuffsDisplay BuffsDisplay
        {
            get {
                var tmp = Cast<StaticContextAccessor>()._GetBuffsDisplay();
                if (tmp == null) return null;
                return new BuffsDisplay(this, tmp);
            }
        }

        public Texture2D Daybg
        {
            get { return Cast<StaticContextAccessor>()._GetDaybg(); }
            set { Cast<StaticContextAccessor>()._SetDaybg(value); }
        }

        public Texture2D Nightbg
        {
            get { return Cast<StaticContextAccessor>()._GetNightbg(); }
            set { Cast<StaticContextAccessor>()._SetNightbg(value); }
        }

        public Texture2D LogoScreenTexture
        {
            get { return Cast<StaticContextAccessor>()._GetLogoScreenTexture(); }
            set { Cast<StaticContextAccessor>()._SetLogoScreenTexture(value); }
        }

        public Texture2D TvStationTexture
        {
            get { return Cast<StaticContextAccessor>()._GetTvStationTexture(); }
            set { Cast<StaticContextAccessor>()._SetTvStationTexture(value); }
        }

        public Texture2D Cloud
        {
            get { return Cast<StaticContextAccessor>()._GetCloud(); }
            set { Cast<StaticContextAccessor>()._SetCloud(value); }
        }

        public Texture2D MenuTexture
        {
            get { return Cast<StaticContextAccessor>()._GetMenuTexture(); }
            set { Cast<StaticContextAccessor>()._SetMenuTexture(value); }
        }

        public Texture2D Lantern
        {
            get { return Cast<StaticContextAccessor>()._GetLantern(); }
            set { Cast<StaticContextAccessor>()._SetLantern(value); }
        }

        public Texture2D WindowLight
        {
            get { return Cast<StaticContextAccessor>()._GetWindowLight(); }
            set { Cast<StaticContextAccessor>()._SetWindowLight(value); }
        }

        public Texture2D SconceLight
        {
            get { return Cast<StaticContextAccessor>()._GetSconceLight(); }
            set { Cast<StaticContextAccessor>()._SetSconceLight(value); }
        }

        public Texture2D CauldronLight
        {
            get { return Cast<StaticContextAccessor>()._GetCauldronLight(); }
            set { Cast<StaticContextAccessor>()._SetCauldronLight(value); }
        }

        public Texture2D ShadowTexture
        {
            get { return Cast<StaticContextAccessor>()._GetShadowTexture(); }
            set { Cast<StaticContextAccessor>()._SetShadowTexture(value); }
        }

        public Texture2D MouseCursors
        {
            get { return Cast<StaticContextAccessor>()._GetMouseCursors(); }
            set { Cast<StaticContextAccessor>()._SetMouseCursors(value); }
        }

        public Texture2D IndoorWindowLight
        {
            get { return Cast<StaticContextAccessor>()._GetIndoorWindowLight(); }
            set { Cast<StaticContextAccessor>()._SetIndoorWindowLight(value); }
        }

        public Texture2D Animations
        {
            get { return Cast<StaticContextAccessor>()._GetAnimations(); }
            set { Cast<StaticContextAccessor>()._SetAnimations(value); }
        }

        public Texture2D TitleScreenBG
        {
            get { return Cast<StaticContextAccessor>()._GetTitleScreenBG(); }
            set { Cast<StaticContextAccessor>()._SetTitleScreenBG(value); }
        }

        public Texture2D Logo
        {
            get { return Cast<StaticContextAccessor>()._GetLogo(); }
            set { Cast<StaticContextAccessor>()._SetLogo(value); }
        }

        public RenderTarget2D Lightmap
        {
            get { return Cast<StaticContextAccessor>()._GetLightmap(); }
            set { Cast<StaticContextAccessor>()._SetLightmap(value); }
        }

        public Texture2D FadeToBlackRect
        {
            get { return Cast<StaticContextAccessor>()._GetFadeToBlackRect(); }
            set { Cast<StaticContextAccessor>()._SetFadeToBlackRect(value); }
        }

        public Texture2D StaminaRect
        {
            get { return Cast<StaticContextAccessor>()._GetStaminaRect(); }
            set { Cast<StaticContextAccessor>()._SetStaminaRect(value); }
        }

        public Texture2D CurrentCoopTexture
        {
            get { return Cast<StaticContextAccessor>()._GetCurrentCoopTexture(); }
            set { Cast<StaticContextAccessor>()._SetCurrentCoopTexture(value); }
        }

        public Texture2D CurrentBarnTexture
        {
            get { return Cast<StaticContextAccessor>()._GetCurrentBarnTexture(); }
            set { Cast<StaticContextAccessor>()._SetCurrentBarnTexture(value); }
        }

        public Texture2D CurrentHouseTexture
        {
            get { return Cast<StaticContextAccessor>()._GetCurrentHouseTexture(); }
            set { Cast<StaticContextAccessor>()._SetCurrentHouseTexture(value); }
        }

        public Texture2D GreenhouseTexture
        {
            get { return Cast<StaticContextAccessor>()._GetGreenhouseTexture(); }
            set { Cast<StaticContextAccessor>()._SetGreenhouseTexture(value); }
        }

        public Texture2D LittleEffect
        {
            get { return Cast<StaticContextAccessor>()._GetLittleEffect(); }
            set { Cast<StaticContextAccessor>()._SetLittleEffect(value); }
        }

        public SpriteFont DialogueFont
        {
            get { return Cast<StaticContextAccessor>()._GetDialogueFont(); }
            set { Cast<StaticContextAccessor>()._SetDialogueFont(value); }
        }

        public SpriteFont SmallFont
        {
            get { return Cast<StaticContextAccessor>()._GetSmallFont(); }
            set { Cast<StaticContextAccessor>()._SetSmallFont(value); }
        }

        public SpriteFont BorderFont
        {
            get { return Cast<StaticContextAccessor>()._GetBorderFont(); }
            set { Cast<StaticContextAccessor>()._SetBorderFont(value); }
        }

        public SpriteFont TinyFont
        {
            get { return Cast<StaticContextAccessor>()._GetTinyFont(); }
            set { Cast<StaticContextAccessor>()._SetTinyFont(value); }
        }

        public SpriteFont TinyFontBorder
        {
            get { return Cast<StaticContextAccessor>()._GetTinyFontBorder(); }
            set { Cast<StaticContextAccessor>()._SetTinyFontBorder(value); }
        }

        public SpriteFont SmoothFont
        {
            get { return Cast<StaticContextAccessor>()._GetSmoothFont(); }
            set { Cast<StaticContextAccessor>()._SetSmoothFont(value); }
        }

        public float FadeToBlackAlpha
        {
            get { return Cast<StaticContextAccessor>()._GetFadeToBlackAlpha(); }
            set { Cast<StaticContextAccessor>()._SetFadeToBlackAlpha(value); }
        }

        public float PickToolInterval
        {
            get { return Cast<StaticContextAccessor>()._GetPickToolInterval(); }
            set { Cast<StaticContextAccessor>()._SetPickToolInterval(value); }
        }

        public float ScreenGlowAlpha
        {
            get { return Cast<StaticContextAccessor>()._GetScreenGlowAlpha(); }
            set { Cast<StaticContextAccessor>()._SetScreenGlowAlpha(value); }
        }

        public float FlashAlpha
        {
            get { return Cast<StaticContextAccessor>()._GetFlashAlpha(); }
            set { Cast<StaticContextAccessor>()._SetFlashAlpha(value); }
        }

        public float StarCropShimmerPause
        {
            get { return Cast<StaticContextAccessor>()._GetStarCropShimmerPause(); }
            set { Cast<StaticContextAccessor>()._SetStarCropShimmerPause(value); }
        }

        public float NoteBlockTimer
        {
            get { return Cast<StaticContextAccessor>()._GetNoteBlockTimer(); }
            set { Cast<StaticContextAccessor>()._SetNoteBlockTimer(value); }
        }

        public float GlobalFadeSpeed
        {
            get { return Cast<StaticContextAccessor>()._GetGlobalFadeSpeed(); }
            set { Cast<StaticContextAccessor>()._SetGlobalFadeSpeed(value); }
        }

        public bool FadeToBlack
        {
            get { return Cast<StaticContextAccessor>()._GetFadeToBlack(); }
            set { Cast<StaticContextAccessor>()._SetFadeToBlack(value); }
        }

        public bool FadeIn
        {
            get { return Cast<StaticContextAccessor>()._GetFadeIn(); }
            set { Cast<StaticContextAccessor>()._SetFadeIn(value); }
        }

        public bool DialogueUp
        {
            get { return Cast<StaticContextAccessor>()._GetDialogueUp(); }
            set { Cast<StaticContextAccessor>()._SetDialogueUp(value); }
        }

        public bool DialogueTyping
        {
            get { return Cast<StaticContextAccessor>()._GetDialogueTyping(); }
            set { Cast<StaticContextAccessor>()._SetDialogueTyping(value); }
        }

        public bool PickingTool
        {
            get { return Cast<StaticContextAccessor>()._GetPickingTool(); }
            set { Cast<StaticContextAccessor>()._SetPickingTool(value); }
        }

        public bool IsQuestion
        {
            get { return Cast<StaticContextAccessor>()._GetIsQuestion(); }
            set { Cast<StaticContextAccessor>()._SetIsQuestion(value); }
        }

        public bool NonWarpFade
        {
            get { return Cast<StaticContextAccessor>()._GetNonWarpFade(); }
            set { Cast<StaticContextAccessor>()._SetNonWarpFade(value); }
        }

        public bool ParticleRaining
        {
            get { return Cast<StaticContextAccessor>()._GetParticleRaining(); }
            set { Cast<StaticContextAccessor>()._SetParticleRaining(value); }
        }

        public bool NewDay
        {
            get { return Cast<StaticContextAccessor>()._GetNewDay(); }
            set { Cast<StaticContextAccessor>()._SetNewDay(value); }
        }

        public bool InMine
        {
            get { return Cast<StaticContextAccessor>()._GetInMine(); }
            set { Cast<StaticContextAccessor>()._SetInMine(value); }
        }

        public bool IsEating
        {
            get { return Cast<StaticContextAccessor>()._GetIsEating(); }
            set { Cast<StaticContextAccessor>()._SetIsEating(value); }
        }

        public bool MenuUp
        {
            get { return Cast<StaticContextAccessor>()._GetMenuUp(); }
            set { Cast<StaticContextAccessor>()._SetMenuUp(value); }
        }

        public bool EventUp
        {
            get { return Cast<StaticContextAccessor>()._GetEventUp(); }
            set { Cast<StaticContextAccessor>()._SetEventUp(value); }
        }

        public bool ViewportFreeze
        {
            get { return Cast<StaticContextAccessor>()._GetViewportFreeze(); }
            set { Cast<StaticContextAccessor>()._SetViewportFreeze(value); }
        }

        public bool EventOver
        {
            get { return Cast<StaticContextAccessor>()._GetEventOver(); }
            set { Cast<StaticContextAccessor>()._SetEventOver(value); }
        }

        public bool NameSelectUp
        {
            get { return Cast<StaticContextAccessor>()._GetNameSelectUp(); }
            set { Cast<StaticContextAccessor>()._SetNameSelectUp(value); }
        }

        public bool ScreenGlow
        {
            get { return Cast<StaticContextAccessor>()._GetScreenGlow(); }
            set { Cast<StaticContextAccessor>()._SetScreenGlow(value); }
        }

        public bool ScreenGlowHold
        {
            get { return Cast<StaticContextAccessor>()._GetScreenGlowHold(); }
            set { Cast<StaticContextAccessor>()._SetScreenGlowHold(value); }
        }

        public bool ScreenGlowUp
        {
            get { return Cast<StaticContextAccessor>()._GetScreenGlowUp(); }
            set { Cast<StaticContextAccessor>()._SetScreenGlowUp(value); }
        }

        public bool ProgressBar
        {
            get { return Cast<StaticContextAccessor>()._GetProgressBar(); }
            set { Cast<StaticContextAccessor>()._SetProgressBar(value); }
        }

        public bool IsRaining
        {
            get { return Cast<StaticContextAccessor>()._GetIsRaining(); }
            set { Cast<StaticContextAccessor>()._SetIsRaining(value); }
        }

        public bool IsSnowing
        {
            get { return Cast<StaticContextAccessor>()._GetIsSnowing(); }
            set { Cast<StaticContextAccessor>()._SetIsSnowing(value); }
        }

        public bool KillScreen
        {
            get { return Cast<StaticContextAccessor>()._GetKillScreen(); }
            set { Cast<StaticContextAccessor>()._SetKillScreen(value); }
        }

        public bool CoopDwellerBorn
        {
            get { return Cast<StaticContextAccessor>()._GetCoopDwellerBorn(); }
            set { Cast<StaticContextAccessor>()._SetCoopDwellerBorn(value); }
        }

        public bool MessagePause
        {
            get { return Cast<StaticContextAccessor>()._GetMessagePause(); }
            set { Cast<StaticContextAccessor>()._SetMessagePause(value); }
        }

        public bool IsDebrisWeather
        {
            get { return Cast<StaticContextAccessor>()._GetIsDebrisWeather(); }
            set { Cast<StaticContextAccessor>()._SetIsDebrisWeather(value); }
        }

        public bool BoardingBus
        {
            get { return Cast<StaticContextAccessor>()._GetBoardingBus(); }
            set { Cast<StaticContextAccessor>()._SetBoardingBus(value); }
        }

        public bool ListeningForKeyControlDefinitions
        {
            get { return Cast<StaticContextAccessor>()._GetListeningForKeyControlDefinitions(); }
            set { Cast<StaticContextAccessor>()._SetListeningForKeyControlDefinitions(value); }
        }

        public bool WeddingToday
        {
            get { return Cast<StaticContextAccessor>()._GetWeddingToday(); }
            set { Cast<StaticContextAccessor>()._SetWeddingToday(value); }
        }

        public bool ExitToTitle
        {
            get { return Cast<StaticContextAccessor>()._GetExitToTitle(); }
            set { Cast<StaticContextAccessor>()._SetExitToTitle(value); }
        }

        public bool DebugMode
        {
            get { return Cast<StaticContextAccessor>()._GetDebugMode(); }
            set { Cast<StaticContextAccessor>()._SetDebugMode(value); }
        }

        public bool IsLightning
        {
            get { return Cast<StaticContextAccessor>()._GetIsLightning(); }
            set { Cast<StaticContextAccessor>()._SetIsLightning(value); }
        }

        public bool DisplayHUD
        {
            get { return Cast<StaticContextAccessor>()._GetDisplayHUD(); }
            set { Cast<StaticContextAccessor>()._SetDisplayHUD(value); }
        }

        public bool DisplayFarmer
        {
            get { return Cast<StaticContextAccessor>()._GetDisplayFarmer(); }
            set { Cast<StaticContextAccessor>()._SetDisplayFarmer(value); }
        }

        public bool ShowKeyHelp
        {
            get { return Cast<StaticContextAccessor>()._GetShowKeyHelp(); }
            set { Cast<StaticContextAccessor>()._SetShowKeyHelp(value); }
        }

        public bool InputMode
        {
            get { return Cast<StaticContextAccessor>()._GetInputMode(); }
            set { Cast<StaticContextAccessor>()._SetInputMode(value); }
        }

        public bool ShippingTax
        {
            get { return Cast<StaticContextAccessor>()._GetShippingTax(); }
            set { Cast<StaticContextAccessor>()._SetShippingTax(value); }
        }

        public bool DialogueButtonShrinking
        {
            get { return Cast<StaticContextAccessor>()._GetDialogueButtonShrinking(); }
            set { Cast<StaticContextAccessor>()._SetDialogueButtonShrinking(value); }
        }

        public bool JukeboxPlaying
        {
            get { return Cast<StaticContextAccessor>()._GetJukeboxPlaying(); }
            set { Cast<StaticContextAccessor>()._SetJukeboxPlaying(value); }
        }

        public bool DrawLighting
        {
            get { return Cast<StaticContextAccessor>()._GetDrawLighting(); }
            set { Cast<StaticContextAccessor>()._SetDrawLighting(value); }
        }

        public bool BloomDay
        {
            get { return Cast<StaticContextAccessor>()._GetBloomDay(); }
            set { Cast<StaticContextAccessor>()._SetBloomDay(value); }
        }

        public bool Quit
        {
            get { return Cast<StaticContextAccessor>()._GetQuit(); }
            set { Cast<StaticContextAccessor>()._SetQuit(value); }
        }

        public bool IsChatting
        {
            get { return Cast<StaticContextAccessor>()._GetIsChatting(); }
            set { Cast<StaticContextAccessor>()._SetIsChatting(value); }
        }

        public bool GlobalFade
        {
            get { return Cast<StaticContextAccessor>()._GetGlobalFade(); }
            set { Cast<StaticContextAccessor>()._SetGlobalFade(value); }
        }

        public bool DrawGrid
        {
            get { return Cast<StaticContextAccessor>()._GetDrawGrid(); }
            set { Cast<StaticContextAccessor>()._SetDrawGrid(value); }
        }

        public bool FreezeControls
        {
            get { return Cast<StaticContextAccessor>()._GetFreezeControls(); }
            set { Cast<StaticContextAccessor>()._SetFreezeControls(value); }
        }

        public bool SaveOnNewDay
        {
            get { return Cast<StaticContextAccessor>()._GetSaveOnNewDay(); }
            set { Cast<StaticContextAccessor>()._SetSaveOnNewDay(value); }
        }

        public bool PanMode
        {
            get { return Cast<StaticContextAccessor>()._GetPanMode(); }
            set { Cast<StaticContextAccessor>()._SetPanMode(value); }
        }

        public bool ShowingEndOfNightStuff
        {
            get { return Cast<StaticContextAccessor>()._GetShowingEndOfNightStuff(); }
            set { Cast<StaticContextAccessor>()._SetShowingEndOfNightStuff(value); }
        }

        public bool WasRainingYesterday
        {
            get { return Cast<StaticContextAccessor>()._GetWasRainingYesterday(); }
            set { Cast<StaticContextAccessor>()._SetWasRainingYesterday(value); }
        }

        public bool HasLoadedGame
        {
            get { return Cast<StaticContextAccessor>()._GetHasLoadedGame(); }
            set { Cast<StaticContextAccessor>()._SetHasLoadedGame(value); }
        }

        public bool IsActionAtCurrentCursorTile
        {
            get { return Cast<StaticContextAccessor>()._GetIsActionAtCurrentCursorTile(); }
            set { Cast<StaticContextAccessor>()._SetIsActionAtCurrentCursorTile(value); }
        }

        public bool IsInspectionAtCurrentCursorTile
        {
            get { return Cast<StaticContextAccessor>()._GetIsInspectionAtCurrentCursorTile(); }
            set { Cast<StaticContextAccessor>()._SetIsInspectionAtCurrentCursorTile(value); }
        }

        public bool Paused
        {
            get { return Cast<StaticContextAccessor>()._GetPaused(); }
            set { Cast<StaticContextAccessor>()._SetPaused(value); }
        }

        public bool LastCursorMotionWasMouse
        {
            get { return Cast<StaticContextAccessor>()._GetLastCursorMotionWasMouse(); }
            set { Cast<StaticContextAccessor>()._SetLastCursorMotionWasMouse(value); }
        }

        public string CurrentSeason
        {
            get { return Cast<StaticContextAccessor>()._GetCurrentSeason(); }
            set { Cast<StaticContextAccessor>()._SetCurrentSeason(value); }
        }

        public string DebugOutput
        {
            get { return Cast<StaticContextAccessor>()._GetDebugOutput(); }
            set { Cast<StaticContextAccessor>()._SetDebugOutput(value); }
        }

        public string NextMusicTrack
        {
            get { return Cast<StaticContextAccessor>()._GetNextMusicTrack(); }
            set { Cast<StaticContextAccessor>()._SetNextMusicTrack(value); }
        }

        public string SelectedItemsType
        {
            get { return Cast<StaticContextAccessor>()._GetSelectedItemsType(); }
            set { Cast<StaticContextAccessor>()._SetSelectedItemsType(value); }
        }

        public string NameSelectType
        {
            get { return Cast<StaticContextAccessor>()._GetNameSelectType(); }
            set { Cast<StaticContextAccessor>()._SetNameSelectType(value); }
        }

        public string MessageAfterPause
        {
            get { return Cast<StaticContextAccessor>()._GetMessageAfterPause(); }
            set { Cast<StaticContextAccessor>()._SetMessageAfterPause(value); }
        }

        public string Fertilizer
        {
            get { return Cast<StaticContextAccessor>()._GetFertilizer(); }
            set { Cast<StaticContextAccessor>()._SetFertilizer(value); }
        }

        public string SamBandName
        {
            get { return Cast<StaticContextAccessor>()._GetSamBandName(); }
            set { Cast<StaticContextAccessor>()._SetSamBandName(value); }
        }

        public string ElliottBookName
        {
            get { return Cast<StaticContextAccessor>()._GetElliottBookName(); }
            set { Cast<StaticContextAccessor>()._SetElliottBookName(value); }
        }

        public string SlotResult
        {
            get { return Cast<StaticContextAccessor>()._GetSlotResult(); }
            set { Cast<StaticContextAccessor>()._SetSlotResult(value); }
        }

        public string KeyHelpString
        {
            get { return Cast<StaticContextAccessor>()._GetKeyHelpString(); }
            set { Cast<StaticContextAccessor>()._SetKeyHelpString(value); }
        }

        public string DebugInput
        {
            get { return Cast<StaticContextAccessor>()._GetDebugInput(); }
            set { Cast<StaticContextAccessor>()._SetDebugInput(value); }
        }

        public string LoadingMessage
        {
            get { return Cast<StaticContextAccessor>()._GetLoadingMessage(); }
            set { Cast<StaticContextAccessor>()._SetLoadingMessage(value); }
        }

        public string ErrorMessage
        {
            get { return Cast<StaticContextAccessor>()._GetErrorMessage(); }
            set { Cast<StaticContextAccessor>()._SetErrorMessage(value); }
        }

        public int XLocationAfterWarp
        {
            get { return Cast<StaticContextAccessor>()._GetXLocationAfterWarp(); }
            set { Cast<StaticContextAccessor>()._SetXLocationAfterWarp(value); }
        }

        public int YLocationAfterWarp
        {
            get { return Cast<StaticContextAccessor>()._GetYLocationAfterWarp(); }
            set { Cast<StaticContextAccessor>()._SetYLocationAfterWarp(value); }
        }

        public int GameTimeInterval
        {
            get { return Cast<StaticContextAccessor>()._GetGameTimeInterval(); }
            set { Cast<StaticContextAccessor>()._SetGameTimeInterval(value); }
        }

        public int CurrentQuestionChoice
        {
            get { return Cast<StaticContextAccessor>()._GetCurrentQuestionChoice(); }
            set { Cast<StaticContextAccessor>()._SetCurrentQuestionChoice(value); }
        }

        public int CurrentDialogueCharacterIndex
        {
            get { return Cast<StaticContextAccessor>()._GetCurrentDialogueCharacterIndex(); }
            set { Cast<StaticContextAccessor>()._SetCurrentDialogueCharacterIndex(value); }
        }

        public int DialogueTypingInterval
        {
            get { return Cast<StaticContextAccessor>()._GetDialogueTypingInterval(); }
            set { Cast<StaticContextAccessor>()._SetDialogueTypingInterval(value); }
        }

        public int DayOfMonth
        {
            get { return Cast<StaticContextAccessor>()._GetDayOfMonth(); }
            set { Cast<StaticContextAccessor>()._SetDayOfMonth(value); }
        }

        public int Year
        {
            get { return Cast<StaticContextAccessor>()._GetYear(); }
            set { Cast<StaticContextAccessor>()._SetYear(value); }
        }

        public int TimeOfDay
        {
            get { return Cast<StaticContextAccessor>()._GetTimeOfDay(); }
            set { Cast<StaticContextAccessor>()._SetTimeOfDay(value); }
        }

        public int NumberOfSelectedItems
        {
            get { return Cast<StaticContextAccessor>()._GetNumberOfSelectedItems(); }
            set { Cast<StaticContextAccessor>()._SetNumberOfSelectedItems(value); }
        }

        public int PriceOfSelectedItem
        {
            get { return Cast<StaticContextAccessor>()._GetPriceOfSelectedItem(); }
            set { Cast<StaticContextAccessor>()._SetPriceOfSelectedItem(value); }
        }

        public int CurrentWallpaper
        {
            get { return Cast<StaticContextAccessor>()._GetCurrentWallpaper(); }
            set { Cast<StaticContextAccessor>()._SetCurrentWallpaper(value); }
        }

        public int FarmerWallpaper
        {
            get { return Cast<StaticContextAccessor>()._GetFarmerWallpaper(); }
            set { Cast<StaticContextAccessor>()._SetFarmerWallpaper(value); }
        }

        public int WallpaperPrice
        {
            get { return Cast<StaticContextAccessor>()._GetWallpaperPrice(); }
            set { Cast<StaticContextAccessor>()._SetWallpaperPrice(value); }
        }

        public int CurrentFloor
        {
            get { return Cast<StaticContextAccessor>()._GetCurrentFloor(); }
            set { Cast<StaticContextAccessor>()._SetCurrentFloor(value); }
        }

        public int FarmerFloor
        {
            get { return Cast<StaticContextAccessor>()._GetFarmerFloor(); }
            set { Cast<StaticContextAccessor>()._SetFarmerFloor(value); }
        }

        public int FloorPrice
        {
            get { return Cast<StaticContextAccessor>()._GetFloorPrice(); }
            set { Cast<StaticContextAccessor>()._SetFloorPrice(value); }
        }

        public int DialogueWidth
        {
            get { return Cast<StaticContextAccessor>()._GetDialogueWidth(); }
            set { Cast<StaticContextAccessor>()._SetDialogueWidth(value); }
        }

        public int CountdownToWedding
        {
            get { return Cast<StaticContextAccessor>()._GetCountdownToWedding(); }
            set { Cast<StaticContextAccessor>()._SetCountdownToWedding(value); }
        }

        public int MenuChoice
        {
            get { return Cast<StaticContextAccessor>()._GetMenuChoice(); }
            set { Cast<StaticContextAccessor>()._SetMenuChoice(value); }
        }

        public int TvStation
        {
            get { return Cast<StaticContextAccessor>()._GetTvStation(); }
            set { Cast<StaticContextAccessor>()._SetTvStation(value); }
        }

        public int CurrentBillboard
        {
            get { return Cast<StaticContextAccessor>()._GetCurrentBillboard(); }
            set { Cast<StaticContextAccessor>()._SetCurrentBillboard(value); }
        }

        public int FacingDirectionAfterWarp
        {
            get { return Cast<StaticContextAccessor>()._GetFacingDirectionAfterWarp(); }
            set { Cast<StaticContextAccessor>()._SetFacingDirectionAfterWarp(value); }
        }

        public int TmpTimeOfDay
        {
            get { return Cast<StaticContextAccessor>()._GetTmpTimeOfDay(); }
            set { Cast<StaticContextAccessor>()._SetTmpTimeOfDay(value); }
        }

        public int PercentageToWinStardewHero
        {
            get { return Cast<StaticContextAccessor>()._GetPercentageToWinStardewHero(); }
            set { Cast<StaticContextAccessor>()._SetPercentageToWinStardewHero(value); }
        }

        public int MouseClickPolling
        {
            get { return Cast<StaticContextAccessor>()._GetMouseClickPolling(); }
            set { Cast<StaticContextAccessor>()._SetMouseClickPolling(value); }
        }

        public int WeatherIcon
        {
            get { return Cast<StaticContextAccessor>()._GetWeatherIcon(); }
            set { Cast<StaticContextAccessor>()._SetWeatherIcon(value); }
        }

        public int HitShakeTimer
        {
            get { return Cast<StaticContextAccessor>()._GetHitShakeTimer(); }
            set { Cast<StaticContextAccessor>()._SetHitShakeTimer(value); }
        }

        public int StaminaShakeTimer
        {
            get { return Cast<StaticContextAccessor>()._GetStaminaShakeTimer(); }
            set { Cast<StaticContextAccessor>()._SetStaminaShakeTimer(value); }
        }

        public int PauseThenDoFunctionTimer
        {
            get { return Cast<StaticContextAccessor>()._GetPauseThenDoFunctionTimer(); }
            set { Cast<StaticContextAccessor>()._SetPauseThenDoFunctionTimer(value); }
        }

        public int WeatherForTomorrow
        {
            get { return Cast<StaticContextAccessor>()._GetWeatherForTomorrow(); }
            set { Cast<StaticContextAccessor>()._SetWeatherForTomorrow(value); }
        }

        public int CurrentSongIndex
        {
            get { return Cast<StaticContextAccessor>()._GetCurrentSongIndex(); }
            set { Cast<StaticContextAccessor>()._SetCurrentSongIndex(value); }
        }

        public int CursorTileHintCheckTimer
        {
            get { return Cast<StaticContextAccessor>()._GetCursorTileHintCheckTimer(); }
            set { Cast<StaticContextAccessor>()._SetCursorTileHintCheckTimer(value); }
        }

        public int TimerUntilMouseFade
        {
            get { return Cast<StaticContextAccessor>()._GetTimerUntilMouseFade(); }
            set { Cast<StaticContextAccessor>()._SetTimerUntilMouseFade(value); }
        }

        public int MinecartHighScore
        {
            get { return Cast<StaticContextAccessor>()._GetMinecartHighScore(); }
            set { Cast<StaticContextAccessor>()._SetMinecartHighScore(value); }
        }

        public Color MorningColor
        {
            get { return Cast<StaticContextAccessor>()._GetMorningColor(); }
            set { Cast<StaticContextAccessor>()._SetMorningColor(value); }
        }

        public Color EveningColor
        {
            get { return Cast<StaticContextAccessor>()._GetEveningColor(); }
            set { Cast<StaticContextAccessor>()._SetEveningColor(value); }
        }

        public Color UnselectedOptionColor
        {
            get { return Cast<StaticContextAccessor>()._GetUnselectedOptionColor(); }
            set { Cast<StaticContextAccessor>()._SetUnselectedOptionColor(value); }
        }

        public Color ScreenGlowColor
        {
            get { return Cast<StaticContextAccessor>()._GetScreenGlowColor(); }
            set { Cast<StaticContextAccessor>()._SetScreenGlowColor(value); }
        }

        public NPC CurrentSpeaker
        {
            get
            {
                var tmp = Cast<StaticContextAccessor>()._GetCurrentSpeaker();
                if (tmp == null) return null;
                return new NPC(this, tmp);
            }
            set { Cast<StaticContextAccessor>()._SetCurrentSpeaker(value.Cast<NPCAccessor>()); }
        }

        public Random Random
        {
            get { return Cast<StaticContextAccessor>()._GetRandom(); }
            set { Cast<StaticContextAccessor>()._SetRandom(value); }
        }

        public Random RecentMultiplayerRandom
        {
            get { return Cast<StaticContextAccessor>()._GetRecentMultiplayerRandom(); }
            set { Cast<StaticContextAccessor>()._SetRecentMultiplayerRandom(value); }
        }

        public float MusicPlayerVolume
        {
            get { return Cast<StaticContextAccessor>()._GetMusicPlayerVolume(); }
            set { Cast<StaticContextAccessor>()._SetMusicPlayerVolume(value); }
        }

        public float PauseAccumulator
        {
            get { return Cast<StaticContextAccessor>()._GetPauseAccumulator(); }
            set { Cast<StaticContextAccessor>()._SetPauseAccumulator(value); }
        }

        public float PauseTime
        {
            get { return Cast<StaticContextAccessor>()._GetPauseTime(); }
            set { Cast<StaticContextAccessor>()._SetPauseTime(value); }
        }

        public float UpPolling
        {
            get { return Cast<StaticContextAccessor>()._GetUpPolling(); }
            set { Cast<StaticContextAccessor>()._SetUpPolling(value); }
        }

        public float DownPolling
        {
            get { return Cast<StaticContextAccessor>()._GetDownPolling(); }
            set { Cast<StaticContextAccessor>()._SetDownPolling(value); }
        }

        public float RightPolling
        {
            get { return Cast<StaticContextAccessor>()._GetRightPolling(); }
            set { Cast<StaticContextAccessor>()._SetRightPolling(value); }
        }

        public float LeftPolling
        {
            get { return Cast<StaticContextAccessor>()._GetLeftPolling(); }
            set { Cast<StaticContextAccessor>()._SetLeftPolling(value); }
        }

        public float DebrisSoundInterval
        {
            get { return Cast<StaticContextAccessor>()._GetDebrisSoundInterval(); }
            set { Cast<StaticContextAccessor>()._SetDebrisSoundInterval(value); }
        }

        public float ToolHold
        {
            get { return Cast<StaticContextAccessor>()._GetToolHold(); }
            set { Cast<StaticContextAccessor>()._SetToolHold(value); }
        }

        public float WindGust
        {
            get { return Cast<StaticContextAccessor>()._GetWindGust(); }
            set { Cast<StaticContextAccessor>()._SetWindGust(value); }
        }

        public float DialogueButtonScale
        {
            get { return Cast<StaticContextAccessor>()._GetDialogueButtonScale(); }
            set { Cast<StaticContextAccessor>()._SetDialogueButtonScale(value); }
        }

        public float CreditsTimer
        {
            get { return Cast<StaticContextAccessor>()._GetCreditsTimer(); }
            set { Cast<StaticContextAccessor>()._SetCreditsTimer(value); }
        }

        public float GlobalOutdoorLighting
        {
            get { return Cast<StaticContextAccessor>()._GetGlobalOutdoorLighting(); }
            set { Cast<StaticContextAccessor>()._SetGlobalOutdoorLighting(value); }
        }

        public PlayerIndex PlayerOneIndex
        {
            get { return Cast<StaticContextAccessor>()._GetPlayerOneIndex(); }
            set { Cast<StaticContextAccessor>()._SetPlayerOneIndex(value); }
        }

        public Vector2 Shiny
        {
            get { return Cast<StaticContextAccessor>()._GetShiny(); }
            set { Cast<StaticContextAccessor>()._SetShiny(value); }
        }

        public Vector2 PreviousViewportPosition
        {
            get { return Cast<StaticContextAccessor>()._GetPreviousViewportPosition(); }
            set { Cast<StaticContextAccessor>()._SetPreviousViewportPosition(value); }
        }

        public Vector2 CurrentCursorTile
        {
            get { return Cast<StaticContextAccessor>()._GetCurrentCursorTile(); }
            set { Cast<StaticContextAccessor>()._SetCurrentCursorTile(value); }
        }

        public Vector2 LastCursorTile
        {
            get { return Cast<StaticContextAccessor>()._GetLastCursorTile(); }
            set { Cast<StaticContextAccessor>()._SetLastCursorTile(value); }
        }

        public double ChanceToRainTomorrow
        {
            get { return Cast<StaticContextAccessor>()._GetChanceToRainTomorrow(); }
            set { Cast<StaticContextAccessor>()._SetChanceToRainTomorrow(value); }
        }

        public double DailyLuck
        {
            get { return Cast<StaticContextAccessor>()._GetDailyLuck(); }
            set { Cast<StaticContextAccessor>()._SetDailyLuck(value); }
        }

        public byte GameMode
        {
            get { return Cast<StaticContextAccessor>()._GetGameMode(); }
            set { Cast<StaticContextAccessor>()._SetGameMode(value); }
        }

        public byte MultiplayerMode
        {
            get { return Cast<StaticContextAccessor>()._GetMultiplayerMode(); }
            set { Cast<StaticContextAccessor>()._SetMultiplayerMode(value); }
        }

        public ulong UniqueIDForThisGame
        {
            get { return Cast<StaticContextAccessor>()._GetUniqueIDForThisGame(); }
            set { Cast<StaticContextAccessor>()._SetUniqueIDForThisGame(value); }
        }

        public int CropsOfTheWeek
        {
            get { return Cast<StaticContextAccessor>()._GetCropsOfTheWeek(); }
            set { Cast<StaticContextAccessor>()._SetCropsOfTheWeek(value); }
        }

        public Color AmbientLight
        {
            get { return Cast<StaticContextAccessor>()._GetAmbientLight(); }
            set { Cast<StaticContextAccessor>()._SetAmbientLight(value); }
        }

        public Color OutdoorLight
        {
            get { return Cast<StaticContextAccessor>()._GetOutdoorLight(); }
            set { Cast<StaticContextAccessor>()._SetOutdoorLight(value); }
        }

        public Color TextColor
        {
            get { return Cast<StaticContextAccessor>()._GetTextColor(); }
            set { Cast<StaticContextAccessor>()._SetTextColor(value); }
        }

        public Color TextShadowColor
        {
            get { return Cast<StaticContextAccessor>()._GetTextShadowColor(); }
            set { Cast<StaticContextAccessor>()._SetTextShadowColor(value); }
        }

        public ClickableMenu ActiveClickableMenu
        {
            get
            {
                var tmp = Cast<StaticContextAccessor>()._GetActiveClickableMenu();
                if (tmp == null) return null;
                return new ClickableMenu(this, tmp);
            }
            set { Cast<StaticContextAccessor>()._SetActiveClickableMenu(value?.Cast<ClickableMenuAccessor>()); }
        }

        public int FramesThisSecond
        {
            get { return Cast<StaticContextAccessor>()._GetFramesThisSecond(); }
            set { Cast<StaticContextAccessor>()._SetFramesThisSecond(value); }
        }

        public int SecondCounter
        {
            get { return Cast<StaticContextAccessor>()._GetSecondCounter(); }
            set { Cast<StaticContextAccessor>()._SetSecondCounter(value); }
        }

        public int Currentfps
        {
            get { return Cast<StaticContextAccessor>()._GetCurrentfps(); }
            set { Cast<StaticContextAccessor>()._SetCurrentfps(value); }
        }

        public ObjectItem DishOfTheDay
        {
            get
            {
                var tmp = Cast<StaticContextAccessor>()._GetDishOfTheDay();
                if (tmp == null) return null;
                return new ObjectItem(this, tmp);
            }
            set { Cast<StaticContextAccessor>()._SetDishOfTheDay(value?.Cast<ObjectAccessor>()); }
        }

        public GameTime CurrentGameTime
        {
            get { return Cast<StaticContextAccessor>()._GetCurrentGameTime(); }
            set { Cast<StaticContextAccessor>()._SetCurrentGameTime(value); }
        }

        public Stack EndOfNightMenus
        {
            get { return Cast<StaticContextAccessor>()._GetEndOfNightMenus(); }
            set { Cast<StaticContextAccessor>()._SetEndOfNightMenus(value); }
        }

        public Point LastMousePositionBeforeFade
        {
            get { return Cast<StaticContextAccessor>()._GetLastMousePositionBeforeFade(); }
            set { Cast<StaticContextAccessor>()._SetLastMousePositionBeforeFade(value); }
        }

        public Point ViewportCenter
        {
            get { return Cast<StaticContextAccessor>()._GetViewportCenter(); }
            set { Cast<StaticContextAccessor>()._SetViewportCenter(value); }
        }

        public Vector2 ViewportTarget
        {
            get { return Cast<StaticContextAccessor>()._GetViewportTarget(); }
            set { Cast<StaticContextAccessor>()._SetViewportTarget(value); }
        }

        public float ViewportSpeed
        {
            get { return Cast<StaticContextAccessor>()._GetViewportSpeed(); }
            set { Cast<StaticContextAccessor>()._SetViewportSpeed(value); }
        }

        public int ViewportHold
        {
            get { return Cast<StaticContextAccessor>()._GetViewportHold(); }
            set { Cast<StaticContextAccessor>()._SetViewportHold(value); }
        }

        public int ThumbstickPollingTimer
        {
            get { return Cast<StaticContextAccessor>()._GetThumbstickPollingTimer(); }
            set { Cast<StaticContextAccessor>()._SetThumbstickPollingTimer(value); }
        }

        public bool ToggleFullScreen
        {
            get { return Cast<StaticContextAccessor>()._GetToggleFullScreen(); }
            set { Cast<StaticContextAccessor>()._SetToggleFullScreen(value); }
        }

        public bool IsFullscreen
        {
            get { return Cast<StaticContextAccessor>()._GetIsFullscreen(); }
            set { Cast<StaticContextAccessor>()._SetIsFullscreen(value); }
        }

        public bool SetToWindowedMode
        {
            get { return Cast<StaticContextAccessor>()._GetSetToWindowedMode(); }
            set { Cast<StaticContextAccessor>()._SetSetToWindowedMode(value); }
        }

        public bool SetToFullscreen
        {
            get { return Cast<StaticContextAccessor>()._GetSetToFullscreen(); }
            set { Cast<StaticContextAccessor>()._SetSetToFullscreen(value); }
        }

        public string WhereIsTodaysFest
        {
            get { return Cast<StaticContextAccessor>()._GetWhereIsTodaysFest(); }
            set { Cast<StaticContextAccessor>()._SetWhereIsTodaysFest(value); }
        }

        public bool FarmerShouldPassOut
        {
            get { return Cast<StaticContextAccessor>()._GetFarmerShouldPassOut(); }
            set { Cast<StaticContextAccessor>()._SetFarmerShouldPassOut(value); }
        }

        public Vector2 CurrentViewportTarget
        {
            get { return Cast<StaticContextAccessor>()._GetCurrentViewportTarget(); }
            set { Cast<StaticContextAccessor>()._SetCurrentViewportTarget(value); }
        }

        public Vector2 ViewportPositionLerp
        {
            get { return Cast<StaticContextAccessor>()._GetViewportPositionLerp(); }
            set { Cast<StaticContextAccessor>()._SetViewportPositionLerp(value); }
        }

        public float ScreenGlowRate
        {
            get { return Cast<StaticContextAccessor>()._GetScreenGlowRate(); }
            set { Cast<StaticContextAccessor>()._SetScreenGlowRate(value); }
        }

        public float ScreenGlowMax
        {
            get { return Cast<StaticContextAccessor>()._GetScreenGlowMax(); }
            set { Cast<StaticContextAccessor>()._SetScreenGlowMax(value); }
        }

        public bool HaltAfterCheck
        {
            get { return Cast<StaticContextAccessor>()._GetHaltAfterCheck(); }
            set { Cast<StaticContextAccessor>()._SetHaltAfterCheck(value); }
        }

        public string PanModeString
        {
            get { return Cast<StaticContextAccessor>()._GetPanModeString(); }
            set { Cast<StaticContextAccessor>()._SetPanModeString(value); }
        }

        public bool PanFacingDirectionWait
        {
            get { return Cast<StaticContextAccessor>()._GetPanFacingDirectionWait(); }
            set { Cast<StaticContextAccessor>()._SetPanFacingDirectionWait(value); }
        }

        public int ThumbstickMotionMargin
        {
            get { return Cast<StaticContextAccessor>()._GetThumbstickMotionMargin(); }
            set { Cast<StaticContextAccessor>()._SetThumbstickMotionMargin(value); }
        }

        public int TriggerPolling
        {
            get { return Cast<StaticContextAccessor>()._GetTriggerPolling(); }
            set { Cast<StaticContextAccessor>()._SetTriggerPolling(value); }
        }

        public int RightClickPolling
        {
            get { return Cast<StaticContextAccessor>()._GetRightClickPolling(); }
            set { Cast<StaticContextAccessor>()._SetRightClickPolling(value); }
        }

        public Matrix ScaleMatrix
        {
            get { return Cast<StaticContextAccessor>()._GetScaleMatrix(); }
            set { Cast<StaticContextAccessor>()._SetScaleMatrix(value); }
        }

        public Color BgColor
        {
            get { return Cast<StaticContextAccessor>()._GetBgColor(); }
            set { Cast<StaticContextAccessor>()._SetBgColor(value); }
        }

        public int MouseCursor
        {
            get { return Cast<StaticContextAccessor>()._GetMouseCursor(); }
            set { Cast<StaticContextAccessor>()._SetMouseCursor(value); }
        }

        public float MouseCursorTransparency
        {
            get { return Cast<StaticContextAccessor>()._GetMouseCursorTransparency(); }
            set { Cast<StaticContextAccessor>()._SetMouseCursorTransparency(value); }
        }

        public IDictionary ObjectInformation
        {
            get { return Cast<StaticContextAccessor>()._GetObjectInformation(); }
        }

        public NPC ObjectDialoguePortraitPerson
        {
            get
            {
                var tmp = Cast<StaticContextAccessor>()._GetObjectDialoguePortraitPerson();
                if (tmp == null) return null;
                return new NPC(this, tmp);
            }
            set { Cast<StaticContextAccessor>()._SetObjectDialoguePortraitPerson(value.Cast<NPCAccessor>()); }
        }

        public ChatBox ChatBox
        {
            get
            {
                foreach (var menu in Cast<StaticContextAccessor>()._GetOnScreenMenus())
                {
                    if (menu is ChatBoxAccessor)
                    {
                        return new ChatBox(this, (ChatBoxAccessor)menu);
                    }
                }
                return null;
            }
        }

        public WrappedProxyList<ClickableMenuAccessor, ClickableMenu> OnScreenMenus
        {
            get
            {
                var tmp = Cast<StaticContextAccessor>()._GetOnScreenMenus();
                if (tmp == null) return null;
                return new WrappedProxyList<ClickableMenuAccessor, ClickableMenu>(tmp, i => new ClickableMenu(this, i));
            }
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

        /// <summary>
        /// Draws bolded text at the specified location.
        /// </summary>
        public void DrawBoldText(SpriteBatch b, string text, SpriteFont font, Vector2 position, Color color, float scale = 1f, float layerDepth = -1f, int boldnessOffset = 1)
        {
            Cast<StaticContextAccessor>()._DrawBoldText(b, text, font, position, color, scale, layerDepth, boldnessOffset);
        }

        /// <summary>
        /// Draws a texture at the specified location with a shadow.
        /// </summary>
        public void DrawWithShadow(SpriteBatch b, Texture2D texture, Vector2 position, Microsoft.Xna.Framework.Rectangle sourceRect, Color color, float rotation, Vector2 origin, float scale = -1f, bool flipped = false, float layerDepth = -1f, int horizontalShadowOffset = -1, int verticalShadowOffset = -1, float shadowIntensity = 0.35f)
        {
            Cast<StaticContextAccessor>()._DrawWithShadow(b, texture, position, sourceRect, color, rotation, origin, scale, flipped, layerDepth, horizontalShadowOffset, verticalShadowOffset, shadowIntensity);
        }

        /// <summary>
        /// Draws text with a shadow underlayed at the specified location.
        /// </summary>
        public void DrawTextWithShadow(SpriteBatch b, string text, SpriteFont font, Vector2 position, Color color, float scale = 1f, float layerDepth = -1f, int horizontalShadowOffset = -1, int verticalShadowOffset = -1, float shadowIntensity = 1f, int numShadows = 3)
        {
            Cast<StaticContextAccessor>()._DrawTextWithShadow(b, text, font, position, color, scale, layerDepth, horizontalShadowOffset, verticalShadowOffset, shadowIntensity, numShadows);
        }

        /// <summary>
        /// Draws hovered text at the specified relative offset to the mouse cursor.
        /// Position can be overridden with overrideX and overrideY
        /// </summary>
        public void DrawHoverText(SpriteBatch b, string text, SpriteFont font, int xOffset = 0, int yOffset = 0, int moneyAmountToDisplayAtBottom = -1, string boldTitleText = null, int healAmountToDisplay = -1, string[] buffIconsToDisplay = null, ItemAccessor hoveredItem = null, int currencySymbol = 0, int extraItemToShowIndex = -1, int extraItemToShowAmount = -1, int overrideX = -1, int overrideY = -1, float alpha = 1f, CraftingRecipeAccessor craftingIngredients = null)
        {
            Cast<StaticContextAccessor>()._DrawHoverText(b, text, font, xOffset, yOffset, moneyAmountToDisplayAtBottom, boldTitleText, healAmountToDisplay, buffIconsToDisplay, hoveredItem, currencySymbol, extraItemToShowIndex, extraItemToShowAmount, overrideX, overrideY, alpha, craftingIngredients);
        }

        public ProxyList<ObjectItem> PurchaseAnimalStock
        {
            get
            {
                var tmp = Cast<StaticContextAccessor>()._GetPurchaseAnimalStock();
                if (tmp == null) return null;
                return new ProxyList<ObjectItem>(tmp);
            }
        }

    }
}