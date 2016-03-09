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

using System.Collections;
using Storm.StardewValley.Wrapper;

namespace Storm
{
    public class DualProxyDictionary<TKey, TValue, TWrapper>
    {
        public delegate W Wrap<V, W>(V val);

        private readonly IDictionary real;
        private readonly Wrap<TValue, TWrapper> wrapper;

        public DualProxyDictionary(IDictionary real, Wrap<TValue, TWrapper> wrapper)
        {
            this.real = real;
            this.wrapper = wrapper;
        }

        public int Count
        {
            get { return real.Count; }
        }

        public bool Contains<T>(Wrapper key)
        {
            return real.Contains(key.Expose());
        }

        public void Add<T>(Wrapper key, Wrapper value)
        {
            real.Add(key.Expose(), value.Expose());
        }

        public void Remove(Wrapper key)
        {
            real.Remove(key.Expose());
        }

        public TWrapper Get(Wrapper key)
        {
            return wrapper((TValue) real[key.Expose()]);
        }

        public void Clear()
        {
            real.Clear();
        }
    }
}