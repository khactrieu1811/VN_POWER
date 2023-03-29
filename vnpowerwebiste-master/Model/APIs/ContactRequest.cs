using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model.APIs
{
    public class ContactRequest
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Message { get; set; }
        public string Slug { get; set; }

    }
}
