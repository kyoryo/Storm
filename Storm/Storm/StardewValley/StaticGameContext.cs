/*
    Copyright 2016 Cody R. (Demmonic), Zoey (Zoryn)

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
using Microsoft.Xna.Framework;
using Storm.ExternalEvent;
using Storm.Manipulation;
using Storm.StardewValley.Accessor;
using Storm.StardewValley.Event;
using Storm.StardewValley.Event.Crop;
using Storm.StardewValley.Event.Game;
using Storm.StardewValley.Wrapper;
using Object = Storm.StardewValley.Wrapper.Object;
using Storm.StardewValley.Proxy;

namespace Storm.StardewValley
{
    public sealed class StaticGameContext
    {
        private StaticGameContext()
        {
        }

        /// <summary>
        ///     The Stardew Valley assembly
        /// </summary>
        public static Assembly Assembly { get; set; }

        /// <summary>
        ///     Wrapped Stardew Valley Program class.
        /// </summary>
        public static ProgramAccessor Root { get; set; }

        public static Type ToolType { get; set; }
        public static ToolInterceptFactory ToolFactory { get; set; }

        public static Type TextureComponentType { get; set; }
        public static TextureComponentInterceptorFactory TextureComponentFactory { get; set; }

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

        #region Farmer Events

        public static DetourEvent WarpFarmerCallback(GameLocationAccessor location, int tileX, int tileY, int facingDirection, bool isStructure)
        {
            var @event = new WarpFarmerEvent(new GameLocation(WrappedGame, location), tileX, tileY, facingDirection, isStructure);
            EventBus.Fire(@event);
            return @event;
        }

        public static DetourEvent AfterFarmerShippedBasicCallback(FarmerAccessor accessor, int index,int number)
        {
            var @event = new Event.Farmer.AfterFarmerShippedBasicEvent(index, number);
            EventBus.Fire(@event);
            return @event;
        }

        public static DetourEvent AfterFarmerCaughtFishCallback(FarmerAccessor accessor, int index, int size)
        {
            var @event = new Event.Farmer.AfterFarmerCaughtFishEvent(index, size);
            EventBus.Fire(@event);
            return @event;
        }

        public static DetourEvent AfterFarmerFoundArtifactCallback(FarmerAccessor accessor, int index, int number)
        {
            var @event = new Event.Farmer.AfterFarmerCaughtFishEvent(index, number);
            EventBus.Fire(@event);
            return @event;
        }

        public static DetourEvent AfterFarmerCookedRecipeCallback(FarmerAccessor accessor, int index)
        {
            var @event = new Event.Farmer.AfterFarmerCookedRecipeEvent(index);
            EventBus.Fire(@event);
            return @event;
        }

        #endregion

        #region Game1 Events

        public static DetourEvent InitializeCallback(StaticContextAccessor context)
        {
            var game = WrappedGame;
            game.Version += ", " + AssemblyInfo.NICE_VERSION;
            game.Version += ", mods loaded: " + EventBus.mods.Count;
            game.Window.Title = "Stardew Valley - Version " + WrappedGame.Version;

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

        public static DetourEvent PerformClockUpdateCallback()
        {
            var @event = new PerformClockUpdateEvent();
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

        public static DetourEvent PostUpdateCallback(StaticContextAccessor accessor)
        {
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

        public DetourEvent UpdateTitleScreenCallback(GameTime gameTime)
        {
            var @event = new UpdateTitleScreenEvent(gameTime);
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

        public DetourEvent GameExitEventCallback(object sender, EventArgs e)
        {
            var @event = new GameExitEvent(sender, e);
            EventBus.Fire(@event);
            return @event;
        }

        public DetourEvent ClientSizeChangedCallback(object sender, EventArgs e)
        {
            var @event = new ClientSizeChangedEvent(sender, e);
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
    }
}