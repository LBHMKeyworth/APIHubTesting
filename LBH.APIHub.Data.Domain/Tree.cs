using System;
using System.Collections.Generic;
using System.Text;

namespace LBH.APIHub.Data.Domain
{
    public class Tree
    {
        public string path { get; set; }
        public string mode { get; set; }
        public string type { get; set; }
        public int size { get; set; }
        public string sha { get; set; }
        public string url { get; set; }
    }
}
