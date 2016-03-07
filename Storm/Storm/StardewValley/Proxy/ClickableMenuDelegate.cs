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
