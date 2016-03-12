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
using Storm.StardewValley.Wrapper;

namespace Storm.Collections
{
    public class ValueProxyDictionary<TKey, TOValue, TValue> : System.Collections.Generic.IDictionary<TKey, TValue> where TValue : Wrapper
    {
        public delegate W Wrap<V, W>(V val);

        private readonly IDictionary real;
        private readonly Wrap<TOValue, TValue> wrapper;

        public ValueProxyDictionary(IDictionary real, Wrap<TOValue, TValue> wrapper)
        {
            this.real = real;
            this.wrapper = wrapper;
        }

        public ICollection<TKey> Keys
        {
            get
            {
                var list = new List<TKey>();
                foreach (var key in real.Keys)
                {
                    list.Add((TKey)key);
                }
                return list;
            }
        }

        public ICollection<TValue> Values
        {
            get
            {
                var list = new List<TValue>();
                foreach (var value in real.Values)
                {
                    list.Add(wrapper((TOValue)value));
                }
                return list;
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

        public TValue this[TKey key]
        {
            get
            {
                return wrapper((TOValue)real[key]);
            }

            set
            {
                real[key] = value.Underlying;
            }
        }

        public bool ContainsKey(TKey key)
        {
            return real.Contains(key);
        }

        public void Add(TKey key, TValue value)
        {
            real.Add(key, value.Underlying);
        }

        public bool Remove(TKey key)
        {
            if (!ContainsKey(key)) return false;
            real.Remove(key);
            return true;
        }

        public bool TryGetValue(TKey key, out TValue value)
        {
            if (!ContainsKey(key))
            {
                value = default(TValue);
                return false;
            }
            value = this[key];
            return true;
        }

        public void Add(KeyValuePair<TKey, TValue> item)
        {
            real.Add(item.Key, item.Value.Underlying);
        }

        public void Clear()
        {
            real.Clear();
        }

        public bool Contains(KeyValuePair<TKey, TValue> item)
        {
            foreach (var key in real.Keys)
            {
                if (key.Equals(item.Key) && real[key].Equals(item.Value.Underlying))
                {
                    return true;
                }
            }
            return false;
        }

        public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public bool Remove(KeyValuePair<TKey, TValue> item)
        {
            foreach (var key in real.Keys)
            {
                if (key.Equals(item.Key) && real[key].Equals(item.Value.Underlying))
                {
                    real.Remove(item.Key);
                    return true;
                }
            }
            return false;
        }

        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
            return new ProxyEnumerator<TKey, TOValue, TValue>(real, wrapper);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        private class ProxyEnumerator<EKey, EOValue, EValue> : IEnumerator<KeyValuePair<EKey, EValue>>
        {
            private IDictionary real;
            private Wrap<EOValue, EValue> wrapper;
            private int curIndex;

            private IList keys;
            private EKey curKey;
            private EOValue curValue;

            public ProxyEnumerator(IDictionary real, Wrap<EOValue, EValue> wrapper)
            {
                this.real = real;
                this.wrapper = wrapper;
                this.keys = new ArrayList();
                foreach (var key in real.Keys)
                {
                    this.keys.Add(key);
                }
                this.curIndex = -1;
                this.curKey = default(EKey);
                this.curValue = default(EOValue);
            }

            public KeyValuePair<EKey, EValue> Current
            {
                get { return new KeyValuePair<EKey, EValue>(curKey, wrapper(curValue)); }
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
                if (++curIndex >= keys.Count)
                {
                    return false;
                }
                else
                {
                    curKey = (EKey)keys[curIndex];
                    curValue = (EOValue)real[curKey];
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