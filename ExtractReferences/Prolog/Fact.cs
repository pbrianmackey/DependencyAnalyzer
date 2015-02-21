using System.Collections.Generic;
using ExtractReferences.Extensions;
using System;
using System.Linq;

namespace ExtractReferences.Prolog
{
    public class Fact
    {
        public List<string> Arguments { get; set; }
        public string Name { get; set; }
        public bool AppendNewLine { get; set; }

        public Fact()
        {
            Arguments = new List<string>();
            AppendNewLine = true;
        }

        public Fact(string name, string argument, bool appendNewLine = true): this()
        {
            Name = name;
            Arguments.Add(argument);
            AppendNewLine = appendNewLine;
        }

        public Fact(string name, params string[] arguments):this()
        {
            Name = name;
            Arguments.AddRange(arguments);
        }

        public override string ToString()
        {
            var stringFormattedArgs = Arguments.Select(i => "'" + i.ToLower() + "'");
            string optionalNewLine = AppendNewLine ? "\n" : "";
            string args = String.Join(",", stringFormattedArgs.ToArray());
            return Name.ToCamelCase() + "(" + args + ")." + optionalNewLine;
        }
    }
}
