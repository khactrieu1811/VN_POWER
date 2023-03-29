
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Entities
{
    public partial class Email
    {
        public Guid Id { get; set; }
        public string EmailTo { get; set; }
        public string Body { get; set; }
        public DateTime DateCreated { get; set; }
        public string Subject { get; set; }
        public string NameTo { get; set; }
    }
}
