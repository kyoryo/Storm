using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Storm
{
    public sealed class ReflectionUtils
    {
        private ReflectionUtils() { }

        public static string DescriptionOf(MethodInfo md)
        {
            var sb = new StringBuilder();
            sb.Append('(');

            var set = false;
            foreach (var param in md.GetParameters())
            {
                sb.Append(param.ParameterType.FullName);
                sb.Append(',');
                set = true;
            }
            if (set) sb.Length -= 1;

            sb.Append(')');
            sb.Append(md.ReturnType.FullName);
            return sb.ToString();
        }

        public static Type DynamicResolve(string name)
        {
            return AppDomain.CurrentDomain.GetAssemblies().SelectMany(a => a.GetTypes()).FirstOrDefault(t => t.FullName.Equals(name));
        }
    }
}
