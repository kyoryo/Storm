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


        public static string NameOfMethod(List<Injector> list, string type, string refactored, string desc)
        {
            foreach (var injector in list)
            {
                var @params = injector.GetParams();
                if (@params is MethodInfoParams)
                {
                    var casted = (MethodInfoParams) @params;
                    if (casted.OwnerAccessorType == type && casted.RefactoredName == refactored && casted.MethodDesc == desc)
                    {
                        return casted.MethodName;
                    }
                }
            }
            return null;
        }

        public static string NameOfMethod<T>(List<Injector> list, string refactored, string desc)
        {
            return NameOfMethod(list, typeof(T).FullName, refactored, desc);
        }

        public static string NameOfMethod(Type t, List<Injector> list, string refactored, string desc)
        {
            return NameOfMethod(list, t.FullName, refactored, desc);
        }
        
        public static Dictionary<string, string> BuildTags(List<Injector> injectors)
        {
            var nameMap = new Dictionary<string, string>();
            foreach (var injector in injectors)
            {
                var @params = injector.GetParams();
                if (@params is InterfaceParams)
                {
                    var casted = (InterfaceParams)@params;
                    nameMap.Add(casted.SimpleName, casted.OwnerType);
                }
            }
            return nameMap;
        }

        public static string FilterTags(Dictionary<string, string> map, string s)
        {
            while (s.IndexOf("@") != -1)
            {
                var start = s.IndexOf('@');
                var end = -1;
                if (s[start + 1] == '(')
                {
                    end = s.IndexOf(')', start);
                    if (end == -1) end = s.Length;
                    else end += 1;
                    var key = s.Substring(start + 2, end - start - 3);
                    s = s.Replace(s.Substring(start, end - start), map[key]);
                }
                else
                {
                    end = s.IndexOf(' ', start);
                    if (end == -1) end = s.Length;
                    else end += 1;
                    var key = s.Substring(start + 1, end - start - 1);
                    s = s.Replace(s.Substring(start, end - start), map[key]);
                }
            }
            return s;
        }

        public static string FilterTags(List<Injector> injectors, string s)
        {
            return FilterTags(BuildTags(injectors), s);
        }
    }
}