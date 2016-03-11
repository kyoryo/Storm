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
using Storm.StardewValley.Accessor;
using Storm.StardewValley.Wrapper;
using Storm.StardewValley.Proxy;

namespace Subclass_Test_Mod
{
    [Mod]
    public class SubclassTestMod : DiskResource
    {
        private bool pressedLast = false;

        private class CustomTool : ToolDelegate
        {
            public override OverrideEvent DrawInMenu(object[] @params)
            {
                var batch = (SpriteBatch)@params[0];
                var loc = (Vector2)@params[1];
                batch.DrawString(Accessor.Parent.SmoothFont, "le custom draw override", loc, Color.Red);
                return new OverrideEvent { ReturnEarly = true };
            }
        }

        private class CustomObject : StandardObjectDelegate
        {
            public CustomObject() :
                base(Vector2.Zero, 3, 2)
            {
            }
        }

        [Subscribe]
        public void PostRenderCallback(PostRenderEvent @event)
        {
            var root = @event.Root;
            var batch = root.SpriteBatch;
            var font = root.SmoothFont;

            var farmer = root.Player;
            if (farmer != null)
            {
                if (!pressedLast && Keyboard.GetState().IsKeyDown(Keys.X))
                {
                    pressedLast = true;

                    var customTool = @event.Proxy<ToolAccessor, Tool>(new CustomTool());
                    customTool.Name = "Tool name!";
                    customTool.Description = "Tool Desc! Pretty gooood.";
                    farmer.SetItem(0, customTool);

                    var customObject = @event.Proxy<ObjectAccessor, ObjectItem>(new CustomObject());
                    customObject.Name = "Object name!";
                    farmer.SetItem(1, customObject);
                }
                else if (!Keyboard.GetState().IsKeyDown(Keys.X))
                {
                    pressedLast = false;
                }
            }
        }
    }
}
