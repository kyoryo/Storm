using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

using Mono.Cecil;
using System.IO;

namespace Storm.Manipulation.Cecil
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
                selfAssembly = AssemblyDefinition.ReadAssembly("StormLoader.exe");
            }
        }

        protected override void UpdatePath(string path)
        {
            this.gameAssembly = AssemblyDefinition.ReadAssembly(path);
        }

        public override Injector CreateInterfaceInjector(InterfaceParams @params)
        {
            CheckSelf();
            return new CecilInterfaceInjector(selfAssembly, gameAssembly, @params);
        }

        public override Injector CreateFieldDetourInjector(FieldDetourParams @params)
        {
            CheckSelf();
            return new CecilFieldDetourInjector(selfAssembly, gameAssembly, @params);
        }

        public override Injector CreateFieldAccessorInjector(FieldAccessorParams @params)
        {
            CheckSelf();
            return new CecilFieldAccessorInjector(selfAssembly, gameAssembly, @params);
        }

        public override Injector CreateFieldMutatorInjector(FieldMutatorParams @params)
        {
            CheckSelf();
            return new CecilFieldMutatorInjector(selfAssembly, gameAssembly, @params);
        }

        public override Injector CreateInvokerInjector(InvokerParams @params)
        {
            CheckSelf();
            return new CecilInvokerInjector(selfAssembly, gameAssembly, @params);
        }

        public override Injector CreateAbsoluteCallInjector(AbsoluteCallParams @params)
        {
            CheckSelf();
            return new CecilAbsoluteCallInjector(selfAssembly, gameAssembly, @params);
        }

        public override Injector CreateEventCallbackInjector(EventCallbackParams @params)
        {
            CheckSelf();
            return new CecilEventCallbackInjector(selfAssembly, gameAssembly, @params);
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
