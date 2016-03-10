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

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Storm.StardewValley.Wrapper;

namespace Storm.StardewValley.Proxy
{
    public abstract class ClickableMenuDelegate : TypeDelegate<ClickableMenu>
    {
        [ProxyMap(Name = "EmergencyShutDown")]
        public abstract void EmergencyShutDown();

        [ProxyMap(Name = "Draw")]
        public abstract void Draw(SpriteBatch b);

        [ProxyMap(Name = "PerformHoverAction")]
        public abstract void PerformHoverAction(int x, int y);

        [ProxyMap(Name = "ReadyToClose")]
        public abstract bool ReadyToClose();

        [ProxyMap(Name = "ReceiveGamePadButton")]
        public abstract void ReceiveGamePadButton(Buttons b);

        [ProxyMap(Name = "ReceiveKeyPress")]
        public abstract void ReceiveKeyPress(Keys key);

        [ProxyMap(Name = "ReceiveLeftClick")]
        public abstract void ReceiveLeftClick(int x, int y, bool playSound = true);

        [ProxyMap(Name = "ReceiveRightClick")]
        public abstract void ReceiveRightClick(int x, int y, bool playSound = true);

        [ProxyMap(Name = "ReceiveScrollWheelAction")]
        public abstract void ReceiveScrollWheelAction(int direction);

        [ProxyMap(Name = "Update")]
        public abstract void Update(GameTime time);
    }
}