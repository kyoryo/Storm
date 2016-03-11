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
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storm.Collections
{
    public class ProxyList<TValue> : System.Collections.Generic.IList<TValue>
    {
        private readonly IList real;

        public ProxyList(IList real)
        {
            this.real = real;
        }

        public int Count
        {
            get
            {
                return real.Count;
            }
        }

        public bool IsReadOnly
        {
            get
            {
                return false;
            }
        }

        public TValue this[int index]
        {
            get
            {
                return (TValue)real[index];
            }

            set
            {
                real[index] = value;
            }
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
            private IList real;
            private int curIndex;
            private EValue curValue;

            public ProxyEnumerator(IList real)
            {
                this.real = real;
                this.curIndex = -1;
                this.curValue = default(EValue);
            }

            public EValue Current
            {
                get { return curValue; }
            }

            object IEnumerator.Current
            {
                get { return curValue; }
            }

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
                else
                {
                    curValue = (EValue)real[curIndex];
                    return true;
                }
            }

            public void Reset()
            {
                curIndex = -1;
            }
        }
    }
}
