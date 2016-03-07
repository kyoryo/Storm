using Storm.Manipulation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storm.StardewValley.Event
{
    public class PreInjectionEvent : DetourEvent
    {
        public PreInjectionEvent(InjectorFactory factory, List<Injector> injectors)
        {
            this.InjectorFactory = factory;
            this.Injectors = injectors;
        }

        public InjectorFactory InjectorFactory { get; }
        public List<Injector> Injectors { get; }
    }
}
