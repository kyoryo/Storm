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
using Storm.StardewValley.Accessor;
using Storm.StardewValley.Wrapper;

namespace Storm.StardewValley
{
    public class ToolInterceptorDelegateFactory : InterceptorDelegateFactory<ToolDelegate>
    {
        public delegate void DrawInMenuDelegate(SpriteBatch b, Vector2 loc, float scaleSize, float transparency, float layerDepth, bool drawStackNumber);
        public delegate void BeginUsingDelegate(GameLocation loc, int x, int y, Farmer farmer);

        private string drawInMenuName;
        private string beginUsingName;

        private StaticContext Parent { get; }

        private class ToolInterceptor : IInterceptor
        {
            private StaticContext Parent { get; }
            private string drawInMenuName;
            private DrawInMenuDelegate drawInMenuDelegate;

            private string beginUsingName;
            private BeginUsingDelegate beginUsingDelegate;

            public ToolInterceptor(
                StaticContext parent,
                string getNameMethodName, DrawInMenuDelegate drawInMenuDelegate, 
                string beginUsingName, BeginUsingDelegate beginUsingDelegate)
            {
                this.Parent = parent;
                this.drawInMenuName = getNameMethodName;
                this.drawInMenuDelegate = drawInMenuDelegate;
                this.beginUsingName = beginUsingName;
                this.beginUsingDelegate = beginUsingDelegate;
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
                else if (method.Name == beginUsingName)
                {
                    var args = invocation.Arguments;
                    var location = new GameLocation(Parent, (GameLocationAccessor)args[0]);
                    var farmer = new Farmer(Parent, (FarmerAccessor)args[3]);
                    beginUsingDelegate(location, (int)args[1], (int)args[2], farmer);
                    return;
                }

                invocation.Proceed();
            }
        }

        public ToolInterceptorDelegateFactory(StaticContext parent, string getNameMethodName, string beginUsingName)
        {
            this.Parent = parent;
            this.drawInMenuName = getNameMethodName;
            this.beginUsingName = beginUsingName;
        }

        public IInterceptor CreateInterceptor(ToolDelegate t)
        {
            return new ToolInterceptor(Parent, drawInMenuName, t.DrawInMenu, beginUsingName, t.BeginUsing);
        }
    }
}
