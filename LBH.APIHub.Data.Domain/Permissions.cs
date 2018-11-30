using System;
using System.Collections.Generic;
using System.Text;

namespace LBH.APIHub.Data.Domain
{
    public class Permissions
    {
        public bool admin { get; set; }
        public bool push { get; set; }
        public bool pull { get; set; }
    }
}
