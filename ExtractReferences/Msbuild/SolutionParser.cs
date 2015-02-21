using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using  System.Linq;

namespace ExtractReferences.Msbuild
{
    public class SolutionParserHelper
    {
        private static readonly Type s_SolutionParser;
        private static readonly PropertyInfo s_SolutionParser_solutionReader;
        private static readonly MethodInfo s_SolutionParser_parseSolution;
        private static readonly PropertyInfo s_SolutionParser_projects;

        static SolutionParserHelper()
        {
            s_SolutionParser =
                Type.GetType(
                    "Microsoft.Build.Construction.SolutionParser, Microsoft.Build, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                    false, false);
            if (s_SolutionParser != null)
            {
                s_SolutionParser_solutionReader = s_SolutionParser.GetProperty("SolutionReader",
                    BindingFlags.NonPublic | BindingFlags.Instance);
                s_SolutionParser_projects = s_SolutionParser.GetProperty("Projects",
                    BindingFlags.NonPublic | BindingFlags.Instance);
                s_SolutionParser_parseSolution = s_SolutionParser.GetMethod("ParseSolution",
                    BindingFlags.NonPublic | BindingFlags.Instance);
            }
        }

        public List<ProjectParser> Projects { get; private set; }

        public SolutionParserHelper(string solutionFileName)
        {
            if (s_SolutionParser == null)
            {
                throw new InvalidOperationException(
                    "Can not find type 'Microsoft.Build.Construction.SolutionParser' are you missing a assembly reference to 'Microsoft.Build.dll'?");
            }
            var solutionParser =
                s_SolutionParser.GetConstructors(BindingFlags.Instance | BindingFlags.NonPublic).First().Invoke(null);
            using (var streamReader = new StreamReader(solutionFileName))
            {
                s_SolutionParser_solutionReader.SetValue(solutionParser, streamReader, null);
                s_SolutionParser_parseSolution.Invoke(solutionParser, null);
            }
            var projects = new List<ProjectParser>();
            var array = (Array) s_SolutionParser_projects.GetValue(solutionParser, null);
            for (int i = 0; i < array.Length; i++)
            {
                projects.Add(new ProjectParser(array.GetValue(i)));
            }
            this.Projects = projects;
        }
    }
}