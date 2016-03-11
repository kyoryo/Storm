/*
    Copyright 2016 Cody R. (Demmonic), Inari-Whitebear

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
using Storm.StardewValley.Proxy;
using Storm.StardewValley.Wrapper;
using System.Collections.Generic;

namespace Storm.StardewValley
{
    public class StaticContextEvent : DetourEvent
    {
        public delegate void InitDelegate(StaticContextEvent @this);
        public delegate InterceptorFactory<DType> CreateFactoryDelegate<AType, DType>();

        public void Init(InitDelegate init)
        {
            init(this);
        }

        public Assembly GameAssembly { get; set; }
        public StaticContext Root { get; set; }
        public ModEventBus EventBus { get; set; }

        public Farmer LocalPlayer
        {
            get { return Root.Player; }
        }

        public GameLocation Location
        {
            get { return Root.CurrentLocation; }
        }

        public T Proxy<A, T>(TypeDelegate<T> @delegate, T instance) where T : StaticContextWrapper
        {
            instance.Parent = Root;
            instance.Underlying = StaticGameContext.ProxyAccessor<A, TypeDelegate<T>>(@delegate, @delegate.ConstructorParams.ToArray());
            @delegate.Accessor = instance;
            return instance;
        }

        public T Proxy<A, T>(TypeDelegate<T> @delegate) where T : StaticContextWrapper
        {
            T instance = Activator.CreateInstance<T>();
            return Proxy<A, T>(@delegate, instance);
        }
    }
}