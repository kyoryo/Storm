using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace gAyPI
{
    public sealed class ReflectionUtils
    {
        private ReflectionUtils() { }

        public static string DescriptionOf(MethodInfo md)
        {
            var sb = new StringBuilder();
            sb.Append('(');
            foreach (var param in md.GetParameters())
            {
                sb.Append(param.ParameterType.FullName);
                sb.Append(',');
            }
            if (md.GetParameters().Length > 0)
            {
                sb.Length -= 1;
            }
            sb.Append(')');
            sb.Append(md.ReturnType.FullName);
            return sb.ToString();
        }
    }
}
