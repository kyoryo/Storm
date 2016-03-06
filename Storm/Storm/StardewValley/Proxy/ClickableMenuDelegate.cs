using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Storm.StardewValley.Wrapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storm.StardewValley.Proxy
{
    public abstract class ClickableMenuDelegate : TypeDelegate<ClickableMenu>
    {
        public abstract void Draw(SpriteBatch b);

        public abstract void PerformHoverAction(int x, int y);

        public abstract bool ReadyToClose();

        public abstract void ReceiveKeyPress(Keys key);

        public abstract void ReceiveLeftClick(int x, int y, bool playSound = true);

        public abstract void ReceiveRightClick(int x, int y, bool playSound = true);

        public abstract void ReceiveScrollWheelAction(int direction);

    }
}
