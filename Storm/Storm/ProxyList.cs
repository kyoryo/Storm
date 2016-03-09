using System.Collections;
using Storm.StardewValley.Wrapper;

namespace Storm
{
    public class ProxyList<TValue, TWrapper>
    {
        public delegate W Wrap<V, W>(V val);

        private readonly IList real;

        public ProxyList(IList real)
        {
            this.real = real;
        }

        public int Count
        {
            get { return real.Count; }
        }

        public void Add(Wrapper value)
        {
            real.Add(value.Expose());
        }

        public void RemoveAt(int index)
        {
            real.RemoveAt(index);
        }

        public void Remove(Wrapper value)
        {
            real.Remove(value.Expose());
        }

        public void Clear()
        {
            real.Clear();
        }
    }
}