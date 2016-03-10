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

        public override T2 As<T2, A>()
        {
            if (!Is<A>()) return null;
            var instance = base.As<T2, A>();
            if (instance is ChildWrapper<T>)
            {
                (instance as ChildWrapper<T>).Parent = Parent;
            }
            return instance;
        }

        public override T2 As<T2, A>(T2 instance)
        {
            if (!Is<A>()) return null;
            base.As<T2, A>(instance);
            if (instance is ChildWrapper<T>)
            {
                (instance as ChildWrapper<T>).Parent = Parent;
            }
            return instance as T2;
        }
    }
}
