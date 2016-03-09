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
                real[index] = value.Expose();
            }
        }

        public int IndexOf(TValue item)
        {
            return real.IndexOf(item.Expose());
        }

        public void Insert(int index, TValue item)
        {
            real.Insert(index, item.Expose());
        }

        public void RemoveAt(int index)
        {
            real.RemoveAt(index);
        }

        public void Add(TValue item)
        {
            real.Add(item.Expose());
        }

        public void Clear()
        {
            real.Clear();
        }

        public bool Contains(TValue item)
        {
            return real.Contains(item.Expose());
        }

        public void CopyTo(TValue[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public bool Remove(TValue item)
        {
            if (!Contains(item)) return false;
            real.Remove(item.Expose());
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
