using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtractReferences
{
    public class SolutionPoco
    {
        public string Name { get; set; }
        public List<ProjectPoco> Projects { get; set; }

        public SolutionPoco()
        {
            Projects = new List<ProjectPoco>();
        }
    }
}
