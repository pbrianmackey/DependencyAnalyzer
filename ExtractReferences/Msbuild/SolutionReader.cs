using System.IO;
using Microsoft.Build.BuildEngine;
using System.Collections.Generic;
using System.Linq;
using ExtractReferences.Msbuild;


namespace ExtractReferences.Msbuild
{
    public class SolutionReader
    {
        private string solutionPath { get; set; }
        public SolutionPoco Solution { get; set; }

        public SolutionReader(string solutionPath)
        {
            this.solutionPath = solutionPath;
            Solution = new SolutionPoco();
        }

        public void Run()
        {
            GetProjectsBelongingToSolution();
            CreateFilesForProjects();
        }

        public void GetProjectsBelongingToSolution()
        {
            var solutionReader = new SolutionParserHelper(solutionPath);
            var solution = new SolutionPoco();

            solution.Name = Path.GetFileNameWithoutExtension(solutionPath);

            foreach (var item in solutionReader.Projects)
            {                
                ConstructPathToProject(item, solution);
            }

            Solution = solution;
        }

        public void CreateFilesForProjects()
        {
            foreach (var project in Solution.Projects)
            {
                var referenceCreator = new ProjectReader(project.FullPath, Solution.Name);
                referenceCreator.ExtractProjectsAndWriteToFile();
            }
        }

        private void ConstructPathToProject(ProjectParser item, SolutionPoco solution)
        {
            if (item.ProjectType == "KnownToBeMSBuildFormat")
            {
                var solutionDirectory = Path.GetDirectoryName(solutionPath);
                var projectPath = Path.Combine(solutionDirectory, item.RelativePath);
                var projectReader = new ProjectReader(projectPath, solution.Name);
                projectReader.ExtractProjectReferences();

                var projectPoco = new ProjectPoco();
                projectPoco.FullPath = projectPath;
                projectPoco.References = projectReader.References;
                solution.Projects.Add(projectPoco);
            }
        }
    }
}
