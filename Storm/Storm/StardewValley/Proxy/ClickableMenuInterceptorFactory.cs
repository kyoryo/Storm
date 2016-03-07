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
    public class ClickableMenuInterceptorFactory : InterceptorDelegateFactory<ClickableMenuDelegate>
    {
        public delegate void DrawDelegate(SpriteBatch b);
        public delegate void PerformHoverActionDelegate(int x, int y);
        public delegate bool ReadyToCloseDelegate();
        public delegate void ReceiveKeyPressDelegate(Keys key);
        public delegate void ReceiveLeftClickDelegate(int x, int y, bool playSound = true);
        public delegate void ReceiveRightClickDelegate(int x, int y, bool playSound = true);
        public delegate void ReceiveScrollWheelActionDelegate(int direction);

        private readonly string drawName;
        private readonly string performHoverActionName;
        private readonly string readyToCloseName;
        private readonly string receiveKeyPressName;
        private readonly string receiveLeftClickName;
        private readonly string receiveRightClickName;
        private readonly string receiveScrollWheelActionName;

        public ClickableMenuInterceptorFactory(
            StaticContext parent,
            string drawName, 
            string performHoverActionName, 
            string readyToCloseName, 
            string receiveKeyPressName, 
            string receiveLeftClickName,
            string receiveRightClickName,
            string receiveScrollWheelActionName)
        {
            this.Parent = parent;
            this.drawName = drawName;
            this.performHoverActionName = performHoverActionName;
            this.readyToCloseName = readyToCloseName;
            this.receiveKeyPressName = receiveKeyPressName;
            this.receiveLeftClickName = receiveLeftClickName;
            this.receiveRightClickName = receiveRightClickName;
            this.receiveScrollWheelActionName = receiveScrollWheelActionName;
        }

        private StaticContext Parent { get; }

        public IInterceptor CreateInterceptor(ClickableMenuDelegate t)
        {
            return new ClickableMenuInterceptor(Parent, drawName, performHoverActionName, readyToCloseName, 
                receiveKeyPressName, receiveLeftClickName, receiveRightClickName, receiveScrollWheelActionName,
                t.Draw, t.PerformHoverAction, t.ReadyToClose, t.ReceiveKeyPress, t.ReceiveLeftClick, t.ReceiveRightClick, 
                t.ReceiveScrollWheelAction);
        }

        private class ClickableMenuInterceptor : IInterceptor
        {
            private readonly string drawName;
            private readonly string performHoverActionName;
            private readonly string readyToCloseName;
            private readonly string receiveKeyPressName;
            private readonly string receiveLeftClickName;
            private readonly string receiveRightClickName;
            private readonly string receiveScrollWheelActionName;

            private readonly DrawDelegate drawDelegate;
            private readonly PerformHoverActionDelegate performHoverActionDelegate;
            private readonly ReadyToCloseDelegate readyToCloseDelegate;
            private readonly ReceiveKeyPressDelegate receiveKeyPressDelegate;
            private readonly ReceiveLeftClickDelegate receiveLeftClickDelegate;
            private readonly ReceiveRightClickDelegate receiveRightClickDelegate;
            private readonly ReceiveScrollWheelActionDelegate receiveScrollWheelDelegate;

            public ClickableMenuInterceptor(
                StaticContext parent,
                string drawName,
                string performHoverActionName,
                string readyToCloseName,
                string receiveKeyPressName,
                string receiveLeftClickName,
                string receiveRightClickName,
                string receiveScrollWheelActionName,

                DrawDelegate drawDelegate,
                PerformHoverActionDelegate performHoverActionDelegate,
                ReadyToCloseDelegate readyToCloseDelegate,
                ReceiveKeyPressDelegate receiveKeyPressDelegate,
                ReceiveLeftClickDelegate receiveLeftClickDelegate,
                ReceiveRightClickDelegate receiveRightClickDelegate,
                ReceiveScrollWheelActionDelegate receiveScrollWheelDelegate)
            {
                this.Parent = parent;
                this.drawName = drawName;
                this.performHoverActionName = performHoverActionName;
                this.readyToCloseName = readyToCloseName;
                this.receiveKeyPressName = receiveKeyPressName;
                this.receiveLeftClickName = receiveLeftClickName;
                this.receiveRightClickName = receiveRightClickName;
                this.receiveScrollWheelActionName = receiveScrollWheelActionName;

                this.drawDelegate = drawDelegate;
                this.performHoverActionDelegate = performHoverActionDelegate;
                this.readyToCloseDelegate = readyToCloseDelegate;
                this.receiveKeyPressDelegate = receiveKeyPressDelegate;
                this.receiveLeftClickDelegate = receiveLeftClickDelegate;
                this.receiveRightClickDelegate = receiveRightClickDelegate;
                this.receiveScrollWheelDelegate = receiveScrollWheelDelegate;
            }

            private StaticContext Parent { get; }

            public void Intercept(IInvocation invocation)
            {
                var method = invocation.Method;
                var name = method.Name;
                var args = invocation.Arguments;
                if (name == drawName)
                {
                    drawDelegate((SpriteBatch)args[0]);
                }
                else if (name == performHoverActionName)
                {
                    performHoverActionDelegate((int)args[0], (int)args[1]);
                }
                else if (name == readyToCloseName)
                {
                    invocation.ReturnValue = readyToCloseDelegate();
                }
                else if (name == receiveKeyPressName)
                {
                    receiveKeyPressDelegate((Keys)args[0]);
                }
                else if (name == receiveLeftClickName)
                {
                    receiveLeftClickDelegate((int)args[0], (int)args[1], (bool)args[2]);
                }
                else if (name == receiveRightClickName)
                {
                    receiveRightClickDelegate((int)args[0], (int)args[1], (bool)args[2]);
                }
                else if (name == receiveScrollWheelActionName)
                {
                    receiveScrollWheelDelegate((int)args[0]);
                }
                else
                {
                    invocation.Proceed();
                }
            }
        }
    }
}
