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
            if (tds.Count() == 0)
            {
                if (dynamicFallback)
                {
                    first = asm.MainModule.Import(ReflectionUtils.DynamicResolve(type));
                }
            }
            else if (tds.Count() > 1)
            {
                throw new TypeCollisionException();
            }
            else
            {
                first = tds.First();
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
            if (tds.Count() == 0)
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
            if (tds.Count() == 0)
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
            if (tds.Count() == 0)
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
            return asm.Modules.
                SelectMany(m => m.Types).
                SelectMany(t => t.Methods).
                Where(m => m.HasBody && m != exclude && m.Body.Instructions.
                    FirstOrDefault(i =>
                    {
                        if (i.Operand != null && i.Operand is FieldReference)
                        {
                            return ((FieldReference)i.Operand).Resolve() == fd;
                        }
                        return false;
                    }) != null);
        }
    }
}