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

using Storm.StardewValley.Wrapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storm
{
    public class DualProxyDictionary<TKey, TValue, TWrapper>
    {
        public delegate W Wrap<V, W>(V val);

        private System.Collections.IDictionary real;
        private Wrap<TValue, TWrapper> wrapper;

        public DualProxyDictionary(System.Collections.IDictionary real, Wrap<TValue, TWrapper> wrapper)
        {
            this.real = real;
            this.wrapper = wrapper;
        }

        public int Count
        {
            get { return real.Count; }
        }

        public void Add<T>(Wrapper<TKey> key, Wrapper<T> value)
        {
            real.Add(key.Expose(), value.Expose());
        }

        public void Remove(Wrapper<TKey> key)
        {
            real.Remove(key.Expose());
        }

        public TWrapper Get(Wrapper<TKey> key)
        {
            return wrapper((TValue)real[key.Expose()]);
        }

        public void Clear()
        {
            real.Clear();
        }
    }
}
