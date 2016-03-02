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

        public static void DrawLastCallback()
        {
            var game = root._GetGame();
            var batch = game._GetSpriteBatch();
            var font = game._GetSmoothFont();
            batch.DrawString(font, "Ayyy", new Vector2(16, 16), Color.Red);
            /*var tileSize = game._GetTileSize();
            var viewport = game._GetViewport();
            var player = root._GetGame()._GetPlayer();
            var pos = player._GetPosition();
            var loc = game._GetCurrentLocation();
            if (loc != null)
            {
                var objects = loc._GetObjects();
                for (int x = 0; x < 64; x++)
                {
                    for (int y = 0; y < 64; y++)
                    {
                        var key = new Vector2(x, y);
                        if (objects.Contains(key))
                        {
                            batch.DrawString(font, String.Format("{0}", (objects[key] as ObjectAccessor)._GetName()), new Vector2(x * tileSize - viewport.X, y * tileSize - viewport.Y), Color.Red);
                        }
                    }
                }
            }*/

            /* (Keyboard.GetState().IsKeyDown(Keys.X))
            {
                player._SetPosition(new Vector2(pos.X + 5, pos.Y));
            }*/
        }

        public static ToolAccessor ProxyTool(ToolDelegate @delegate)
        {
            var generator = new ProxyGenerator();
            return (ToolAccessor)generator.CreateClassProxy(toolType, toolFactory.CreateInterceptor(@delegate));
        }
    }
}
