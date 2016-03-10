using System;
using System.Collections;
using System.Collections.Generic;
using Storm.StardewValley.Wrapper;

namespace Storm
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
                throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}