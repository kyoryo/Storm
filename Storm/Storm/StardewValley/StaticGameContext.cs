using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Storm.StardewValley;
using Storm.StardewValley.Accessor;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System.Reflection;
using Castle.DynamicProxy;
using Microsoft.Xna.Framework.Input;
using Storm.Manipulation;
using System.Diagnostics;
using Storm.ExternalEvent;
using Storm.StardewValley.Event;
using Storm.StardewValley.Wrapper;

namespace Storm.StardewValley
{
    public sealed class StaticGameContext
    {
        private StaticGameContext() { }

        public static Assembly Assembly
        {
            get; set;
        }
        public static ProgramAccessor Root
        {
            get; set;
        }
        public static Type ToolType
        {
            get; set;
        }
        public static ToolInterceptorDelegateFactory ToolFactory
        {
            get; set;
        }
        public static ModEventBus EventBus
        {
            get; set;
        }

        public static StaticContext WrappedGame
        {
            get { return new StaticContext(Root._GetGame());  }
        }

        public static void InitializeCallback()
        {
            var @event = new InitializeEvent();
            EventBus.Fire<InitializeEvent>(@event);
        }

        public static void DrawLastCallback()
        {
            var @event = new PostRenderEvent();
            EventBus.Fire<PostRenderEvent>(@event);
        }

        public static DetourEvent PerformClockUpdateCallback(StaticContextAccessor source)
        {
            var @event = new PerformClockUpdateEvent();
            EventBus.Fire<PerformClockUpdateEvent>(@event);
            return @event;
        }

        public static DetourEvent PerformClockUpdateCallback()
        {
            var @event = new PerformClockUpdateEvent();
            EventBus.Fire<PerformClockUpdateEvent>(@event);
            return @event;
        }

        public static ToolAccessor ProxyTool(ToolDelegate @delegate)
        {
            var generator = new ProxyGenerator();
            return (ToolAccessor)generator.CreateClassProxy(ToolType, ToolFactory.CreateInterceptor(@delegate));
        }
    }
}
