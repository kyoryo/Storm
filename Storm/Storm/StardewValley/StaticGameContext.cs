/*
    Copyright 2016 Cody R. (Demmonic), Zoey (Zoryn), Matt Stevens (Handsome Matt), Matthew Bell (mdbell), Inari-Whitebear

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
using System.Reflection;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Storm.ExternalEvent;
using Storm.Manipulation;
using Storm.StardewValley.Accessor;
using Storm.StardewValley.Event;
using Storm.StardewValley.Proxy;
using Storm.StardewValley.Wrapper;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Storm.Collections;
using System.Collections.Generic;
using Castle.DynamicProxy;

namespace Storm.StardewValley
{
    public static class StaticGameContext
    {
        private static Assembly Assembly { get; set; }

        private static ProgramAccessor Root { get; set; }

        private static ModEventBus EventBus { get; set; }

        private static List<Injector> Injectors;
        private static Dictionary<Type, object> CachedFactories = new Dictionary<Type, object>();

        private static KeyboardState oldKeyboardState = new KeyboardState();
        private static MouseState oldMouseState;
        private static GamePadState oldGamepadState;

        private static StaticContext WrappedGame
        {
            get { return new StaticContext(Root._GetGame()); }
        }

        public static void Init(
            Assembly assembly, ProgramAccessor root, ModEventBus eventBus, List<Injector> injectors)
        {
            Assembly = assembly;
            Root = root;
            EventBus = eventBus;
            Injectors = injectors;
        }

        private static void InitializeEvent(StaticContextEvent @event)
        {
            @event.GameAssembly = Assembly;
            @event.Root = WrappedGame;
            @event.EventBus = EventBus;
        }

        public static InterceptorFactory<DType> CreateFactory<AType, DType>()
        {
            if (CachedFactories.ContainsKey(typeof(DType)))
            {
                return (InterceptorFactory<DType>)CachedFactories[typeof(DType)];
            }
            var factory = new MappedInterceptorFactory<DType>();
            factory.Map(typeof(AType), typeof(DType), Injectors);
            CachedFactories.Add(typeof(DType), factory);
            return factory;
        }

        public static AType ProxyAccessor<AType, DType>(DType @delegate, params object[] constructor)
        {
            var type = InjectorMetaData.AccessorToGameType<AType>(Injectors, Assembly);
            var factory = CreateFactory<AType, DType>();

            var generator = new ProxyGenerator();
            return (AType)generator.CreateClassProxy(type, constructor, factory.CreateInterceptor(@delegate));
        }

        public static AType ProxyAccessor<AType, DType>(DType @delegate)
        {
            return ProxyAccessor<AType, DType>(@delegate, new object[0]);
        }

        private static void CheckAccessRights()
        {
            // make calls to this in all properties if someone tries to bypass
            // private access

            // if (did not originate from this class)
            //  throw new Exception("Invalid access rights!");
        }

        private static T HookEvent<T>(T @event) where T : DetourEvent
        {
            if (@event is StaticContextEvent)
            {
                (@event as StaticContextEvent).Init(InitializeEvent);
            }
            return @event;
        }

        private static void FireEvent<T>(T @event) where T : DetourEvent
        {
            HookEvent(@event);
            EventBus.Fire(@event);
        }

        #region ContentManager Events

        public static DetourEvent ContentLoadCallback(ContentManager manager, Type assetType, string assetName)
        {
            var @event = new AssetLoadEvent(manager, assetType, assetName);
            HookEvent(@event);
            @event.ReturnValue = EventBus.MapContent(@event);
            //this workaround gives mods priority over manifest resources
            EventBus.Fire(@event);
            //FireEvent(@event);
            return @event;
        }

        public static DetourEvent ManagerUnloadCallback(ContentManager manager)
        {
            var @event = new ManagerUnloadEvent(manager);
            FireEvent(@event);
            return @event;
        }

        #endregion

        #region Chatbox

        public static DetourEvent ChatboxTextEnteredCallback(ChatBoxAccessor accessor, TextBoxAccessor textbox)
        {
            var @event = new ChatMessageEnteredEvent(textbox._GetText());

            // just echo back for now, idk why
            @event.Root.ChatBox.ReceiveChatMessage(@event.ChatText, -1L);
            FireEvent(@event);
            return @event;
        }

        #endregion

        #region Game1 Events

        public static DetourEvent InitializeCallback(StaticContextAccessor accesor)
        {
            WrappedGame.Version += ", " + AssemblyInfo.NICE_VERSION;
            WrappedGame.Version += ", mods loaded: " + EventBus.mods.Count;
            WrappedGame.Window.Title = "Stardew Valley - Version " + WrappedGame.Version;

            Logging.DebugLog("Game Initialized");

            var @event = new InitializeEvent();
            FireEvent(@event);
            return @event;
        }

        public static DetourEvent LoadContentCallback(StaticContextAccessor accessor)
        {
            var @event = new LoadContentEvent();
            FireEvent(@event);
            return @event;
        }

        public static DetourEvent UnloadContentCallback(StaticContextAccessor accessor)
        {
            var @event = new UnloadContentEvent();
            FireEvent(@event);
            return @event;
        }

        public static DetourEvent PreDrawCallback(StaticContextAccessor accessor)
        {
            var @event = new PreRenderEvent();
            FireEvent(@event);
            return @event;
        }

        public static DetourEvent PreUIDrawCallback(StaticContextAccessor accessor)
        {
            var @event = new PreUIRenderEvent();
            FireEvent(@event);
            return @event;
        }

        public static DetourEvent PostDrawCallback(StaticContextAccessor accessor)
        {
            var batch = accessor._GetSpriteBatch();
            batch.Begin();

            var @event = new PostRenderEvent();
            FireEvent(@event);

            batch.End();
            return @event;
        }

        public static DetourEvent SeasonChangeCallback()
        {
            var @event = new SeasonChangeEvent();
            FireEvent(@event);
            return @event;
        }

        public static DetourEvent PreNewDayCallback()
        {
            var @event = new PreNewDayEvent();
            FireEvent(@event);
            return @event;
        }

        public static DetourEvent PostNewDayCallback()
        {
            var @event = new PostNewDayEvent();
            FireEvent(@event);
            return @event;
        }

        public static DetourEvent Pre10MinuteClockUpdateCallback()
        {
            var @event = new Pre10MinuteClockUpdateEvent();
            FireEvent(@event);
            return @event;
        }

        public static DetourEvent Post10MinuteClockUpdateCallback()
        {
            var @event = new Post10MinuteClockUpdateEvent();
            FireEvent(@event);
            return @event;
        }

        public static DetourEvent UpdateGameClockCallback()
        {
            var @event = new UpdateGameClockEvent();
            FireEvent(@event);
            return @event;
        }

        public static DetourEvent SellShippedItemsCallback()
        {
            var @event = new SellShippedItemsEvent();
            FireEvent(@event);
            return @event;
        }

        public static DetourEvent AddItemToInventoryCallback(FarmerAccessor farmer, ItemAccessor item)
        {
            var @event = new AddItemToInventoryEvent(
                new Farmer(WrappedGame, farmer), 
                item == null ? null : new Item(WrappedGame, item));

            FireEvent(@event);
            return @event;
        }

        public static DetourEvent AddItemToChestCallback(ItemAccessor item)
        {
            var @event = new AddItemToChestEvent(
                item == null ? null : new Item(WrappedGame, item));
            FireEvent(@event);
            return @event;
        }

        public static DetourEvent PreUpdateCallback(StaticContextAccessor accessor)
        {
            var @event = new PreUpdateEvent();
            FireEvent(@event);
            return @event;
        }

        public static DetourEvent PostUpdateCallback(StaticContextAccessor accessor)
        {
            var keyboardState = Keyboard.GetState();
            var mouseState = Mouse.GetState();
            var gamepadState = GamePad.GetState(PlayerIndex.One);

            /* keyboard events */

            foreach (var key in keyboardState.GetPressedKeys())
                if (!oldKeyboardState.IsKeyDown(key))
                    FireEvent(new KeyPressedEvent(key));

            foreach (var key in oldKeyboardState.GetPressedKeys())
                if (!keyboardState.IsKeyDown(key))
                    FireEvent(new KeyReleasedEvent(key));

            /* probably a way to template this, but whatever, mouse events */

            if (mouseState.LeftButton == ButtonState.Pressed && oldMouseState.LeftButton == ButtonState.Released)
                FireEvent(new MouseButtonPressedEvent(MouseButtonPressedEvent.MouseButton.Left, mouseState));
            if (mouseState.LeftButton == ButtonState.Released && oldMouseState.LeftButton == ButtonState.Pressed)
                FireEvent(new MouseButtonReleasedEvent(MouseButtonReleasedEvent.MouseButton.Left, mouseState));

            if (mouseState.MiddleButton == ButtonState.Pressed && oldMouseState.MiddleButton == ButtonState.Released)
                FireEvent(new MouseButtonPressedEvent(MouseButtonPressedEvent.MouseButton.Middle, mouseState));
            if (mouseState.MiddleButton == ButtonState.Released && oldMouseState.MiddleButton == ButtonState.Pressed)
                FireEvent(new MouseButtonReleasedEvent(MouseButtonReleasedEvent.MouseButton.Middle, mouseState));

            if (mouseState.RightButton == ButtonState.Pressed && oldMouseState.RightButton == ButtonState.Released)
                FireEvent(new MouseButtonPressedEvent(MouseButtonPressedEvent.MouseButton.Right, mouseState));
            if (mouseState.RightButton == ButtonState.Released && oldMouseState.RightButton == ButtonState.Pressed)
                FireEvent(new MouseButtonReleasedEvent(MouseButtonReleasedEvent.MouseButton.Right, mouseState));

            /* gamepad events */

            foreach (Buttons button in Enum.GetValues(typeof(Buttons)))
            {
                if (gamepadState.IsButtonDown(button) && oldGamepadState.IsButtonUp(button))
                    FireEvent(new GamepadButtonPressedEvent(button));
                if (gamepadState.IsButtonUp(button) && oldGamepadState.IsButtonDown(button))
                    FireEvent(new GamepadButtonReleasedEvent(button));
            }


            oldKeyboardState = keyboardState;
            oldMouseState = mouseState;
            oldGamepadState = gamepadState;

            var @event = new PostUpdateEvent();
            FireEvent(@event);
            return @event;
        }

        public static DetourEvent PressUseToolButtonCallback()
        {
            var @event = new PressUseToolButtonEvent();
            FireEvent(@event);
            return @event;
        }

        public static DetourEvent PressActionButtonCallback()
        {
            var @event = new PressActionButtonEvent();
            FireEvent(@event);
            return @event;
        }

        public static DetourEvent PrepareSpouseForWeddingCallback()
        {
            var @event = new PrepareSpouseForWeddingEvent();
            FireEvent(@event);
            return @event;
        }

        public static DetourEvent PlayMorningSongCallback()
        {
            var @event = new PlayMorningSongEvent();
            FireEvent(@event);
            return @event;
        }

		public static DetourEvent PlaySoundCallback( string soundCue )
		{
			var @event = new PlaySoundEvent( soundCue );
            FireEvent(@event);
			return @event;
		}

        public static DetourEvent FarmerTakeDamageCallback(int damage, bool overrideParry, MonsterAccessor damager)
        {
            var @event = new FarmerDamageEvent(damage, overrideParry, 
                damager == null ? null : new Monster(WrappedGame, damager));

            FireEvent(@event);
            return @event;
        }

        public static DetourEvent PreGameLoadedCallback(bool loadedGame)
        {
            var @event = HookEvent(new PreGameLoadedEvent(loadedGame));
            FireEvent(@event);
            return @event;
        }

        public static DetourEvent PostGameLoadedCallback(bool loadedGame)
        {
            var @event = HookEvent(new PostGameLoadedEvent(loadedGame));

            /* Create chatbox if there is not one */
            if (@event.Root.ChatBox == null)
                @event.Root.OnScreenMenus.Add(@event.Proxy<ChatBoxAccessor, ChatBox>(new ChatBoxDelegate()));

            FireEvent(@event);
            return @event;
        }

        public static DetourEvent ShowEndOfNightStuffCallback()
        {
            var @event = new ShowEndOfNightStuffEvent();
            FireEvent(@event);
            return @event;
        }

        public static DetourEvent TryToBuySelectedItemsCallback()
        {
            var @event = new TryToBuySelectedItemsEvent();
            FireEvent(@event);
            return @event;
        }

        public static DetourEvent UpdateMusicCallback()
        {
            var @event = new UpdateMusicEvent();
            FireEvent(@event);
            return @event;
        }

        public static DetourEvent UpdateTitleScreenCallback(StaticContextAccessor accessor)
        {
            var @event = new UpdateTitleScreenEvent(new StaticContext(accessor));
            FireEvent(@event);
            return @event;
        }

        public static DetourEvent ShowRedMessageCallback(string message)
        {
            var @event = new ShowRedMessageEvent(message);
            FireEvent(@event);
            return @event;
        }

        public static DetourEvent ShowGlobalMessageCallback(string message)
        {
            var @event = new ShowGlobalMessageEvent(message);
            FireEvent(@event);
            return @event;
        }

        public static DetourEvent GameExitEventCallback(StaticContextAccessor accessor)
        {
            var @event = new GameExitEvent(new StaticContext(accessor));
            FireEvent(@event);
            return @event;
        }

        public static DetourEvent ClientSizeChangedCallback(StaticContextAccessor accessor)
        {
            var @event = new ClientSizeChangedEvent(new StaticContext(accessor));
            FireEvent(@event);
            return @event;
        }

        public static DetourEvent PressAddItemToInventoryButtonCallback()
        {
            var @event = new PressAddItemToInventoryButtonEvent();
            FireEvent(@event);
            return @event;
        }

        public static DetourEvent PlayerEatObjectCallback(ObjectAccessor accessor, bool overrideFullness)
        {
            var @event = new PlayerEatObjectEvent(new ObjectItem(WrappedGame, accessor), overrideFullness);
            FireEvent(@event);
            return @event;
        }

        public static DetourEvent PressSwitchToolButtonCallback()
        {
            var @event = new PressSwitchToolButtonEvent();
            FireEvent(@event);
            return @event;
        }

        public static DetourEvent ReleaseUseToolButtonCallback()
        {
            var @event = new ReleaseUseToolButtonEvent();
            FireEvent(@event);
            return @event;
        }

        public static DetourEvent ShouldTimePassCallback()
        {
            var @event = new ShouldTimePassEvent();
            FireEvent(@event);
            return @event;
        }

        public static DetourEvent IsDarkOutCallback()
        {
            var @event = new IsDarkOutEvent();
            FireEvent(@event);
            return @event;
        }

        public static DetourEvent ShipObjectCallback(ObjectAccessor accessor)
        {
            var @event = new ShipObjectEvent(new ObjectItem(WrappedGame, accessor));
            FireEvent(@event);
            return @event;
        }

        #endregion

        #region Farmer Events

        public static DetourEvent WarpFarmerCallback(GameLocationAccessor location, int tileX, int tileY, int facingDirection, bool isStructure)
        {
            var @event = new WarpFarmerEvent(new GameLocation(WrappedGame, location), 
                tileX, tileY, facingDirection, isStructure);

            FireEvent(@event);
            return @event;
        }

        public static DetourEvent PostFarmerShippedBasicCallback(FarmerAccessor accessor, int index, int number)
        {
            var @event = new PostFarmerShippedBasicEvent(new Farmer(WrappedGame, accessor), index, number);
            FireEvent(@event);
            return @event;
        }

        public static DetourEvent PostFarmerCaughtFishCallback(FarmerAccessor accessor, int index, int size)
        {
            var @event = new PostFarmerCaughtFishEvent(new Farmer(WrappedGame, accessor), index, size);
            FireEvent(@event);
            return @event;
        }

        public static DetourEvent PostFarmerFoundArtifactCallback(FarmerAccessor accessor, int index, int number)
        {
            var @event = new PostFarmerFoundArtifactEvent(new Farmer(WrappedGame, accessor), index, number);
            FireEvent(@event);
            return @event;
        }

        public static DetourEvent PostFarmerCookedRecipeCallback(FarmerAccessor accessor, int index)
        {
            var @event = new PostFarmerCookedRecipeEvent(new Farmer(WrappedGame, accessor), index);
            FireEvent(@event);
            return @event;
        }

        public static DetourEvent FarmerGainedExperienceCallback(FarmerAccessor accessor, int which, int howMuch)
        {
            var @event = new FarmerGainedExperienceEvent(new Farmer(WrappedGame, accessor), which, howMuch);
            FireEvent(@event);
            return @event;
        }

        public static DetourEvent PostFarmerFoundMineralCallback(FarmerAccessor accessor, int index)
        {
            var @event = new PostFarmerFoundMineralEvent(new Farmer(WrappedGame, accessor), index);
            FireEvent(@event);
            return @event;
        }

        public static DetourEvent PostFarmerConsumeObjectCallback(FarmerAccessor accessor, int index, int quantity)
        {
            var @event = new PostFarmerConsumObjectEvent(new Farmer(WrappedGame, accessor), index, quantity);
            FireEvent(@event);
            return @event;
        }

        public static DetourEvent FarmerIncreaseBackpackSizeCallback(FarmerAccessor accessor, int howMuch)
        {
            var @event = new FarmerIncreaseBackpackSizeEvent(new Farmer(WrappedGame, accessor), howMuch);
            FireEvent(@event);
            return @event;
        }

        public static DetourEvent PostFarmerDismountHorseCallback(FarmerAccessor accessor)
        {
            var @event = new PostFarmerDismountHorseEvent(new Farmer(WrappedGame, accessor));
            FireEvent(@event);
            return @event;
        }

        public static DetourEvent FarmerChangedShirtCallback(FarmerAccessor accessor, int whichShirt)
        {
            var @event = new FarmerChangedShirtEvent(new Farmer(WrappedGame, accessor), whichShirt);
            FireEvent(@event);
            return @event;
        }

        public static DetourEvent FarmerChangedHairCallback(FarmerAccessor accessor, int whichHair)
        {
            var @event = new FarmerChangedHairEvent(new Farmer(WrappedGame, accessor), whichHair);
            FireEvent(@event);
            return @event;
        }

        public static DetourEvent FarmerChangedShoeCallback(FarmerAccessor accessor, int which)
        {
            var @event = new FarmerChangedShoeEvent(new Farmer(WrappedGame, accessor), which);
            FireEvent(@event);
            return @event;
        }

        public static DetourEvent FarmerChangedHairColorCallback(FarmerAccessor accessor, Color c)
        {
            var @event = new FarmerChangedHairColorEvent(new Farmer(WrappedGame, accessor), c);
            FireEvent(@event);
            return @event;
        }

        public static DetourEvent FarmerChangedPantsCallback(FarmerAccessor accessor, Color color)
        {
            var @event = new FarmerChangedPantsEvent(new Farmer(WrappedGame, accessor), color);
            FireEvent(@event);
            return @event;
        }

        public static DetourEvent FarmerChangedHatCallback(FarmerAccessor accessor, int newHat)
        {
            var @event = new FarmerChangedHatEvent(new Farmer(WrappedGame, accessor), newHat);
            FireEvent(@event);
            return @event;
        }

        public static DetourEvent FarmerChangedAccessoryCallback(FarmerAccessor accessor, int which)
        {
            var @event = new FarmerChangedAccessoryEvent(new Farmer(WrappedGame, accessor), which);
            FireEvent(@event);
            return @event;
        }

        public static DetourEvent FarmerChangedSkinColorCallback(FarmerAccessor accessor, int which)
        {
            var @event = new FarmerChangedSkinColorEvent(new Farmer(WrappedGame, accessor), which);
            FireEvent(@event);
            return @event;
        }

        public static DetourEvent FarmerChangedEyeColorCallback(FarmerAccessor accessor, Color c)
        {
            var @event = new FarmerChangedEyeColorEvent(new Farmer(WrappedGame, accessor), c);
            FireEvent(@event);
            return @event;
        }

        public static DetourEvent FarmerChangedGenderCallback(FarmerAccessor accessor, bool male)
        {
            var @event = new FarmerChangedGenderEvent(new Farmer(WrappedGame, accessor), male);
            FireEvent(@event);
            return @event;
        }

        public static DetourEvent FarmerCollideWithCallback(FarmerAccessor accessor, ObjectAccessor collisionObject)
        {
            var @event = new FarmerCollideWithEvent(new Farmer(WrappedGame, accessor), 
                collisionObject == null ? null : new ObjectItem(WrappedGame, collisionObject));

            FireEvent(@event);
            return @event;
        }

        public static DetourEvent ShouldCollideWithBuildingLayerCallback(CharacterAccessor accessor, GameLocationAccessor gameLocationAccessor)
        {
            var @event = new ShouldCollideWithBuildingLayerEvent(new Character(WrappedGame, accessor),
                gameLocationAccessor == null ? null : new GameLocation(WrappedGame, gameLocationAccessor));

            FireEvent(@event);
            return @event;
        }

        public static DetourEvent PostFarmerChangedIntoSwimsuitCallback(FarmerAccessor accessor)
        {
            var @event = new PostFarmerChangeIntoSwimsuitEvent(new Farmer(WrappedGame, accessor));
            FireEvent(@event);
            return @event;
        }

        public static DetourEvent PostFarmerChangeOutOfSwimsuitCallback(FarmerAccessor accessor)
        {
            var @event = new PostFarmerChangeOutOfSwimsuitEvent(new Farmer(WrappedGame, accessor));
            FireEvent(@event);
            return @event;
        }

        public static DetourEvent PostFarmerDayUpdateCallback(FarmerAccessor accessor)
        {
            var @event = new PostFarmerDayUpdateEvent(new Farmer(WrappedGame, accessor));
            FireEvent(@event);
            return @event;
        }

        public static DetourEvent GetFarmerTextureCallback(FarmerAccessor accessor)
        {
            var @event = new GetFarmerTextureEvent(new Farmer(WrappedGame, accessor));
            FireEvent(@event);
            return @event;
        }

        public static DetourEvent FarmerMountHorseCallback(FarmerAccessor accessor, HorseAccessor mount)
        {
            var @event = new FarmerMountHorseEvent(new Farmer(WrappedGame, accessor), new Horse(WrappedGame, mount));
            FireEvent(@event);
            return @event;
        }

        public static DetourEvent FarmerGetHisHerCallback(FarmerAccessor accessor)
        {
            var @event = new FarmerGetHisHerEvent(new Farmer(WrappedGame, accessor));
            FireEvent(@event);
            return @event;
        }

        public static DetourEvent FarmerShipAllCallback(FarmerAccessor accessor)
        {
            var @event = new FarmerShipAllEvent(new Farmer(WrappedGame, accessor));
            FireEvent(@event);
            return @event;
        }


        #endregion

        #region Crop Events

        public static DetourEvent CompleteGrowthCallback(CropAccessor accessor)
        {
            var @event = new CropCompleteGrowthEvent(new Crop(WrappedGame, accessor));
            FireEvent(@event);
            return @event;
        }

        public static DetourEvent PreHarvestCropCallback(CropAccessor accessor)
        {
            var @event = new PreHarvestCropEvent(new Crop(WrappedGame, accessor));
            FireEvent(@event);
            return @event;
        }

        public static DetourEvent PostHarvestCropCallback(CropAccessor accessor)
        {
            var @event = new PreHarvestCropEvent(new Crop(WrappedGame, accessor));
            FireEvent(@event);
            return @event;
        }

        public static DetourEvent PreCropNewDayCallback(CropAccessor accessor, int state, int fertilizer, int xTile, int yTile, GameLocationAccessor environment)
        {
            var @event = new PreCropNewDayEvent(new Crop(WrappedGame, accessor), state, fertilizer, xTile, yTile, new GameLocation(WrappedGame, environment));
            FireEvent(@event);
            return @event;
        }

        public static DetourEvent PostCropNewDayCallback(CropAccessor accessor, int state, int fertilizer, int xTile, int yTile, GameLocationAccessor environment)
        {
            var @event = new PostCropNewDayEvent(new Crop(WrappedGame, accessor), state, fertilizer, xTile, yTile, new GameLocation(WrappedGame, environment));
            FireEvent(@event);
            return @event;
        }

        public static DetourEvent PreCropConstructorCallback(CropAccessor accessor, int seedIndex, int tileX, int tileY)
        {
            var @event = new PreCropConstructorEvent(new Crop(WrappedGame, accessor), seedIndex, tileX, tileY);
            FireEvent(@event);
            return @event;
        }

        public static DetourEvent PostCropConstructorCallback(CropAccessor accessor, int seedIndex, int tileX, int tileY)
        {
            var @event = new PostCropConstructorEvent(new Crop(WrappedGame, accessor), seedIndex, tileX, tileY);
            FireEvent(@event);
            return @event;
        }

        #endregion

        #region HoeDirt Events

        public static DetourEvent PreDayUpdateHoeDirtCallback(HoeDirtAccessor accessor, GameLocationAccessor location, Vector2 tileLocation)
        {
            var @event = new PreDayUpdateHoeDirtEvent(
                new HoeDirt(WrappedGame, accessor),
                location == null ? null : new GameLocation(WrappedGame, location), 
                tileLocation);

            FireEvent(@event);
            return @event;
        }

        public static DetourEvent PostDayUpdateHoeDirtCallback(HoeDirtAccessor accessor, GameLocationAccessor location, Vector2 tileLocation)
        {
            var @event = new PostDayUpdateHoeDirtEvent(new HoeDirt(WrappedGame, accessor), 
                location == null ? null : new GameLocation(WrappedGame, location), 
                tileLocation);

            FireEvent(@event);
            return @event;
        }

        public static DetourEvent PreHoeDirtPlantCallback(HoeDirtAccessor accessor, int objectIndex, int tileX, int tileY, FarmerAccessor farmer, bool isFertilizer)
        {
            var @event = new PreHoeDirtPlantEvent(
                new HoeDirt(WrappedGame, accessor), 
                objectIndex, 
                tileX, tileY, 
                farmer == null ? null : new Farmer(WrappedGame, farmer),
                isFertilizer);

            FireEvent(@event);
            return @event;
        }

        public static DetourEvent PreHoeDirtCanPlantCallback(HoeDirtAccessor accessor, int objectIndex, int tileX, int tileY, bool isFertilizer)
        {
            var @event = new PreHoeDirtCanPlantEvent(new HoeDirt(WrappedGame, accessor), objectIndex, tileX, tileY, isFertilizer);
            FireEvent(@event);
            return @event;
        }

        public static DetourEvent PostHoeDirtCanPlantCallback(HoeDirtAccessor accessor, int objectIndex, int tileX, int tileY, bool isFertilizer)
        {
            var @event = new PostHoeDirtCanPlantEvent(new HoeDirt(WrappedGame, accessor), objectIndex, tileX, tileY, isFertilizer);
            FireEvent(@event);
            return @event;
        }

        public static DetourEvent PostHoeDirtPlantCallback(HoeDirtAccessor accessor, int objectIndex, int tileX, int tileY, FarmerAccessor farmer, bool isFertilizer)
        {
            var @event = new PostHoeDirtPlantEvent(
                new HoeDirt(WrappedGame, accessor), 
                objectIndex, 
                tileX, tileY, 
                farmer == null ? null : new Farmer(WrappedGame, farmer), 
                isFertilizer);

            FireEvent(@event);
            return @event;
        }

        #endregion

        #region Objects

        public static DetourEvent PreObjectDayUpdateCallback(ObjectAccessor accessor, GameLocationAccessor locAccessor)
        {
            var @event = new PreObjectDayUpdateEvent(
                new ObjectItem(WrappedGame, accessor), 
                locAccessor == null ? null : new GameLocation(WrappedGame, locAccessor));

            FireEvent(@event);
            return @event;
        }

        public static DetourEvent PostObjectDayUpdateCallback(ObjectAccessor accessor, GameLocationAccessor locAccessor)
        {
            var @event = new PostObjectDayUpdateEvent(
                new ObjectItem(WrappedGame, accessor), 
                locAccessor == null ? null : new GameLocation(WrappedGame, locAccessor));

            FireEvent(@event);
            return @event;
        }

        public static DetourEvent PreObjectDropInActionCallback(ObjectAccessor accessor, ObjectAccessor dropAccessor, bool probe, FarmerAccessor who)
        {
            var @event = new PreObjectDropInActionEvent(
                new ObjectItem(WrappedGame, accessor), 
                dropAccessor == null ? null : new ObjectItem(WrappedGame, dropAccessor), 
                probe,
                who == null ? null : new Farmer(WrappedGame, who));

            FireEvent(@event);
            return @event;
        }

        public static DetourEvent PostObjectDropInActionCallback(ObjectAccessor accessor, ObjectAccessor dropAccessor, bool probe, FarmerAccessor who)
        {
            var @event = new PostObjectDropInActionEvent(
                new ObjectItem(WrappedGame, accessor), 
                dropAccessor == null ? null : new ObjectItem(WrappedGame, dropAccessor), 
                probe, 
                who == null ? null : new Farmer(WrappedGame, who));

            FireEvent(@event);
            return @event;
        }

        #endregion

        #region FishingRod Events

        public static DetourEvent PrePullFishFromWaterCallback(FishingRodAccessor accessor, int whichFish, int fishSize, int fishQuality, int fishDifficulty, bool treasureCaught, bool wasPerfect)
        {
            var @event = new PrePullFishFromWaterEvent(new FishingRod(WrappedGame, accessor), 
                whichFish, fishSize, fishQuality, fishDifficulty, treasureCaught, wasPerfect);

            FireEvent(@event);
            return @event;
        }

        public static DetourEvent PostPullFishFromWaterCallback(FishingRodAccessor accessor, int whichFish, int fishSize, int fishQuality, int fishDifficulty, bool treasureCaught, bool wasPerfect)
        {
            var @event = new PostPullFishFromWaterEvent(new FishingRod(WrappedGame, accessor), 
                whichFish, fishSize, fishQuality, fishDifficulty, treasureCaught, wasPerfect);

            FireEvent(@event);
            return @event;
        }

        public static DetourEvent PreDoneFishingCallback(FishingRodAccessor accessor, FarmerAccessor who, bool consumeBaitAndTackle)
        {
            var @event = new PreDoneFishingEvent(
                new FishingRod(WrappedGame, accessor), 
                who == null ? null : new Farmer(WrappedGame, who), 
                consumeBaitAndTackle);

            FireEvent(@event);
            return @event;
        }

        public static DetourEvent PostDoneFishingCallback(FishingRodAccessor accessor, FarmerAccessor who, bool consumeBaitAndTackle)
        {
            var @event = new PostDoneFishingEvent(
                new FishingRod(WrappedGame, accessor),
                who == null ? null : new Farmer(WrappedGame, who),
                consumeBaitAndTackle);

            FireEvent(@event);
            return @event;
        }

        public static DetourEvent PreFishingRodTickUpdateCallback(FishingRodAccessor accessor, GameTime time, FarmerAccessor who)
        {
            var @event = new PreFishingRodTickUpdateEvent(
                new FishingRod(WrappedGame, accessor), 
                time, 
                who == null ? null : new Farmer(WrappedGame, who));

            FireEvent(@event);
            return @event;
        }

        public static DetourEvent PostFishingRodTickUpdateCallback(FishingRodAccessor accessor, GameTime time, FarmerAccessor who)
        {
            var @event = new PostFishingRodTickUpdateEvent(
                new FishingRod(WrappedGame, accessor), 
                time, 
                who == null ? null : new Farmer(WrappedGame, who));

            FireEvent(@event);
            return @event;
        }

        #endregion

        #region BuffsDisplay Events
        
        public static DetourEvent TryToAddFoodBuffCallback(BuffsDisplayAccessor accessor, BuffAccessor buff, int duration)
        {
            var @event = new TryToAddFoodBuffCallbackEvent(new BuffsDisplay(WrappedGame, accessor), new Buff(WrappedGame, buff), duration);
            FireEvent(@event);
            return @event;
        }

        public static DetourEvent TryToAddDrinkBuffCallback(BuffsDisplayAccessor accessor, BuffAccessor buff)
        {
            var @event = new TryToAddDrinkBuffCallbackEvent(new BuffsDisplay(WrappedGame, accessor), new Buff(WrappedGame, buff));
            FireEvent(@event);
            return @event;
        }

        public static DetourEvent AddOtherBuffCallback(BuffsDisplayAccessor accessor, BuffAccessor buff)
        {
            var @event = new AddOtherBuffCallbackEvent(new BuffsDisplay(WrappedGame, accessor), new Buff(WrappedGame, buff));
            FireEvent(@event);
            return @event;
        }

        #endregion

        #region ShopMenu Events

        public static DetourEvent PreConstructShopViaListCallback(ShopMenuAccessor accessor, IList list, int currency, string who)
        {
            var itemsForSale = new WrappedProxyList<ItemAccessor, Item>(list, i => new Item(WrappedGame, i));
            var @event = new PreConstructShopViaListEvent(new ShopMenu(WrappedGame, accessor), itemsForSale, currency, who);
            FireEvent(@event);
            return @event;
        }

        public static DetourEvent PostConstructShopViaListCallback(ShopMenuAccessor accessor, IList list, int currency, string who)
        {
            var itemsForSale = new WrappedProxyList<ItemAccessor, Item>(list, i => new Item(WrappedGame, i));
            var @event = new PostConstructShopViaListEvent(new ShopMenu(WrappedGame, accessor), itemsForSale, currency, who);
            FireEvent(@event);
            return @event;
        }

        public static DetourEvent SetUpShopOwnerCallback(ShopMenuAccessor accessor, string who)
        {
            var @event = new SetUpShopOwnerEvent(new ShopMenu(WrappedGame, accessor), who);
            FireEvent(@event);
            return @event;
        }

        #endregion

        #region MineShaft Events

        public static DetourEvent PreBuriedItemCheckCallback(MineShaftAccessor accessor, int xLocation, int yLocation, bool explosion, bool detectOnly)
        {
            var @event = new PreBuriedItemCheckEvent(xLocation, yLocation, explosion, detectOnly);
            FireEvent(@event);
            return @event;
        }

        public static DetourEvent PreStoneItemCheckCallback(MineShaftAccessor accessor, int tileIndexOfStone, int x, int y, Farmer who)
        {
            var @event = new PreStoneItemCheckEvent(tileIndexOfStone, x, y, who);
            FireEvent(@event);
            return @event;
        }

        public static DetourEvent PlayMineSongCallback(MineShaftAccessor accessor)
        {
            var @event = new PlayMineSongEvent();
            FireEvent(@event);
            return @event;
        }

        public static DetourEvent ChooseLevelTypeCallback(MineShaftAccessor accessor)
        {
            var @event = new ChooseLevelTypeEvent();
            FireEvent(@event);
            return @event;
        }

        public static DetourEvent LoadMineshaftLevelCallback(MineShaftAccessor accessor, int level)
        {
            var @event = new LoadMineshaftLevelEvent(level);
            FireEvent(@event);
            return @event;
        }

        public static DetourEvent PrepareElevatorCallback(MineShaftAccessor accessor)
        {
            var @event = new PrepareElevatorEvent();
            FireEvent(@event);
            return @event;
        }

        public static DetourEvent CreateLadderDownCallback(MineShaftAccessor accessor, int x, int y)
        {
            var @event = new CreateLadderDownEvent(x, y);
            FireEvent(@event);
            return @event;
        }

        public static DetourEvent GetOreIndexForLevelCallback(MineShaftAccessor accessor, int mineLevel, Random r)
        {
            var @event = new GetOreIndexForLevelEvent(mineLevel, r);
            FireEvent(@event);
            return @event;
        }

        public static DetourEvent GetMineAreaCallback(MineShaftAccessor accessor, int level)
        {
            var @event = new GetMineAreaEvent(level);
            FireEvent(@event);
            return @event;
        }

        public static DetourEvent GetMonsterForLevelCallback(MineShaftAccessor accessor, int level, int xTile, int yTile)
        {
            var @event = new GetMonsterForLevelEvent(level, xTile, yTile);
            FireEvent(@event);
            return @event;
        }

        public static DetourEvent GetExtraMineShaftMillisecondsCallback(MineShaftAccessor accessor)
        {
            var @event = new GetExtraMineShaftMillisecondsEvent();
            FireEvent(@event);
            return @event;
        }

        #endregion

        #region BobberBar Events

        public static DetourEvent BobberBarUpdateCallback(BobberBarAccessor bobberBar, Microsoft.Xna.Framework.GameTime time)
        {
            var @event = new BobberBarUpdateEvent(new BobberBar(WrappedGame, bobberBar), time);
            FireEvent(@event);
            return @event;
        }

        #endregion

    }
}