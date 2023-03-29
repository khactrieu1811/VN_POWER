using Entities.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class ServiceModel : Service
    {
        public IFormFile FileImage { get; set; }
    }
}
