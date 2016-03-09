/*
    Copyright 2016 Cody R. (Demmonic)

    Storm is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    Storm is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with Storm.  If not, see <http://www.gnu.org/licenses/>.
 */

using System.IO;
using System.Reflection;
using Mono.Cecil;
using System;

namespace Storm.Manipulation.Cecil
{
    public class CecilInjectorFactory : InjectorFactory
    {
        private Assembly refAssembly;

        public CecilInjectorFactory()
        {
        }

        public CecilInjectorFactory(string path) : base(path)
        {
        }

        public AssemblyDefinition SelfAssembly { get; private set; }
        public AssemblyDefinition GameAssembly { get; private set; }

        private void CheckSelf()
        {
            if (SelfAssembly == null)
            {
                SelfAssembly = AssemblyDefinition.ReadAssembly("StormLoader.exe");
            }
        }

        protected override void UpdatePath(string path)
        {
            GameAssembly = AssemblyDefinition.ReadAssembly(path);
        }

        public override Injector CreateInterfaceInjector(InterfaceParams @params)
        {
            CheckSelf();
            return new CecilInterfaceInjector(SelfAssembly, GameAssembly, @params);
        }

        public override Injector CreateFieldDetourInjector(FieldDetourParams @params)
        {
            CheckSelf();
            return new CecilFieldDetourInjector(SelfAssembly, GameAssembly, @params);
        }

        public override Injector CreateFieldAccessorInjector(FieldAccessorParams @params)
        {
            CheckSelf();
            return new CecilFieldAccessorInjector(SelfAssembly, GameAssembly, @params);
        }

        public override Injector CreateFieldMutatorInjector(FieldMutatorParams @params)
        {
            CheckSelf();
            return new CecilFieldMutatorInjector(SelfAssembly, GameAssembly, @params);
        }

        public override Injector CreateFieldAccessorMutatorInjector(FieldAccessorMutatorParams @params)
        {
            CheckSelf();
            return new CecilFieldAccessorMutatorInjector(SelfAssembly, GameAssembly, @params);
        }

        public override Injector CreateInvokerInjector(InvokerParams @params)
        {
            CheckSelf();
            return new CecilInvokerInjector(SelfAssembly, GameAssembly, @params);
        }

        public override Injector CreateAbsoluteCallInjector(AbsoluteCallParams @params)
        {
            CheckSelf();
            return new CecilAbsoluteCallInjector(SelfAssembly, GameAssembly, @params);
        }

        public override Injector CreateEventCallbackInjector(EventCallbackParams @params)
        {
            CheckSelf();
            return new CecilEventCallbackInjector(SelfAssembly, GameAssembly, @params);
        }

        public override Assembly ToConcrete()
        {
            if (refAssembly != null) return refAssembly;
            using (var strum = new MemoryStream())
            {
                GameAssembly.Name.Name = "Storm-Hooked-Game";
                GameAssembly.Write(strum);
                using (var strum2 = new FileStream("Storm-Hooked-Game.exe", FileMode.Create, FileAccess.Write))
                {
                    GameAssembly.Write(strum2);
                }

                var domain = AppDomain.CreateDomain("Game Domain");
                domain.UnhandledException += Logging.UnhandledExceptionHandler;
                refAssembly = domain.Load(strum.GetBuffer());
            }
            return refAssembly;
        }

        public void WriteModifiedAssembly(Stream @out)
        {
            GameAssembly.Write(@out);
        }
    }
}