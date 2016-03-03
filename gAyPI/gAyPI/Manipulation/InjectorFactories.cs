using gAyPI.Manipulation.Cecil;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gAyPI.Manipulation
{
    public sealed class InjectorFactories
    {
        private InjectorFactories() { }

        public static InjectorFactory Create(InjectorFactoryType type, string path)
        {
            switch (type)
            {
                case InjectorFactoryType.Cecil:
                    return new CecilInjectorFactory(path);
            }
            throw new NotSupportedException(string.Format("Unsupported factory type {0}", type));
        }
    }
}
