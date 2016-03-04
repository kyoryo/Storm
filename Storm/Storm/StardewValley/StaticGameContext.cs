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

        public static void InitializeCallback()
        {
            var game = StaticGameContext.WrappedGame;
            game.Version += ", " + AssemblyInfo.NICE_VERSION;
            game.Version += ", mods loaded: " + EventBus.mods.Count;
            game.Window.Title = "Stardew Valley - Version " + StaticGameContext.WrappedGame.Version;

            var @event = new InitializeEvent();
            EventBus.Fire<InitializeEvent>(@event);
        }

        public static void LoadContentCallback()
        {
            var @event = new LoadContentEvent();
            EventBus.Fire<LoadContentEvent>(@event);
        }

        public static void PreDrawCallback()
        {
            var @event = new PreRenderEvent();
            EventBus.Fire<PreRenderEvent>(@event);
        }

        public static void PreUIDrawCallback()
        {
            var @event = new PreUIRenderEvent();
            EventBus.Fire<PreUIRenderEvent>(@event);
        }

        public static void PostDrawCallback()
        {
            var @event = new PostRenderEvent();
            EventBus.Fire<PostRenderEvent>(@event);
        }

        public static void SeasonChangeCallback()
        {
            var @event = new OnSeasonChangeEvent();
            EventBus.Fire<OnSeasonChangeEvent>(@event);
        }

        public static void NewDayCallback()
        {
            var @event = new OnNewDayEvent();
            EventBus.Fire<OnNewDayEvent>(@event);
        }

        public static DetourEvent PerformClockUpdateCallback()
        {
            var @event = new PerformClockUpdateEvent();
            EventBus.Fire<PerformClockUpdateEvent>(@event);
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
            var @event = new AddItemToInventoryEvent(new Farmer(farmer), new Item(item));
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
            var @event = new WarpFarmerEvent(location, tileX, tileY, facingDirection, isStructure);
            EventBus.Fire<WarpFarmerEvent>(@event);
            return @event;
        }

        public static ToolAccessor ProxyTool(ToolDelegate @delegate)
        {
            var generator = new ProxyGenerator();
            var accessor = (ToolAccessor)generator.CreateClassProxy(ToolType, ToolFactory.CreateInterceptor(@delegate));
            @delegate.Accessor = accessor;
            return accessor;
        }
    }
}
