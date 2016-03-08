using Storm.StardewValley.Wrapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storm
{
    public class ProxyDictionary<TKey, TValue, TWrapper> 
    {
        public delegate W Wrap<V, W>(V val);

        private System.Collections.IDictionary real;
        private Wrap<TValue, TWrapper> wrapper;

        public ProxyDictionary(System.Collections.IDictionary real, Wrap<TValue, TWrapper> wrapper)
        {
            this.real = real;
            this.wrapper = wrapper;
        }

        public int Count
        {
            get { return real.Count; }
        }

        public void Add<T>(TKey key, Wrapper<T> value)
        {
            real.Add(key, value.Expose());
        }

        public void Remove(TKey key)
        {
            real.Remove(key);
        }

        public TWrapper Get(TKey key)
        {
            return wrapper((TValue)real[key]);
        }

        public void Clear()
        {
            real.Clear();
        }
    }
}
