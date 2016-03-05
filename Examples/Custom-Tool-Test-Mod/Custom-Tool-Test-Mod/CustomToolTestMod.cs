using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Storm.ExternalEvent;
using Storm.StardewValley;
using Storm.StardewValley.Event;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Custom_Tool_Test_Mod
{
    [Mod(Author = "Demmonic", Name = "Custom Tool Test", Version = 0.1D)]
    public class CustomToolTestMod : DiskResource
    {
        private bool pressedLast = false;

        private class CustomTool : ToolDelegate
        {
            public override void DrawInMenu(SpriteBatch b, Vector2 loc, float scaleSize, float transparency, float layerDepth, bool drawStackNumber)
            {
                b.DrawString(Accessor.Parent.SmoothFont, "le custom draw override", loc, Color.Red);
            }
        }

        [Subscribe]
        public void PostRenderCallback(PostRenderEvent @event)
        {
            var root = @event.Root;
            var batch = root.SpriteBatch;
            var font = root.SmoothFont;
            batch.DrawString(font, "Custom Tool - Example " + PathOnDisk, new Vector2(16, 16), Color.Red);
            if (!pressedLast && Keyboard.GetState().IsKeyDown(Keys.X))
            {
                pressedLast = true;
                var obj = @event.ProxyTool(new CustomTool());
                obj.Name = "Tool name!";
                obj.Description = "Tool Desc! Pretty gooood.";

                var farmer = root.Player;
                if (farmer != null)
                {
                    farmer.Items[1] = obj;
                }
            }
            else if (!Keyboard.GetState().IsKeyDown(Keys.X))
            {
                pressedLast = false;
            }
        }
    }
}
