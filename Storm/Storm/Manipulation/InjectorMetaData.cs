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

using System;
using System.Collections.Generic;
using System.Reflection;

namespace Storm.Manipulation
{
    public sealed class InjectorMetaData
    {
        private InjectorMetaData()
        {
        }

        public static string AccessorToGameType<T>(List<Injector> list)
        {
            foreach (var injector in list)
            {
                var @params = injector.GetParams();
                if (@params is InterfaceParams)
                {
                    var casted = (InterfaceParams) @params;
                    if (casted.InterfaceType == typeof (T).FullName)
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
                    var casted = (MethodInfoParams) @params;
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
            return NameOfMethod(list, typeof (T).FullName, refactored);
        }

        public static string NameOfMethod(Type t, List<Injector> list, string refactored)
        {
            return NameOfMethod(list, t.FullName, refactored);
        }
    }
}