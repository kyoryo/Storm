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
    public class WrappedProxyList<TOValue, TValue> : System.Collections.Generic.IList<TValue> where TValue : Wrapper
    {
        public delegate W Wrap<V, W>(V val);

        private readonly IList real;
        private readonly Wrap<TOValue, TValue> wrapper;

        public WrappedProxyList(IList real, Wrap<TOValue, TValue> wrapper)
        {
            this.real = real;
            this.wrapper = wrapper;
        }

        internal IList Real
        {
            get
            {
                return real;
            }
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
                return wrapper((TOValue)real[index]);
            }

            set
            {
                real[index] = value == null ? null : value.Underlying;
            }
        }

        public int IndexOf(TValue item)
        {
            return real.IndexOf(item.Underlying);
        }

        public void Insert(int index, TValue item)
        {
            real.Insert(index, item == null ? null : item.Underlying);
        }

        public void RemoveAt(int index)
        {
            real.RemoveAt(index);
        }

        public void Add(TValue item)
        {
            real.Add(item == null ? null : item.Underlying);
        }

        public void Clear()
        {
            real.Clear();
        }

        public bool Contains(TValue item)
        {
            return real.Contains(item.Underlying);
        }

        public void CopyTo(TValue[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public bool Remove(TValue item)
        {
            if (!Contains(item)) return false;
            real.Remove(item.Underlying);
            return true;
        }

        public IEnumerator<TValue> GetEnumerator()
        {
            return new ProxyEnumerator<TOValue, TValue>(real, wrapper);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        private class ProxyEnumerator<EOValue, EValue> : IEnumerator<EValue>
        {
            private IList real;
            private Wrap<EOValue, EValue> wrapper;
            private int curIndex;
            private EOValue curValue;

            public ProxyEnumerator(IList real, Wrap<EOValue, EValue> wrapper)
            {
                this.real = real;
                this.wrapper = wrapper;
                this.curIndex = -1;
                this.curValue = default(EOValue);
            }

            public EValue Current
            {
                get { return wrapper(curValue); }
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
                    curValue = (EOValue)real[curIndex];
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
