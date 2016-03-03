using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using gAyPI.StardewValley;
using gAyPI.StardewValley.Accessor;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System.Reflection;
using Castle.DynamicProxy;
using Microsoft.Xna.Framework.Input;
using gAyPI.Manipulation;
using System.Diagnostics;
using gAyPI.ModLoader;
using gAyPI.StardewValley.Event;

namespace gAyPI.StardewValley
{
    public sealed class StaticGameContext
    {
        private StaticGameContext() { }

        private static Assembly assembly = null;
        private static ProgramAccessor root = null;
        private static Type toolType = null;
        private static ToolInterceptorDelegateFactory toolFactory = null;
        private static ModEventBus eventBus = null;

        public static Assembly Assembly { set { assembly = value; } }
        public static ProgramAccessor Root  { set { root = value; } }
        public static Type ToolType { set { toolType = value; } }
        public static ToolInterceptorDelegateFactory ToolFactory { set { toolFactory = value; } }
        public static ModEventBus EventBus { set { eventBus = value; } }

        public static void DrawLastCallback()
        {
            var game = root._GetGame();
            var batch = game._GetSpriteBatch();
            var font = game._GetSmoothFont();
            batch.DrawString(font, "Ayyy ", new Vector2(16, 16), Color.Red);
        }

        public static int TestCast(object o)
        {
            return (int)o;
        }

        public static DetourEvent PerformClockUpdateCallback(GameAccessor source)
        {
            var @event = new PerformClockUpdateEvent();
            eventBus.Fire<PerformClockUpdateEvent>(@event);
            return @event;
        }

        public static DetourEvent PerformClockUpdateCallback()
        {
            var @event = new PerformClockUpdateEvent();
            eventBus.Fire<PerformClockUpdateEvent>(@event);
            return @event;
        }

        public static ToolAccessor ProxyTool(ToolDelegate @delegate)
        {
            var generator = new ProxyGenerator();
            return (ToolAccessor)generator.CreateClassProxy(toolType, toolFactory.CreateInterceptor(@delegate));
        }
    }
}
