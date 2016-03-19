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
using System.Linq;
using Mono.Cecil;

namespace Storm
{
    public static class CecilExtensions
    {
        public static TypeReference GetTypeRef(this AssemblyDefinition asm, string type, bool dynamicFallback = false)
        {
            var arrayDepth = 0;
            while (type.EndsWith("[]"))
            {
                type = type.Substring(0, type.Length - 2);
                arrayDepth++;
            }

            TypeReference first = null;
            var tds = asm.Modules.Where(m => m.GetType(type) != null).Select(m => m.GetType(type));
            var typeDefinitions = tds as IList<TypeDefinition> ?? tds.ToList();
            if (!typeDefinitions.Any())
            {
                if (dynamicFallback)
                {
                    var refRef = ReflectionUtils.DynamicResolve(type);
                    if (refRef == null)
                    {
                        Logging.DebugLogs("Eek! can't find {0}", type);
                        return asm.MainModule.Import(typeof(object));
                    }
                    first = asm.MainModule.Import(refRef);
                }
            }
            else if (typeDefinitions.Count > 1)
            {
                throw new TypeCollisionException();
            }
            else
            {
                first = typeDefinitions.First();
            }

            if (arrayDepth > 0)
            {
                return new ArrayType(first, arrayDepth);
            }
            return first;
        }

        public static TypeDefinition GetTypeDef(this AssemblyDefinition asm, string type)
        {
            var tds = asm.Modules.Where(m => m.GetType(type) != null).Select(m => m.GetType(type));
            if (!tds.Any())
            {
                return null;
            }
            if (tds.Count() > 1)
            {
                throw new TypeCollisionException();
            }
            return tds.First();
        }

        public static FieldDefinition GetField(this AssemblyDefinition asm, string type, string name, string fieldType)
        {
            var tds = asm.Modules.Where(m => m.GetType(type) != null).Select(m => m.GetType(type));
            if (!tds.Any())
            {
                return null;
            }
            if (tds.Count() > 1)
            {
                throw new TypeCollisionException();
            }
            var td = tds.First();
            return td.Fields.FirstOrDefault(f => f.Name.Equals(name) && f.FieldType.Resolve().FullName.Equals(fieldType));
        }

        public static MethodDefinition GetMethod(this AssemblyDefinition asm, string type, string name, string desc)
        {
            var tds = asm.Modules.Where(m => m.GetType(type) != null).Select(m => m.GetType(type));
            if (!tds.Any())
            {
                return null;
            }
            if (tds.Count() != 1)
            {
                throw new TypeCollisionException();
            }
            var td = tds.First();
            return td.Methods.FirstOrDefault(m => m.Name.Equals(name) && CecilUtils.DescriptionOf(m).Equals(desc));
        }

        public static TypeReference Import(this AssemblyDefinition asm, Type t)
        {
            return asm.MainModule.Import(t);
        }

        public static TypeReference Import(this AssemblyDefinition asm, TypeReference tr)
        {
            return asm.MainModule.Import(tr);
        }

        public static MethodReference Import(this AssemblyDefinition asm, MethodDefinition md)
        {
            return asm.MainModule.Import(md);
        }

        public static IEnumerable<MethodDefinition> FindRefences(this AssemblyDefinition asm, FieldDefinition fd, MethodDefinition exclude = null)
        {
            return asm.Modules.SelectMany(m => m.Types).SelectMany(t => t.Methods).Where(m => m.HasBody && m != exclude && m.Body.Instructions.FirstOrDefault(i =>
            {
                var operand = i.Operand as FieldReference;
                if (operand != null)
                {
                    return operand.Resolve() == fd;
                }
                return false;
            }) != null);
        }
    }
}