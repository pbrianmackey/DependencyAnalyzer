﻿using System;
using System.Diagnostics;
using System.Reflection;

namespace ExtractReferences.Msbuild
{
    [DebuggerDisplay("{ProjectName}, {RelativePath}, {ProjectGuid}")]
    public class ProjectParser
    {
        private static readonly Type s_ProjectInSolution;
        private static readonly PropertyInfo s_ProjectInSolution_ProjectName;
        private static readonly PropertyInfo s_ProjectInSolution_RelativePath;
        private static readonly PropertyInfo s_ProjectInSolution_ProjectGuid;
        private static readonly PropertyInfo s_ProjectInSolution_ProjectType;

        static ProjectParser()
        {
            s_ProjectInSolution =
                Type.GetType(
                    "Microsoft.Build.Construction.ProjectInSolution, Microsoft.Build, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                    false, false);
            if (s_ProjectInSolution != null)
            {
                s_ProjectInSolution_ProjectName = s_ProjectInSolution.GetProperty("ProjectName",
                    BindingFlags.NonPublic | BindingFlags.Instance);
                s_ProjectInSolution_RelativePath = s_ProjectInSolution.GetProperty("RelativePath",
                    BindingFlags.NonPublic | BindingFlags.Instance);
                s_ProjectInSolution_ProjectGuid = s_ProjectInSolution.GetProperty("ProjectGuid",
                    BindingFlags.NonPublic | BindingFlags.Instance);
                s_ProjectInSolution_ProjectType = s_ProjectInSolution.GetProperty("ProjectType",
                    BindingFlags.NonPublic | BindingFlags.Instance);
            }
        }

        public string ProjectName { get; private set; }
        public string RelativePath { get; private set; }
        public string ProjectGuid { get; private set; }
        public string ProjectType { get; private set; }

        public ProjectParser(object solutionProject)
        {
            this.ProjectName = s_ProjectInSolution_ProjectName.GetValue(solutionProject, null) as string;
            this.RelativePath = s_ProjectInSolution_RelativePath.GetValue(solutionProject, null) as string;
            this.ProjectGuid = s_ProjectInSolution_ProjectGuid.GetValue(solutionProject, null) as string;
            this.ProjectType = s_ProjectInSolution_ProjectType.GetValue(solutionProject, null).ToString();
        }
    }
}