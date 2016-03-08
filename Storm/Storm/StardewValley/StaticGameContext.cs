/*
    Copyright 2016 Cody R. (Demmonic), Zoey (Zoryn), Matt Stevens (Handsome Matt)

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
using System.Reflection;
using Microsoft.Xna.Framework.Input;
using Storm.ExternalEvent;
using Storm.Manipulation;
using Storm.StardewValley.Accessor;
using Storm.StardewValley.Event;
using Storm.StardewValley.Event.Crop;
using Storm.StardewValley.Event.Farmer;
using Storm.StardewValley.Event.Game;
using Storm.StardewValley.Wrapper;
using Object = Storm.StardewValley.Wrapper.Object;
using Storm.StardewValley.Proxy;
using Storm.StardewValley.Event.HoeDirt;
using Microsoft.Xna.Framework;

namespace Storm.StardewValley
{
    public static class StaticGameContext
    {
        /// <summary>
        ///     The Stardew Valley assembly
        /// </summary>
        public static Assembly Assembly { get; set; }

        /// <summary>
        ///     Wrapped Stardew Valley Program class.
        /// </summary>
        public static ProgramAccessor Root { get; set; }

        /// <summary>
        ///     The Type of the Tool class within the game, cached here so we can proxy it later
        /// </summary>
        public static Type ToolType { get; set; }
        public static InterceptorFactory<ToolDelegate> ToolFactory { get; set; }

        /// <summary>
        ///     The Type of the Object class within the game, cached here so we can proxy it later
        /// </summary>
        public static Type ObjectType { get; set; }
        public static InterceptorFactory<ObjectDelegate> ObjectFactory { get; set; }

        public static Type TextureComponentType { get; set; }
        public static InterceptorFactory<TextureComponentDelegate> TextureComponentFactory { get; set; }

        /// <summary>
        ///     Event handler for all Storm mods.
        /// </summary>
        public static ModEventBus EventBus { get; set; }

        /// <summary>
        ///     Wrapped Stardew Valley Game class.
        /// </summary>
        public static StaticContext WrappedGame
        {
            get { return new StaticContext(Root._GetGame()); }
        }

        #region Game1 Events

        public static DetourEvent InitializeCallback(StaticContextAccessor context)
        {
            WrappedGame.Version += ", " + AssemblyInfo.NICE_VERSION;
            WrappedGame.Version += ", mods loaded: " + EventBus.mods.Count;
            WrappedGame.Window.Title = "Stardew Valley - Version " + WrappedGame.Version;

            Logging.DebugLog("Game Initialized");

            var @event = new InitializeEvent();
            EventBus.Fire(@event);
            return @event;
        }

        public static DetourEvent LoadContentCallback(StaticContextAccessor context)
        {
            var @event = new LoadContentEvent();
            EventBus.Fire(@event);
            return @event;
        }

        public static DetourEvent UnloadContentCallback(StaticContextAccessor context)
        {
            var @event = new UnloadContentEvent();
            EventBus.Fire(@event);
            return @event;
        }

        public static DetourEvent PreDrawCallback(StaticContextAccessor context)
        {
            var @event = new PreRenderEvent();
            EventBus.Fire(@event);
            return @event;
        }

        public static DetourEvent PreUIDrawCallback(StaticContextAccessor context)
        {
            var @event = new PreUIRenderEvent();
            EventBus.Fire(@event);
            return @event;
        }

        public static DetourEvent PostDrawCallback(StaticContextAccessor context)
        {
            var batch = context._GetSpriteBatch();
            batch.Begin();

            var @event = new PostRenderEvent();
            EventBus.Fire(@event);

            batch.End();
            return @event;
        }

        public static DetourEvent SeasonChangeCallback()
        {
            var @event = new SeasonChangeEvent();
            EventBus.Fire(@event);
            return @event;
        }

        public static DetourEvent NewDayCallback()
        {
            var @event = new NewDayEvent();
            EventBus.Fire(@event);
            return @event;
        }

        public static DetourEvent Before10MinuteClockUpdateCallback()
        {
            var @event = new Before10MinuteClockUpdateEvent();
            EventBus.Fire(@event);
            return @event;
        }

        public static DetourEvent After10MinuteClockUpdateCallback()
        {
            var @event = new After10MinuteClockUpdateEvent();
            EventBus.Fire(@event);
            return @event;
        }

        public static DetourEvent UpdateGameClockCallback()
        {
            var @event = new UpdateGameClockEvent();
            EventBus.Fire(@event);
            return @event;
        }

        public static DetourEvent SellShippedItemsCallback()
        {
            var @event = new SellShippedItemsEvent();
            EventBus.Fire(@event);
            return @event;
        }

        public static DetourEvent AddItemToInventoryCallback(FarmerAccessor farmer, ItemAccessor item)
        {
            var @event = new AddItemToInventoryEvent(new Farmer(WrappedGame, farmer), new Item(WrappedGame, item));
            EventBus.Fire(@event);
            return @event;
        }

        public static DetourEvent PreUpdateCallback(StaticContextAccessor accessor)
        {
            var @event = new PreUpdateEvent();
            EventBus.Fire(@event);
            return @event;
        }

        private static KeyboardState oldKeyboardState = new KeyboardState();
        private static MouseState oldMouseState = new MouseState();
        private static GamePadState oldGamepadState = new GamePadState();

        public static DetourEvent PostUpdateCallback(StaticContextAccessor accessor)
        {
            var keyboardState = Keyboard.GetState();
            var mouseState = Mouse.GetState();
            var gamepadState = GamePad.GetState(Microsoft.Xna.Framework.PlayerIndex.One);

            /* keyboard events */

            foreach (Keys key in keyboardState.GetPressedKeys())
                if (!oldKeyboardState.IsKeyDown(key))
                    EventBus.Fire(new KeyPressedEvent(key));

            foreach (Keys key in oldKeyboardState.GetPressedKeys())
                if (!keyboardState.IsKeyDown(key))
                    EventBus.Fire(new KeyReleasedEvent(key));

            /* probably a way to template this, but whatever, mouse events */

            if (mouseState.LeftButton == ButtonState.Pressed && oldMouseState.LeftButton == ButtonState.Released)
                EventBus.Fire(new MouseButtonPressedEvent(MouseButtonPressedEvent.MouseButton.Left));
            if (mouseState.LeftButton == ButtonState.Released && oldMouseState.LeftButton == ButtonState.Pressed)
                EventBus.Fire(new MouseButtonReleasedEvent(MouseButtonReleasedEvent.MouseButton.Left));

            if (mouseState.MiddleButton == ButtonState.Pressed && oldMouseState.MiddleButton == ButtonState.Released)
                EventBus.Fire(new MouseButtonPressedEvent(MouseButtonPressedEvent.MouseButton.Middle));
            if (mouseState.MiddleButton == ButtonState.Released && oldMouseState.MiddleButton == ButtonState.Pressed)
                EventBus.Fire(new MouseButtonReleasedEvent(MouseButtonReleasedEvent.MouseButton.Middle));

            if (mouseState.RightButton == ButtonState.Pressed && oldMouseState.RightButton == ButtonState.Released)
                EventBus.Fire(new MouseButtonPressedEvent(MouseButtonPressedEvent.MouseButton.Right));
            if (mouseState.RightButton == ButtonState.Released && oldMouseState.RightButton == ButtonState.Pressed)
                EventBus.Fire(new MouseButtonReleasedEvent(MouseButtonReleasedEvent.MouseButton.Right));

            /* todo: gamepad events */

            oldKeyboardState = keyboardState;
            oldMouseState = mouseState;
            oldGamepadState = gamepadState;

            var @event = new PostUpdateEvent();
            EventBus.Fire(@event);
            return @event;
        }

        public static DetourEvent PressUseToolButtonCallback()
        {
            var @event = new PressUseToolButtonEvent();
            EventBus.Fire(@event);
            return @event;
        }

        public static DetourEvent PressActionButtonCallback()
        {
            var @event = new PressActionButtonEvent();
            EventBus.Fire(@event);
            return @event;
        }

        public static DetourEvent PrepareSpouseForWeddingCallback()
        {
            var @event = new PrepareSpouseForWeddingEvent();
            EventBus.Fire(@event);
            return @event;
        }

        public static DetourEvent PlayMorningSongCallback()
        {
            var @event = new PlayMorningSongEvent();
            EventBus.Fire(@event);
            return @event;
        }

        public static DetourEvent FarmerTakeDamageCallback(int damage, bool overrideParry, MonsterAccessor damager)
        {
            var @event = new FarmerDamageEvent(damage, overrideParry, new Monster(WrappedGame, damager));
            EventBus.Fire(@event);
            return @event;
        }

        public static DetourEvent BeforeGameLoadedCallback(bool loadedGame)
        {
            var @event = new GameLoadedEvent(loadedGame);
            EventBus.Fire(@event);
            return @event;
        }

        public static DetourEvent AfterGameLoadedCallback(bool loadedGame)
        {
            var @event = new GameLoadedEvent(loadedGame);
            EventBus.Fire(@event);
            return @event;
        }

        public static DetourEvent ShowEndOfNightStuffCallback()
        {
            var @event = new ShowEndOfNightStuffEvent();
            EventBus.Fire(@event);
            return @event;
        }

        public static DetourEvent TryToBuySelectedItemsCallback()
        {
            var @event = new TryToBuySelectedItemsEvent();
            EventBus.Fire(@event);
            return @event;
        }

        public static DetourEvent UpdateMusicCallback()
        {
            var @event = new UpdateMusicEvent();
            EventBus.Fire(@event);
            return @event;
        }

        public static DetourEvent UpdateTitleScreenCallback(StaticContextAccessor context)
        {
            var @event = new UpdateTitleScreenEvent(context);
            EventBus.Fire(@event);
            return @event;
        }

        public static DetourEvent ShowRedMessageCallback(string message)
        {
            var @event = new ShowRedMessageEvent(message);
            EventBus.Fire(@event);
            return @event;
        }

        public static DetourEvent ShowGlobalMessageCallback(string message)
        {
            var @event = new ShowGlobalMessageEvent(message);
            EventBus.Fire(@event);
            return @event;
        }

        public static DetourEvent GameExitEventCallback(StaticContextAccessor context)
        {
            var @event = new GameExitEvent(context);
            EventBus.Fire(@event);
            return @event;
        }

        public static DetourEvent ClientSizeChangedCallback(StaticContextAccessor context)
        {
            var @event = new ClientSizeChangedEvent(context);
            EventBus.Fire(@event);
            return @event;
        }

        public static DetourEvent PressAddItemToInventoryButtonCallback()
        {
            var @event = new PressAddItemToInventoryButtonEvent();
            EventBus.Fire(@event);
            return @event;
        }

        public static DetourEvent PlayerEatObjectCallback(ObjectAccessor o, bool overrideFullness)
        {
            var @event = new PlayerEatObjectEvent(new Object(WrappedGame, o), overrideFullness);
            EventBus.Fire(@event);
            return @event;
        }

        public static DetourEvent PressSwitchToolButtonCallback()
        {
            var @event = new PressSwitchToolButtonEvent();
            EventBus.Fire(@event);
            return @event;
        }

        public static DetourEvent ReleaseUseToolButtonCallback()
        {
            var @event = new ReleaseUseToolButtonEvent();
            EventBus.Fire(@event);
            return @event;
        }

        public static DetourEvent ShouldTimePassCallback()
        {
            var @event = new ShouldTimePassEvent();
            EventBus.Fire(@event);
            return @event;
        }

        public static DetourEvent IsDarkOutCallback()
        {
            var @event = new IsDarkOutEvent();
            EventBus.Fire(@event);
            return @event;
        }

        public static DetourEvent ShipObjectCallback(ObjectAccessor accessor)
        {
            var @event = new ShipObjectEvent(new Object(WrappedGame, accessor));
            EventBus.Fire(@event);
            return @event;
        }

        #endregion

        #region Farmer Events

        public static DetourEvent WarpFarmerCallback(GameLocationAccessor location, int tileX, int tileY, int facingDirection, bool isStructure)
        {
            var @event = new WarpFarmerEvent(new GameLocation(WrappedGame, location), tileX, tileY, facingDirection, isStructure);
            EventBus.Fire(@event);
            return @event;
        }

        public static DetourEvent AfterFarmerShippedBasicCallback(FarmerAccessor accessor, int index,int number)
        {
            var @event = new AfterFarmerShippedBasicEvent(index, number);
            EventBus.Fire(@event);
            return @event;
        }

        public static DetourEvent AfterFarmerCaughtFishCallback(FarmerAccessor accessor, int index, int size)
        {
            var @event = new AfterFarmerCaughtFishEvent(index, size);
            EventBus.Fire(@event);
            return @event;
        }

        public static DetourEvent AfterFarmerFoundArtifactCallback(FarmerAccessor accessor, int index, int number)
        {
            var @event = new AfterFarmerCaughtFishEvent(index, number);
            EventBus.Fire(@event);
            return @event;
        }

        public static DetourEvent AfterFarmerCookedRecipeCallback(FarmerAccessor accessor, int index)
        {
            var @event = new AfterFarmerCookedRecipeEvent(index);
            EventBus.Fire(@event);
            return @event;
        }

        public static DetourEvent FarmerGainedExperienceCallback(FarmerAccessor accessor, int which, int howMuch)
        {
            var @event = new FarmerGainedExperienceEvent(which, howMuch);
            EventBus.Fire(@event);
            return @event;
        }

        public static DetourEvent AfterFarmerFoundMineralCallback(FarmerAccessor accessor, int index)
        {
            var @event = new AfterFarmerFoundMineralEvent(index);
            EventBus.Fire(@event);
            return @event;
        }

        public static DetourEvent AfterFarmerConsumeObjectCallback(FarmerAccessor accessor, int index, int quantity)
        {
            var @event = new AfterFarmerConsumObjectEvent(index, quantity);
            EventBus.Fire(@event);
            return @event;
        }

        public static DetourEvent FarmerIncreaseBackpackSizeCallback(FarmerAccessor accessor, int howMuch)
        {
            var @event = new Event.Farmer.FarmerIncreaseBackpackSizeEvent(howMuch);
            EventBus.Fire(@event);
            return @event;
        }

        public static DetourEvent AfterFarmerDismountHorseCallback(FarmerAccessor accessor)
        {
            var @event = new Event.Farmer.AfterFarmerDismountHorseEvent();
            EventBus.Fire(@event);
            return @event;
        }

        #endregion

        #region Crop Events

        public static DetourEvent CompleteGrowthCallback(CropAccessor accessor)
        {
            var @event = new CropCompleteGrowthEvent(new Crop(WrappedGame, accessor));
            EventBus.Fire(@event);
            return @event;
        }

        public static DetourEvent BeforeHarvestCropCallback(CropAccessor accessor)
        {
            var @event = new BeforeHarvestCropEvent(new Crop(WrappedGame, accessor));
            EventBus.Fire(@event);
            return @event;
        }

        public static DetourEvent AfterHarvestCropCallback(CropAccessor accessor)
        {
            var @event = new AfterHarvestCropEvent(new Crop(WrappedGame, accessor));
            EventBus.Fire(@event);
            return @event;
        }

        #endregion

        #region HoeDirt Events

        public static DetourEvent BeforeDayUpdateHoeDirtCallback(HoeDirtAccessor hoedirt, GameLocationAccessor locationaccessor, Vector2 tileLocation)
        {
            var @event = new BeforeDayUpdateHoeDirtEvent(new GameLocation(WrappedGame, locationaccessor), tileLocation);
            EventBus.Fire(@event);
            return @event;
        }

        public static DetourEvent AfterDayUpdateHoeDirtCallback(HoeDirtAccessor hoedirt, GameLocationAccessor locationaccessor, Vector2 tileLocation)
        {
            var @event = new AfterDayUpdateHoeDirtEvent(new GameLocation(WrappedGame, locationaccessor), tileLocation);
            EventBus.Fire(@event);
            return @event;
        }

        #endregion

        #region Objects

        #endregion
    }
}