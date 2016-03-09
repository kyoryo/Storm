/*
    Copyright 2016 Cody R. (Demmonic), Zoey (Zoryn), Matt Stevens (Handsome Matt), Matthew Bell (mdbell)

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

namespace Storm.StardewValley
{
    public static class StaticGameContext
    {
        private static Assembly Assembly { get; set; }

        private static ProgramAccessor Root { get; set; }

        private static Type ToolType { get; set; }

        private static InterceptorFactory<ToolDelegate> ToolFactory { get; set; }

        private static Type ObjectType { get; set; }

        private static InterceptorFactory<ObjectDelegate> ObjectFactory { get; set; }

        private static Type TextureComponentType { get; set; }
        private static InterceptorFactory<TextureComponentDelegate> TextureComponentFactory { get; set; }

        private static Type BillboardType { get; set; }
        private static InterceptorFactory<BillboardDelegate> BillboardFactory { get; set; }

        private static Type ClickableMenuType { get; set; }
        private static InterceptorFactory<ClickableMenuDelegate> ClickableMenuFactory { get; set; }

        private static ModEventBus EventBus { get; set; }

        private static StaticContext WrappedGame
        {
            get { return new StaticContext(Root._GetGame()); }
        }

        public static void Init(
            Assembly assembly, ProgramAccessor root, 
            Type toolType, InterceptorFactory<ToolDelegate> toolFactory, 
            Type objectType, InterceptorFactory<ObjectDelegate> objectFactory, 
            Type textureComponentType, InterceptorFactory<TextureComponentDelegate> textureComponentFactory,
            Type billboardType, InterceptorFactory<BillboardDelegate> billboardFactory,
            Type clickableMenuType, InterceptorFactory<ClickableMenuDelegate> clickableMenuFactory,
            ModEventBus eventBus)
        {
            Assembly = assembly;
            Root = root;
            ToolType = toolType;
            ToolFactory = toolFactory;
            ObjectType = objectType;
            ObjectFactory = objectFactory;
            TextureComponentType = textureComponentType;
            TextureComponentFactory = textureComponentFactory;
            BillboardType = billboardType;
            BillboardFactory = billboardFactory;
            ClickableMenuType = clickableMenuType;
            ClickableMenuFactory = clickableMenuFactory;
            EventBus = eventBus;
        }

        private static void InitializeEvent(StaticContextEvent @event)
        {
            @event.GameAssembly = Assembly;
            @event.Root = WrappedGame;
            @event.EventBus = EventBus;
            @event.ToolType = ToolType;
            @event.ToolFactory = ToolFactory;
            @event.ObjectType = ObjectType;
            @event.ObjectFactory = ObjectFactory;
            @event.TextureComponentType = TextureComponentType;
            @event.TextureComponentFactory = TextureComponentFactory;
            @event.BillboardType = BillboardType;
            @event.BillboardFactory =BillboardFactory;
            @event.ClickableMenuType = ClickableMenuType;
            @event.ClickableMenuFactory = ClickableMenuFactory;
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
            FireEvent(@event);
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

        public static DetourEvent ChatboxTextEnteredCallback(ChatBoxAccessor chatbox, TextBoxAccessor textbox)
        {
            var @event = new ChatMessageEnteredEvent(textbox._GetText());

            // just echo back for now, idk why
            @event.Root.ChatBox.ReceiveChatMessage(@event.ChatText, -1L);
            FireEvent(@event);
            return @event;
        }

        #endregion

        #region Game1 Events

        public static DetourEvent InitializeCallback(StaticContextAccessor context)
        {
            WrappedGame.Version += ", " + AssemblyInfo.NICE_VERSION;
            WrappedGame.Version += ", mods loaded: " + EventBus.mods.Count;
            WrappedGame.Window.Title = "Stardew Valley - Version " + WrappedGame.Version;

            Logging.DebugLog("Game Initialized");

            var @event = new InitializeEvent();
            FireEvent(@event);
            return @event;
        }

        public static DetourEvent LoadContentCallback(StaticContextAccessor context)
        {
            var @event = new LoadContentEvent();
            FireEvent(@event);
            return @event;
        }

        public static DetourEvent UnloadContentCallback(StaticContextAccessor context)
        {
            var @event = new UnloadContentEvent();
            FireEvent(@event);
            return @event;
        }

        public static DetourEvent PreDrawCallback(StaticContextAccessor context)
        {
            var @event = new PreRenderEvent();
            FireEvent(@event);
            return @event;
        }

        public static DetourEvent PreUIDrawCallback(StaticContextAccessor context)
        {
            var @event = new PreUIRenderEvent();
            FireEvent(@event);
            return @event;
        }

        public static DetourEvent PostDrawCallback(StaticContextAccessor context)
        {
            var batch = context._GetSpriteBatch();
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

        public static DetourEvent BeforeNewDayCallback()
        {
            var @event = new BeforeNewDayEvent();
            FireEvent(@event);
            return @event;
        }

        public static DetourEvent AfterNewDayCallback()
        {
            var @event = new AfterNewDayEvent();
            FireEvent(@event);
            return @event;
        }

        public static DetourEvent Before10MinuteClockUpdateCallback()
        {
            var @event = new Before10MinuteClockUpdateEvent();
            FireEvent(@event);
            return @event;
        }

        public static DetourEvent After10MinuteClockUpdateCallback()
        {
            var @event = new After10MinuteClockUpdateEvent();
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
            var @event = new AddItemToInventoryEvent(new Farmer(WrappedGame, farmer), new Item(WrappedGame, item));
            FireEvent(@event);
            return @event;
        }

        public static DetourEvent PreUpdateCallback(StaticContextAccessor accessor)
        {
            var @event = new PreUpdateEvent();
            FireEvent(@event);
            return @event;
        }

        private static KeyboardState oldKeyboardState = new KeyboardState();
        private static MouseState oldMouseState;
        private static GamePadState oldGamepadState;

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

            /* todo: gamepad events */

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

        public static DetourEvent FarmerTakeDamageCallback(int damage, bool overrideParry, MonsterAccessor damager)
        {
            var @event = new FarmerDamageEvent(damage, overrideParry, new Monster(WrappedGame, damager));
            FireEvent(@event);
            return @event;
        }

        public static DetourEvent BeforeGameLoadedCallback(bool loadedGame)
        {
            var @event = HookEvent(new BeforeGameLoadedEvent(loadedGame));
            @event.Root.MultiplayerMode = 1; /* enables chatbox and nothing else, hacky, remove when proxies are done */
            FireEvent(@event);
            return @event;
        }

        public static DetourEvent AfterGameLoadedCallback(bool loadedGame)
        {
            var @event = HookEvent(new AfterGameLoadedEvent(loadedGame));
            @event.Root.MultiplayerMode = 0; /* enables chatbox and nothing else, hacky, remove when proxies are done */
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

        public static DetourEvent UpdateTitleScreenCallback(StaticContextAccessor context)
        {
            var @event = new UpdateTitleScreenEvent(context);
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

        public static DetourEvent GameExitEventCallback(StaticContextAccessor context)
        {
            var @event = new GameExitEvent(context);
            FireEvent(@event);
            return @event;
        }

        public static DetourEvent ClientSizeChangedCallback(StaticContextAccessor context)
        {
            var @event = new ClientSizeChangedEvent(context);
            FireEvent(@event);
            return @event;
        }

        public static DetourEvent PressAddItemToInventoryButtonCallback()
        {
            var @event = new PressAddItemToInventoryButtonEvent();
            FireEvent(@event);
            return @event;
        }

        public static DetourEvent PlayerEatObjectCallback(ObjectAccessor o, bool overrideFullness)
        {
            var @event = new PlayerEatObjectEvent(new ObjectItem(WrappedGame, o), overrideFullness);
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
            var @event = new WarpFarmerEvent(new GameLocation(WrappedGame, location), tileX, tileY, facingDirection, isStructure);
            FireEvent(@event);
            return @event;
        }

        public static DetourEvent AfterFarmerShippedBasicCallback(FarmerAccessor accessor, int index, int number)
        {
            var @event = new AfterFarmerShippedBasicEvent(index, number);
            FireEvent(@event);
            return @event;
        }

        public static DetourEvent AfterFarmerCaughtFishCallback(FarmerAccessor accessor, int index, int size)
        {
            var @event = new AfterFarmerCaughtFishEvent(index, size);
            FireEvent(@event);
            return @event;
        }

        public static DetourEvent AfterFarmerFoundArtifactCallback(FarmerAccessor accessor, int index, int number)
        {
            var @event = new AfterFarmerCaughtFishEvent(index, number);
            FireEvent(@event);
            return @event;
        }

        public static DetourEvent AfterFarmerCookedRecipeCallback(FarmerAccessor accessor, int index)
        {
            var @event = new AfterFarmerCookedRecipeEvent(index);
            FireEvent(@event);
            return @event;
        }

        public static DetourEvent FarmerGainedExperienceCallback(FarmerAccessor accessor, int which, int howMuch)
        {
            var @event = new FarmerGainedExperienceEvent(which, howMuch);
            FireEvent(@event);
            return @event;
        }

        public static DetourEvent AfterFarmerFoundMineralCallback(FarmerAccessor accessor, int index)
        {
            var @event = new AfterFarmerFoundMineralEvent(index);
            FireEvent(@event);
            return @event;
        }

        public static DetourEvent AfterFarmerConsumeObjectCallback(FarmerAccessor accessor, int index, int quantity)
        {
            var @event = new AfterFarmerConsumObjectEvent(index, quantity);
            FireEvent(@event);
            return @event;
        }

        public static DetourEvent FarmerIncreaseBackpackSizeCallback(FarmerAccessor accessor, int howMuch)
        {
            var @event = new FarmerIncreaseBackpackSizeEvent(howMuch);
            FireEvent(@event);
            return @event;
        }

        public static DetourEvent AfterFarmerDismountHorseCallback(FarmerAccessor accessor)
        {
            var @event = new AfterFarmerDismountHorseEvent();
            FireEvent(@event);
            return @event;
        }

        public static DetourEvent FarmerChangedShirtCallback(FarmerAccessor accessor, int whichShirt)
        {
            var @event = new FarmerChangedShirtEvent(whichShirt);
            FireEvent(@event);
            return @event;
        }

        public static DetourEvent FarmerChangedHairCallback(FarmerAccessor accessor, int whichHair)
        {
            var @event = new FarmerChangedHairEvent(whichHair);
            FireEvent(@event);
            return @event;
        }

        public static DetourEvent FarmerChangedShoeCallback(FarmerAccessor accessor, int which)
        {
            var @event = new FarmerChangedShoeEvent(which);
            FireEvent(@event);
            return @event;
        }

        public static DetourEvent FarmerChangedHairColorCallback(FarmerAccessor accessor, Color c)
        {
            var @event = new FarmerChangedHairColorEvent(c);
            FireEvent(@event);
            return @event;
        }

        public static DetourEvent FarmerChangedPantsCallback(FarmerAccessor accessor, Color color)
        {
            var @event = new FarmerChangedPantsEvent(color);
            FireEvent(@event);
            return @event;
        }

        public static DetourEvent FarmerChangedHatCallback(FarmerAccessor accessor, int newHat)
        {
            var @event = new FarmerChangedHatEvent(newHat);
            FireEvent(@event);
            return @event;
        }

        public static DetourEvent FarmerChangedAccessoryCallback(FarmerAccessor accessor, int which)
        {
            var @event = new FarmerChangedAccessoryEvent(which);
            FireEvent(@event);
            return @event;
        }

        public static DetourEvent FarmerChangedSkinColorCallback(FarmerAccessor accessor, int which)
        {
            var @event = new FarmerChangedSkinColorEvent(which);
            FireEvent(@event);
            return @event;
        }

        public static DetourEvent FarmerChangedEyeColorCallback(FarmerAccessor accessor, Color c)
        {
            var @event = new FarmerChangedEyeColorEvent(c);
            FireEvent(@event);
            return @event;
        }

        public static DetourEvent FarmerChangedGenderCallback(FarmerAccessor accessor, bool male)
        {
            var @event = new FarmerChangedGenderEvent(male);
            FireEvent(@event);
            return @event;
        }

        public static DetourEvent FarmerCollideWithCallback(FarmerAccessor accessor, ObjectAccessor collisionObject)
        {
            var @event = new FarmerCollideWithEvent(new ObjectItem(WrappedGame, collisionObject));
            FireEvent(@event);
            return @event;
        }

        public static DetourEvent ShouldCollideWithBuildingLayerCallback(CharacterAccessor accessor, GameLocationAccessor gameLocationAccessor)
        {
            var @event = new ShouldCollideWithBuildingLayerEvent(new GameLocation(WrappedGame, gameLocationAccessor));
            FireEvent(@event);
            return @event;
        }

        public static DetourEvent AfterFarmerChangedIntoSwimsuitCallback(FarmerAccessor accessor)
        {
            var @event = new AfterFarmerChangeIntoSwimsuitEvent();
            FireEvent(@event);
            return @event;
        }

        public static DetourEvent AfterFarmerChangeOutOfSwimsuitCallback(FarmerAccessor accessor)
        {
            var @event = new AfterFarmerChangeOutOfSwimsuitEvent();
            FireEvent(@event);
            return @event;
        }

        public static DetourEvent AfterFarmerDayUpdateCallback(FarmerAccessor accessor)
        {
            var @event = new AfterFarmerDayUpdateEvent();
            FireEvent(@event);
            return @event;
        }

        public static DetourEvent GetFarmerTextureCallback(FarmerAccessor accessor)
        {
            var @event = new GetFarmerTextureEvent();
            FireEvent(@event);
            return @event;
        }

        public static DetourEvent FarmerMountHorseCallback(FarmerAccessor accessor, HorseAccessor mount)
        {
            var @event = new FarmerMountHorseEvent(new Horse(WrappedGame, mount));
            FireEvent(@event);
            return @event;
        }

        public static DetourEvent FarmerGetHisHerCallback(FarmerAccessor accessor)
        {
            var @event = new FarmerGetHisHerEvent();
            FireEvent(@event);
            return @event;
        }

        public static DetourEvent FarmerShipAllCallback(FarmerAccessor accessor)
        {
            var @event = new FarmerShipAllEvent();
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

        public static DetourEvent BeforeHarvestCropCallback(CropAccessor accessor)
        {
            var @event = new BeforeHarvestCropEvent(new Crop(WrappedGame, accessor));
            FireEvent(@event);
            return @event;
        }

        public static DetourEvent AfterHarvestCropCallback(CropAccessor accessor)
        {
            var @event = new AfterHarvestCropEvent(new Crop(WrappedGame, accessor));
            FireEvent(@event);
            return @event;
        }

        #endregion

        #region HoeDirt Events

        public static DetourEvent BeforeDayUpdateHoeDirtCallback(HoeDirtAccessor hoedirt, GameLocationAccessor locationaccessor, Vector2 tileLocation)
        {
            var @event = new BeforeDayUpdateHoeDirtEvent(new HoeDirt(WrappedGame, hoedirt), new GameLocation(WrappedGame, locationaccessor), tileLocation);
            FireEvent(@event);
            return @event;
        }

        public static DetourEvent AfterDayUpdateHoeDirtCallback(HoeDirtAccessor hoedirt, GameLocationAccessor locationaccessor, Vector2 tileLocation)
        {
            var @event = new AfterDayUpdateHoeDirtEvent(new HoeDirt(WrappedGame, hoedirt), new GameLocation(WrappedGame, locationaccessor), tileLocation);
            FireEvent(@event);
            return @event;
        }

        public static DetourEvent BeforeHoeDirtPlantCallback(HoeDirtAccessor hoedirt, int objectIndex, int tileX, int tileY, FarmerAccessor farmeraccessor, bool isFertilizer = false)
        {
            var @event = new BeforeHoeDirtPlantEvent(new HoeDirt(WrappedGame, hoedirt), objectIndex, tileX, tileY, new Farmer(WrappedGame, farmeraccessor), isFertilizer);
            FireEvent(@event);
            return @event;
        }

        public static DetourEvent BeforeHoeDirtCanPlantCallback(HoeDirtAccessor hoedirt, int objectIndex, int tileX, int tileY, bool isFertilizer = false)
        {
            var @event = new BeforeHoeDirtCanPlantEvent(new HoeDirt(WrappedGame, hoedirt), objectIndex, tileX, tileY, isFertilizer);
            FireEvent(@event);
            return @event;
        }

        public static DetourEvent AfterHoeDirtCanPlantCallback(HoeDirtAccessor hoedirt, int objectIndex, int tileX, int tileY, bool isFertilizer = false)
        {
            var @event = new AfterHoeDirtCanPlantEvent(new HoeDirt(WrappedGame, hoedirt), objectIndex, tileX, tileY, isFertilizer);
            FireEvent(@event);
            return @event;
        }

        public static DetourEvent AfterHoeDirtPlantCallback(HoeDirtAccessor hoedirt, int objectIndex, int tileX, int tileY, FarmerAccessor farmeraccessor, bool isFertilizer = false)
        {
            var @event = new AfterHoeDirtPlantEvent(new HoeDirt(WrappedGame, hoedirt), objectIndex, tileX, tileY, new Farmer(WrappedGame, farmeraccessor), isFertilizer);
            FireEvent(@event);
            return @event;
        }

        #endregion

        #region Objects

        public static DetourEvent BeforeObjectDayUpdateCallback(ObjectAccessor accessor, GameLocationAccessor locAccessor)
        {
            var @event = new BeforeObjectDayUpdateEvent(new ObjectItem(WrappedGame, accessor), new GameLocation(WrappedGame, locAccessor));
            FireEvent(@event);
            return @event;
        }

        public static DetourEvent AfterObjectDayUpdateCallback(ObjectAccessor accessor, GameLocationAccessor locAccessor)
        {
            var @event = new AfterObjectDayUpdateEvent(new ObjectItem(WrappedGame, accessor), new GameLocation(WrappedGame, locAccessor));
            FireEvent(@event);
            return @event;
        }

        public static DetourEvent PreObjectDropInActionCallback(ObjectAccessor accessor, ObjectAccessor dropAccessor, bool probe, FarmerAccessor who)
        {
            var @event = new PreObjectDropInActionEvent(new ObjectItem(WrappedGame, accessor), new ObjectItem(WrappedGame, dropAccessor), probe, new Farmer(WrappedGame, who));
            FireEvent(@event);
            return @event;
        }

        public static DetourEvent PostObjectDropInActionCallback(ObjectAccessor accessor, ObjectAccessor dropAccessor, bool probe, FarmerAccessor who)
        {
            var @event = new PostObjectDropInActionEvent(new ObjectItem(WrappedGame, accessor), new ObjectItem(WrappedGame, dropAccessor), probe, new Farmer(WrappedGame, who));
            FireEvent(@event);
            return @event;
        }

        #endregion

        #region FishingRod Events

        public static DetourEvent BeforePullFishFromWaterCallback(FishingRodAccessor accessor, int whichFish, int fishSize, int fishQuality, int fishDifficulty, bool treasureCaught, bool wasPerfect)
        {
            var @event = new BeforePullFishFromWaterEvent(new FishingRod(WrappedGame, accessor), whichFish, fishSize, fishQuality, fishDifficulty, treasureCaught, wasPerfect);
            FireEvent(@event);
            return @event;
        }

        public static DetourEvent AfterPullFishFromWaterCallback(FishingRodAccessor accessor, int whichFish, int fishSize, int fishQuality, int fishDifficulty, bool treasureCaught, bool wasPerfect)
        {
            var @event = new AfterPullFishFromWaterEvent(new FishingRod(WrappedGame, accessor), whichFish, fishSize, fishQuality, fishDifficulty, treasureCaught, wasPerfect);
            FireEvent(@event);
            return @event;
        }

        public static DetourEvent BeforeDoneFishingCallback(FishingRodAccessor accessor, FarmerAccessor who, bool consumeBaitAndTackle)
        {
            var @event = new BeforeDoneFishingEvent(new Farmer(WrappedGame, who), new FishingRod(WrappedGame, accessor), consumeBaitAndTackle);
            FireEvent(@event);
            return @event;
        }

        public static DetourEvent AfterDoneFishingCallback(FishingRodAccessor accessor, FarmerAccessor who, bool consumeBaitAndTackle)
        {
            var @event = new AfterDoneFishingEvent(new Farmer(WrappedGame, who), new FishingRod(WrappedGame, accessor), consumeBaitAndTackle);
            FireEvent(@event);
            return @event;
        }

        #endregion

        #region ShopMenu Events

        public static DetourEvent PreConstructShopViaListCallback(ShopMenuAccessor shopMenu, IList list, int currency = 0, string who = null)
        {
            var itemsForSale = new ProxyList<ItemAccessor, Item>(list);
            var @event = new PreConstructShopViaListEvent(new ShopMenu(WrappedGame, shopMenu), itemsForSale, currency, who);
            FireEvent(@event);
            return @event;
        }

        public static DetourEvent PostConstructShopViaListCallback(ShopMenuAccessor shopMenu, IList list, int currency = 0, string who = null)
        {
            var itemsForSale = new ProxyList<ItemAccessor, Item>(list);
            var @event = new PostConstructShopViaListEvent(new ShopMenu(WrappedGame, shopMenu), itemsForSale, currency, who);
            FireEvent(@event);
            return @event;
        }

        public static DetourEvent SetUpShopOwnerCallback(ShopMenuAccessor shopMenu, string who)
        {
            var @event = new SetUpShopOwnerEvent(new ShopMenu(WrappedGame, shopMenu), who);
            FireEvent(@event);
            return @event;
        }

        #endregion

        #region MineShaft Events

        public static DetourEvent BeforeBuriedItemCheckCallback(MineShaftAccessor accessor, int xLocation, int yLocation, bool explosion, bool detectOnly)
        {
            var @event = new BeforeBuriedItemCheckEvent(xLocation, yLocation, explosion, detectOnly);
            FireEvent(@event);
            return @event;
        }

        public static DetourEvent BeforeStoneItemCheckCallback(MineShaftAccessor accessor, int tileIndexOfStone, int x, int y, Farmer who)
        {
            var @event = new BeforeStoneItemCheckEvent(tileIndexOfStone, x, y, who);
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
            var @event = new BobberBarUpdateEvent(time);
            FireEvent(@event);
            return @event;
        }

        #endregion
    }
}