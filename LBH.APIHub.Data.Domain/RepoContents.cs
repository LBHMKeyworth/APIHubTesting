using System;
using System.Collections.Generic;
using System.Text;

namespace LBH.APIHub.Data.Domain
{
    public class RepoContents
    {
        public string sha { get; set; }
        public string url { get; set; }
        public List<Tree> tree { get; set; }
        public bool truncated { get; set; }
    }
}
