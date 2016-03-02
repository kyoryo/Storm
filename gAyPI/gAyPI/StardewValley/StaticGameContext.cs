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

namespace gAyPI.StardewValley
{
    class TestToolDelegate : ToolDelegate
    {
        public string GetName()
        {
            return "that's prettty goood";
        }
    }

    public sealed class StaticGameContext
    {
        private StaticGameContext() { }

        private static Assembly assembly = null;
        private static ProgramAccessor root = null;
        private static Type toolType = null;
        private static ToolInterceptorDelegateFactory toolFactory = null;

        public static Assembly Assembly { set { assembly = value; } }
        public static ProgramAccessor Root  { set { root = value; } }
        public static Type ToolType { set { toolType = value; } }
        public static ToolInterceptorDelegateFactory ToolFactory { set { toolFactory = value; } }

        private static bool downLast = false;

        public static void DrawLastCallback()
        {
            var batch = root._GetGame()._GetSpriteBatch();
            var font = root._GetGame()._GetSmoothFont();
            batch.DrawString(font, "gAyPI", new Vector2(16, 16), Color.Red);

            var down = Keyboard.GetState().IsKeyDown(Keys.X);
            if (down && !downLast)
            {
                var tool = ProxyTool(new TestToolDelegate());
                root._GetGame()._GetPlayer()._GetItems()[1] = tool;
                downLast = true;
            }
            else if (!down)
            {
                downLast = false;
            }
        }

        public static ToolAccessor ProxyTool(ToolDelegate @delegate)
        {
            var generator = new ProxyGenerator();
            return (ToolAccessor)generator.CreateClassProxy(toolType, toolFactory.CreateInterceptor(@delegate));
        }
    }
}
