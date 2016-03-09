using System.Collections;
using Storm.StardewValley.Wrapper;

namespace Storm
{
    public class ProxyList<TValue, TWrapper>
    {
        public delegate W Wrap<V, W>(V val);

        private readonly IList real;
        private Wrap<TValue, TWrapper> wrapper;

        public ProxyList(IList real, Wrap<TValue, TWrapper> wrapper)
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

        public void Clear()
        {
            real.Clear();
        }
    }
}