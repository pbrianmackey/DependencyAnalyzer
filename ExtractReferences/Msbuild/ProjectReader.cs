using ExtractReferences.Extensions;
using Microsoft.Build.BuildEngine;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ExtractReferences.Msbuild
{
    public class ProjectReader
    {
        private string projectName;
        private readonly string projectPath;
        public List<string> References { get; set; }
        public string SolutionName { get; set; }

        public ProjectReader(string projectPath, string solutionName)
        {            
            this.projectPath = projectPath;
            this.SolutionName = solutionName;
            References = new List<string>();
        }

        public void ExtractProjectsAndWriteToFile()
        {
            ExtractProjectReferences();
            WriteToFile();
        }

        public void ExtractProjectReferences()
        {
            var project = new Project();
            project.Load(projectPath);
            ReadProjectName(project);

            var embeddedResources =
                from grp in project.ItemGroups.Cast<BuildItemGroup>()
                from item in grp.Cast<BuildItem>()
                where item.Name == "Reference"
                select item;

            foreach (BuildItem item in embeddedResources)
            {
                References.Add(item.Include.StripVersionOffAssembly());
                //Console.WriteLine(item.Include); // prints the name of the resource file
                //Console.WriteLine(projectName);
                //WriteToFile(item.Name);
            }

            var projectReference =
                from grp in project.ItemGroups.Cast<BuildItemGroup>()
                from item in grp.Cast<BuildItem>()
                where item.Name == "ProjectReference"
                select item;

            foreach (BuildItem item in projectReference)
            {
                var name = item.GetMetadata("Name");
                name = name.StripTrashCharacters();
                References.Add(name);
            }
        }

        private void ReadProjectName(Project project)
        {
            if (project == null)
                return;

            foreach (BuildPropertyGroup pg in project.PropertyGroups)
            {
                foreach (BuildProperty property in pg)
                {
                    if (property.Name == "AssemblyName")
                    {
                        projectName = property.Value;
                        return;
                    }
                }
            }
        }

        private void WriteToFile()
        {
            var outputPath = Path.Combine(GlobalData.ProjectPath, SolutionName + "." + projectName + ".txt");
            var fs = new FileStream(outputPath, FileMode.OpenOrCreate);
            fs.Seek(0,0);
            fs.SetLength(0);//truncate
            using (var sw = new StreamWriter(fs))
            {
                sw.Write(References);
            }
        }
    }
}
