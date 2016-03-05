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
using Castle.DynamicProxy;
using Storm.ExternalEvent;
using Storm.Manipulation;
using Storm.StardewValley.Accessor;
using Storm.StardewValley.Event;
using Storm.StardewValley.Wrapper;
using System;
using System.Reflection;

namespace Storm.StardewValley
{
    public sealed class StaticGameContext
    {
        private StaticGameContext() { }

        /// <summary>
        /// The Stardew Valley assembly
        /// </summary>
        public static Assembly Assembly { get; set; }

        /// <summary>
        /// Wrapped Stardew Valley Program class.
        /// </summary>
        public static ProgramAccessor Root { get; set; }

        public static Type ToolType { get; set; }

        public static ToolInterceptorDelegateFactory ToolFactory{ get; set; }

        /// <summary>
        /// Event handler for all Storm mods.
        /// </summary>
        public static ModEventBus EventBus { get; set; }

        /// <summary>
        /// Wrapped Stardew Valley Game class.
        /// </summary>
        public static StaticContext WrappedGame
        {
            get { return new StaticContext(Root._GetGame());  }
        }

        public static DetourEvent InitializeCallback(StaticContextAccessor context)
        {
            var game = StaticGameContext.WrappedGame;
            game.Version += ", " + AssemblyInfo.NICE_VERSION;
            game.Version += ", mods loaded: " + EventBus.mods.Count;
            game.Window.Title = "Stardew Valley - Version " + StaticGameContext.WrappedGame.Version;

            var @event = new InitializeEvent();
            EventBus.Fire<InitializeEvent>(@event);
            return @event;
        }

        public static DetourEvent LoadContentCallback(StaticContextAccessor context)
        {
            var @event = new LoadContentEvent();
            EventBus.Fire<LoadContentEvent>(@event);
            return @event;
        }

        public static DetourEvent PreDrawCallback(StaticContextAccessor context)
        {
            var @event = new PreRenderEvent();
            EventBus.Fire<PreRenderEvent>(@event);
            return @event;
        }

        public static DetourEvent PreUIDrawCallback(StaticContextAccessor context)
        {
            var @event = new PreUIRenderEvent();
            EventBus.Fire<PreUIRenderEvent>(@event);
            return @event;
        }

        public static DetourEvent PostDrawCallback(StaticContextAccessor context)
        {
            var batch = context._GetSpriteBatch();
            batch.Begin();

            var @event = new PostRenderEvent();
            EventBus.Fire<PostRenderEvent>(@event);

            batch.End();
            return @event;
        }

        public static DetourEvent SeasonChangeCallback()
        {
            var @event = new OnSeasonChangeEvent();
            EventBus.Fire<OnSeasonChangeEvent>(@event);
            return @event;
        }

        public static DetourEvent NewDayCallback()
        {
            var @event = new OnNewDayEvent();
            EventBus.Fire<OnNewDayEvent>(@event);
            return @event;
        }

        public static DetourEvent PerformClockUpdateCallback()
        {
            var @event = new PerformClockUpdateEvent();
            EventBus.Fire<PerformClockUpdateEvent>(@event);
            return @event;
        }

        public static DetourEvent OnUpdateGameClockCallback()
        {
            var @event = new OnUpdateGameClockEvent();
            EventBus.Fire<OnUpdateGameClockEvent>(@event);
            return @event;
        }

        public static DetourEvent SellShippedItemsCallback()
        {
            var @event = new SellShippedItemsEvent();
            EventBus.Fire<SellShippedItemsEvent>(@event);
            return @event;
        }

        public static DetourEvent AddItemToInventoryCallback(FarmerAccessor farmer, ItemAccessor item)
        {
            var @event = new AddItemToInventoryEvent(new Farmer(WrappedGame, farmer), new Item(WrappedGame, item));
            EventBus.Fire<AddItemToInventoryEvent>(@event);
            return @event;
        }

        public static DetourEvent PreUpdateCallback(StaticContextAccessor accessor)
        {
            var @event = new PreUpdateEvent();
            EventBus.Fire<PreUpdateEvent>(@event);
            return @event;
        }

        public static DetourEvent WarpFarmerCallback(GameLocationAccessor location, int tileX, int tileY, int facingDirection, bool isStructure)
        {
            var @event = new WarpFarmerEvent(new GameLocation(WrappedGame, location), tileX, tileY, facingDirection, isStructure);
            EventBus.Fire<WarpFarmerEvent>(@event);
            return @event;
        }
    }
}
