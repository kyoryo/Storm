using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

using Mono.Cecil;
using System.IO;

namespace gAyPI.Manipulation
{
    public class CecilInjectorFactory : InjectorFactory
    {
        private AssemblyDefinition self = null;
        private AssemblyDefinition cecilAssembly = null;
        private Assembly refAssembly = null;

        public CecilInjectorFactory() { }

        public CecilInjectorFactory(string path) : base(path) { }

        private void CheckSelf()
        {
            if (self == null)
            {
                self = AssemblyDefinition.ReadAssembly("gAyPI.exe");
            }
        }

        protected override void UpdatePath(string path)
        {
            this.cecilAssembly = AssemblyDefinition.ReadAssembly(path);
        }

        protected override Injector CreateInterfaceInjector(InterfaceInjectorParams @params)
        {
            CheckSelf();
            return new CecilInterfaceInjector(self, cecilAssembly, @params);
        }

        protected override Injector CreateFieldDetourInjector(FieldDetourInjectorParams @params)
        {
            CheckSelf();
            return new CecilFieldDetourInjector(self, cecilAssembly, @params);
        }

        protected override Injector CreateFieldAccessorInjector(FieldAccessorInjectorParams @params)
        {
            CheckSelf();
            return new CecilFieldAccessorInjector(self, cecilAssembly, @params);
        }

        protected override Injector CreateAbsoluteCallInjector(AbsoluteCallInjectorParams @params)
        {
            CheckSelf();
            return new CecilAbsoluteCallInjector(self, cecilAssembly, @params);
        }

        protected override Assembly ToConcrete()
        {
            using (var strum = new MemoryStream())
            {
                cecilAssembly.Write(strum);
                refAssembly = Assembly.Load(strum.GetBuffer());
            }
            return refAssembly;
        }
    }
}
