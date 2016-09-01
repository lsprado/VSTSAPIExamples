using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GIT_API
{
    public class Project
    {
        public string id { get; set; }
        public string name { get; set; }
        public string url { get; set; }
        public string state { get; set; }
    }

    public class Value
    {
        public string id { get; set; }
        public string name { get; set; }
        public string url { get; set; }
        public Project project { get; set; }
        public string remoteUrl { get; set; }
        public string defaultBranch { get; set; }
    }

    public class GetListRepositories
    {
        public List<Value> value { get; set; }
        public int count { get; set; }
    }
}
