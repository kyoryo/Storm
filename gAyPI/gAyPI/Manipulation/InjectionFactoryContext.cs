using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace gAyPI.Manipulation
{
    public class InjectionFactoryContext
    {
        public delegate Assembly ConcreteCreator();

        public ConcreteCreator GetConcreteAssembly { get; set; }
        public List<Injector> Injectors { get; set; }
    }
}
