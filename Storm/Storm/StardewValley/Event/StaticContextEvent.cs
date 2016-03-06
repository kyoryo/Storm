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
using System.Reflection;
using Castle.DynamicProxy;
using Storm.ExternalEvent;
using Storm.Manipulation;
using Storm.StardewValley.Accessor;
using Storm.StardewValley.Wrapper;
using Storm.StardewValley.Proxy;

namespace Storm.StardewValley
{
    public class StaticContextEvent : DetourEvent
    {
        public StaticContextEvent()
        {
            GameAssembly = StaticGameContext.Assembly;
            Root = StaticGameContext.WrappedGame;
            EventBus = StaticGameContext.EventBus;
            ToolType = StaticGameContext.ToolType;
            ToolFactory = StaticGameContext.ToolFactory;
        }

        public Assembly GameAssembly { get; }
        public StaticContext Root { get; }
        public ModEventBus EventBus { get; }
        public Type ToolType { get; }
        public ToolInterceptFactory ToolFactory { get; }

        public Tool ProxyTool(ToolDelegate @delegate)
        {
            var generator = new ProxyGenerator();
            var accessor = (ToolAccessor) generator.CreateClassProxy(ToolType, ToolFactory.CreateInterceptor(@delegate));
            var wrapped = new Tool(Root, accessor);
            @delegate.Accessor = wrapped;
            return wrapped;
        }

        public Farmer LocalPlayer
        {
            get { return Root.Player; }
        }

        public GameLocation Location
        {
            get { return Root.CurrentLocation; }
        }
    }
}