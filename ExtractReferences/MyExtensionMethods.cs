using System;

namespace ExtractReferences.Extensions
{
    public static class MyExtensionMethods
    {
        public static string ToCamelCase(this string s)
        {
            return Char.ToLowerInvariant(s[0]) + s.Substring(1);
        }

        public static string StripTrashCharacters(this string s)
        {
            s = s.Replace(" %28","");//I don't know why these show up sometimes
            s = s.Replace("%29","");
            s = s.Replace(@"\o","");
            s = s.Replace(@"\", "");//You can't have a slash in prolog lookups
            return s;
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
