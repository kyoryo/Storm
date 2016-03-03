using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace gAyPI.Manipulation
{
    public sealed class InjectorMetaData
    {
        private InjectorMetaData() { }

        public static string AccessorToGameType<T>(List<Injector> list)
        {
            foreach (var injector in list)
            {
                var @params = injector.GetParams();
                if (@params is InterfaceParams)
                {
                    var casted = (InterfaceParams)@params;
                    if (casted.InterfaceType == typeof(T).FullName)
                    {
                        return casted.OwnerType;
                    }
                }
            }
            return null;
        }

        public static Type AccessorToGameType<T>(List<Injector> list, Assembly asm)
        {
            var matching = AccessorToGameType<T>(list);
            if (matching == null) return null;
            return asm.GetType(matching);
        }

        public static string NameOfMethod(List<Injector> list, string type, string refactored)
        {
            foreach (var injector in list)
            {
                var @params = injector.GetParams();
                if (@params is MethodInfoParams)
                {
                    var casted = (MethodInfoParams)@params;
                    if (casted.OwnerAccessorType == type && casted.RefactoredName == refactored)
                    {
                        return casted.MethodName;
                    }
                }
            }
            return null;
        }

        public static string NameOfMethod<T>(List<Injector> list, string refactored)
        {
            return NameOfMethod(list, typeof(T).FullName, refactored);
        }
    }
}
