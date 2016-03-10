/*
    Copyright 2016 Inari-Whitebear

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

namespace Storm.StardewValley.Wrapper
{
    public abstract class ChildWrapper<T> : Wrapper
    {
        public T Parent { get; set; }

        public ChildWrapper(T parent)
        {
            Parent = parent;
        }

        public ChildWrapper()
        {
        }

        public new T2 As<T2, A>() where T2 : ChildWrapper<T>
        {
            if (!Is<A>()) return null;
            return (T2)Activator.CreateInstance(typeof(T2), new object[] { Parent, Cast<A>() });
        }

        public new T2 As<T2, A>(T2 instance) where T2 : ChildWrapper<T>
        {
            if (!Is<A>()) return null;
            instance.Parent = (T)Parent;
            instance.Accessor = Cast<A>();
            return instance as T2;
        }
    }
}
