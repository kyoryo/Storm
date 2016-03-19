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
using System.Collections;
using System.Collections.Generic;

namespace Storm.Collections
{
    public class ProxyList<TValue> : IList<TValue>
    {
        private readonly IList real;

        public ProxyList(IList real)
        {
            this.real = real;
        }

        public int Count => real.Count;

        public bool IsReadOnly => false;

        public TValue this[int index]
        {
            get { return (TValue) real[index]; }

            set { real[index] = value; }
        }

        public int IndexOf(TValue item)
        {
            return real.IndexOf(item);
        }

        public void Insert(int index, TValue item)
        {
            real.Insert(index, item);
        }

        public void RemoveAt(int index)
        {
            real.RemoveAt(index);
        }

        public void Add(TValue item)
        {
            real.Add(item);
        }

        public void Clear()
        {
            real.Clear();
        }

        public bool Contains(TValue item)
        {
            return real.Contains(item);
        }

        public void CopyTo(TValue[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public bool Remove(TValue item)
        {
            if (!Contains(item)) return false;
            real.Remove(item);
            return true;
        }

        public IEnumerator<TValue> GetEnumerator()
        {
            return new ProxyEnumerator<TValue>(real);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        private class ProxyEnumerator<EValue> : IEnumerator<EValue>
        {
            private readonly IList real;
            private int curIndex;

            public ProxyEnumerator(IList real)
            {
                this.real = real;
                curIndex = -1;
                Current = default(EValue);
            }

            public EValue Current { get; private set; }

            object IEnumerator.Current => Current;

            public void Dispose()
            {
                throw new NotImplementedException();
            }

            public bool MoveNext()
            {
                if (++curIndex >= real.Count)
                {
                    return false;
                }
                Current = (EValue) real[curIndex];
                return true;
            }

            public void Reset()
            {
                curIndex = -1;
            }
        }
    }
}