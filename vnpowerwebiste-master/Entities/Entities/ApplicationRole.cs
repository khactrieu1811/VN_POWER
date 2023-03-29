using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace Entities.Entities
{
    public class ApplicationRole : IdentityRole
    {
        public string Displayname { get; set; }
        public bool ReadOnly { get; set; }
        public bool FullControl { get; set; }
        public string Description { get; set; }
      
    }
}
