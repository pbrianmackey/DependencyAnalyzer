using System;

namespace ExtractReferences.Extensions
{
    public static class MyExtensionMethods
    {
        public static string ToCamelCase(this string s)
        {
            return Char.ToLowerInvariant(s[0]) + s.Substring(1);
        }

        public static string StripVersionOffAssembly(this string s)
        {
            var stopIndex = s.IndexOf(',');
            if (stopIndex == -1)
                return s;
            else
            {
                return s.Substring(0, stopIndex);
            }
        }
    }
}
