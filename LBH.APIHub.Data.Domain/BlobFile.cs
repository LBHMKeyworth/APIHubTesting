using System;
using System.Collections.Generic;
using System.Text;

namespace LBH.APIHub.Data.Domain
{
    public class BlobFile
    {
        public string content { get; set; }
        public string encoding { get; set; }
        public string url { get; set; }
        public string sha { get; set; }
        public int size { get; set; }
    }
}
