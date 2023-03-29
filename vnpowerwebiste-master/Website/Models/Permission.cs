using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Website.Models
{
    public class Permission
    {
        public string Controller { get; set; }
        public string Area { get; set; }
        public List<string> Allow { get; set; }
        public bool FullControl { get; set; }
    }
}
