using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GIT_API.GetRepository
{


    public class Project
    {
        public string id { get; set; }
        public string name { get; set; }
        public string url { get; set; }
        public string state { get; set; }
    }

    public class Self
    {
        public string href { get; set; }
    }

    public class Project2
    {
        public string href { get; set; }
    }

    public class Web
    {
        public string href { get; set; }
    }

    public class Commits
    {
        public string href { get; set; }
    }

    public class Refs
    {
        public string href { get; set; }
    }

    public class PullRequests
    {
        public string href { get; set; }
    }

    public class Items
    {
        public string href { get; set; }
    }

    public class Pushes
    {
        public string href { get; set; }
    }

    public class Links
    {
        public Self self { get; set; }
        public Project2 project { get; set; }
        public Web web { get; set; }
        public Commits commits { get; set; }
        public Refs refs { get; set; }
        public PullRequests pullRequests { get; set; }
        public Items items { get; set; }
        public Pushes pushes { get; set; }
    }

    public class GetRepositoryById
    {
        public string id { get; set; }
        public string name { get; set; }
        public string url { get; set; }
        public Project project { get; set; }
        public string defaultBranch { get; set; }
        public string remoteUrl { get; set; }
        public Links _links { get; set; }
    }

}
