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
        private AssemblyDefinition selfAssembly = null;
        private AssemblyDefinition gameAssembly = null;
        private Assembly refAssembly = null;

        public CecilInjectorFactory() { }

        public CecilInjectorFactory(string path) : base(path) { }

        public AssemblyDefinition SelfAssembly { get { return selfAssembly; } }
        public AssemblyDefinition GameAssembly { get { return gameAssembly; } }

        private void CheckSelf()
        {
            if (selfAssembly == null)
            {
                selfAssembly = AssemblyDefinition.ReadAssembly("gAyPI.exe");
            }
        }

        protected override void UpdatePath(string path)
        {
            this.gameAssembly = AssemblyDefinition.ReadAssembly(path);
        }

        public override Injector CreateInterfaceInjector(InterfaceInjectorParams @params)
        {
            CheckSelf();
            return new CecilInterfaceInjector(selfAssembly, gameAssembly, @params);
        }

        public override Injector CreateFieldDetourInjector(FieldDetourInjectorParams @params)
        {
            CheckSelf();
            return new CecilFieldDetourInjector(selfAssembly, gameAssembly, @params);
        }

        public override Injector CreateFieldAccessorInjector(FieldAccessorInjectorParams @params)
        {
            CheckSelf();
            return new CecilFieldAccessorInjector(selfAssembly, gameAssembly, @params);
        }

        public override Injector CreateAbsoluteCallInjector(AbsoluteCallInjectorParams @params)
        {
            CheckSelf();
            return new CecilAbsoluteCallInjector(selfAssembly, gameAssembly, @params);
        }

        public override Assembly ToConcrete()
        {
            using (var strum = new MemoryStream())
            {
                gameAssembly.Write(strum);
                refAssembly = Assembly.Load(strum.GetBuffer());
            }
            return refAssembly;
        }
    }
}
