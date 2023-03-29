using Entities.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class ProductModel:Product
    {
        public IFormFile FileImage { get; set; }
        public DateTime PromotionStartDate { get; set; }
        public DateTime PromotionEndDate { get; set; }
        public string CategoryName { get; set; }
    }
}
