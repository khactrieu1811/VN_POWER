using Entities.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class PostModel : Post
    {
        public string EndDateString { get; set; }
        public IFormFile FileImage { get; set; }
    }
}
