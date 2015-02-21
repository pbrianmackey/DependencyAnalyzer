
using ExtractReferences.Extensions;

namespace ExtractReferences.Prolog
{
    public class ReferencesFact: Fact
    {
        public string ProjectName { get; set; }
        public string AssemblyName { get; set; }

        public ReferencesFact(string projectName, string assemblyName)
        {
            ProjectName = projectName;
            AssemblyName = assemblyName;
        }

        public override string ToString()
        {
            var fact = new Fact("projectReferences", ProjectName, AssemblyName);
            return fact.ToString();
        }
    }
}
