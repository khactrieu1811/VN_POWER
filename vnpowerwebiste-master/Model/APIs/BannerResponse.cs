using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class BannerResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public int DisplayOrder { get; set; }
        public string PostLink { get; set; }

        public BannerResponse(Banner entity)
        {
            Id = entity.Id;
            Name = entity.Name;
            Description = entity.Title;
            Image = entity.ImageLink;
            PostLink = entity.LinkWeb ?? "";
            DisplayOrder = entity.Position;
        }

        public BannerResponse(Banner entity, string urlServerImage)
        {
            Id = entity.Id;
            Name = entity.Name;
            Description = entity.Title;
            Image = $"{urlServerImage}/{entity.ImageLink}";
            PostLink = entity.LinkWeb ?? "";
            DisplayOrder = entity.Position;
        }
    }
}
