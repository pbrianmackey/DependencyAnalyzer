using ExtractReferences.Msbuild;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtractReferences.Prolog
{
    public class GenerateProlog
    {
        public List<ReferencesFact> Facts = new List<ReferencesFact>();
        private string result;

        public void Generate(params string[] solutionPaths)
        {
            foreach (var solutionPath in solutionPaths)
            {
                var referenceSolutionCreator = new SolutionReader(solutionPath);
                referenceSolutionCreator.GetProjectsBelongingToSolution();

                foreach (var project in referenceSolutionCreator.Solution.Projects)
                {
                    foreach (var reference in project.References)
                    {
                        var fact = new ReferencesFact(project.Name, reference);
                        Facts.Add(fact);
                    }
                }
            }
            
        }

        public void CreateKnowledgeBase()
        {
            result += GlobalData.HeaderData;
            result += GlobalData.TestData;

            foreach (var fact in Facts)
            {
                result += fact.ToString();
            }

            result += GlobalData.Rules;
            WriteToFile();
        }

        private void WriteToFile()
        {
            var outputPath = Path.Combine(Directory.GetCurrentDirectory(),"ReferenceCreator", "Sample.pro");
            var fs = new FileStream(outputPath, FileMode.OpenOrCreate);
            fs.Seek(0, 0);
            fs.SetLength(0);//truncate
            using (var sw = new StreamWriter(fs))
            {
                sw.Write(result);
            }
        }
    }
}
