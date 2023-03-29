using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model.APIs
{
    public class ProductResponse
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
        public DateTime? PromotionStartDate { get; set; }
        public DateTime? PromotionEndDate { get; set; }
        public int? DisplayOrder { get; set; }
        public string CreatedBy { get; set; }
        public ProductResponse()
        {

        }
        public ProductResponse(Product entity)
        {
            Id = entity.Id;
            Name = entity.Name;
            MetaTitle = entity.MetaDescription;
            Description = entity.Description;
            Image = entity.Image;
            Price = entity.Price;
            PromotionPrice = entity.PromotionPrice;
            Quantity = entity.Quantity;
            Detail = entity.Detail;
            Warranty = entity.Warranty;
            CreatedDate = entity.CreatedDate;
            PromotionStartDate = entity.PromotionStartDate;
            PromotionEndDate = entity.PromotionEndDate;
            CreatedBy = entity.ApplicationUser?.FullName;
            DisplayOrder = entity.DisplayOrder;
        }

        public ProductResponse(Product entity, string urlServerImage)
        {
            Id = entity.Id;
            Name = entity.Name;
            MetaTitle = entity.MetaDescription;
            Description = entity.Description;
            Image = $"{urlServerImage}/{entity.Image}";
            Price = entity.Price;
            PromotionPrice = entity.PromotionPrice;
            Quantity = entity.Quantity;
            Detail = entity.Detail;
            Warranty = entity.Warranty;
            CreatedDate = entity.CreatedDate;
            PromotionStartDate = entity.PromotionStartDate;
            PromotionEndDate = entity.PromotionEndDate;
            CreatedBy = entity.ApplicationUser?.FullName;
            DisplayOrder = entity.DisplayOrder;

        }

    }
}
