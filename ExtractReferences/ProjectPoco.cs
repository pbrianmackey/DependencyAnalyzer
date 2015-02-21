using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtractReferences
{
    public class ProjectPoco
    {
        private string _name;

        public string Name {
            get
            {
                if(_name == null)
                    _name = Path.GetFileNameWithoutExtension(FullPath);
                return _name;
            }
            private set { _name = value; }
        }
        public string FullPath { get; set; }
        public List<string> References { get; set; }
    }
}
