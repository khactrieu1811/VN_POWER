
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System;

namespace Entities.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public string FullName { get; set; }
        public string FullAddress { get; set; }
        public string Sex { get; set; }
        public DateTime BirthDay { get; set; }  
        public string Avatar { get; set; }
        public virtual ICollection<Post> Posts { get; set; }
        public virtual ICollection<Contact> UserReplyContact { get; set; }
        public virtual ICollection<Scholarship> Scholarships { get; set; }
        public virtual ICollection<Product> Products { get; set; }

    }
   
}
