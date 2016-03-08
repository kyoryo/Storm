using Storm.StardewValley.Wrapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storm
{
    public class ProxyList<TValue, TWrapper>
    {
        public delegate W Wrap<V, W>(V val);

        private System.Collections.IList real;
        private Wrap<TValue, TWrapper> wrapper;

        public ProxyList(System.Collections.IList real, Wrap<TValue, TWrapper> wrapper)
        {
            this.real = real;
            this.wrapper = wrapper;
        }

        public int Count
        {
            get { return real.Count; }
        }

        public void Add<T>(Wrapper<T> value)
        {
            real.Add(value.Expose());
        }

        public void RemoveAt(int index)
        {
            real.RemoveAt(index);
        }

        public void Remove<T>(Wrapper<T> value)
        {
            real.Remove(value.Expose());
        }
    }
}
