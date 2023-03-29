using Entities.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class ScholarshipModel : Scholarship
    {
        public string Tags { get; set; }
        public string EndDateString { get; set; }
        public IFormFile FileImage { get; set; }
    }
}
