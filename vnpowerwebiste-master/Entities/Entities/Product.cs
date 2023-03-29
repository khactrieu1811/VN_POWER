using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Entities
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string MetaTitle { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public decimal Price { get; set; }
        public decimal? PromotionPrice { get; set; }
        public int Quantity { get; set; }
        //nd
        public string Detail { get; set; }
        //bao hanh
        public string Warranty { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        
        public bool IsLocked { get; set; }
        public bool IsApproved { get; set; }
        public bool IsHotPost { get; set; }
        public DateTime? PromotionStartDate { get; set; }
        public DateTime? PromotionEndDate { get; set; }
        public string MetaDescription { get; set; }
        public string MetaKeyword { get; set; }
        public Guid CategoryId { get; set; }
        public string UserId { get; set; }
        public int? DisplayOrder { get; set; }
        public virtual ApplicationUser ApplicationUser { get;set;}
        public virtual CategoryProduct CategoryProduct { get; set; }
    }
}
