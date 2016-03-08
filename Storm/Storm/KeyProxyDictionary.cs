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
    public class KeyProxyDictionary<TKey, TValue>
    {
        private System.Collections.IDictionary real;

        public KeyProxyDictionary(System.Collections.IDictionary real)
        {
            this.real = real;
        }

        public int Count
        {
            get { return real.Count; }
        }

        public void Add<T>(Wrapper<T> key, TValue value)
        {
            real.Add(key.Expose(), value);
        }

        public void Remove(Wrapper<TKey> key)
        {
            real.Remove(key.Expose());
        }

        public TValue Get(Wrapper<TKey> key)
        {
            return (TValue)real[key.Expose()];
        }

        public void Clear()
        {
            real.Clear();
        }
    }
}
