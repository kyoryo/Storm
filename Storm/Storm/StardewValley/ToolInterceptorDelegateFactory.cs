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

using System;
using Castle.DynamicProxy;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Storm.StardewValley
{
    public class ToolInterceptorDelegateFactory : InterceptorDelegateFactory<ToolDelegate>
    {
        public delegate void DrawInMenuDelegate(SpriteBatch b, Vector2 loc, float scaleSize, float transparency, float layerDepth, bool drawStackNumber);

        private string drawInMenuName;

        private class ToolInterceptor : IInterceptor
        {
            private string drawInMenuName;
            private DrawInMenuDelegate drawInMenuDelegate;

            public ToolInterceptor(string getNameMethodName, DrawInMenuDelegate drawInMenuDelegate)
            {
                this.drawInMenuName = getNameMethodName;
                this.drawInMenuDelegate = drawInMenuDelegate;
            }

            public void Intercept(IInvocation invocation)
            {
                var method = invocation.Method;
                if (method.Name == drawInMenuName)
                {
                    var args = invocation.Arguments;
                    drawInMenuDelegate((SpriteBatch)args[0], (Vector2)args[1], (float)args[2], (float)args[3], (float)args[4], (bool)args[5]);
                    return;
                }

                invocation.Proceed();
            }
        }

        public ToolInterceptorDelegateFactory(string getNameMethodName)
        {
            this.drawInMenuName = getNameMethodName;
        }

        public IInterceptor CreateInterceptor(ToolDelegate t)
        {
            return new ToolInterceptor(drawInMenuName, t.DrawInMenu);
        }
    }
}
