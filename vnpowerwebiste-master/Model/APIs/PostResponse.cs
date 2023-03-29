using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class PostResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public string CreatedBy { get; set; }
        public string Type { get; set; }
        public int? DisplayOrder { get; set; }
        public DateTime CreatedDate { get; set; }

        public PostResponse()
        {

        }
        public PostResponse(Post entity)
        {
            Id = entity.Id;
            Name = entity.Name;
            Slug = entity.Slug;
            Description = entity.Description;
            Image = entity.Image;
            CreatedDate = entity.CreatedDate;
            CreatedBy = entity.ApplicationUser?.FullName;
            Type = entity.Category.Name.ToLower();
            DisplayOrder = entity.DisplayOrder;
        }

        public PostResponse(Post entity, string urlServerImage)
        {
            Id = entity.Id;
            Name = entity.Name;
            Slug = entity.Slug;
            Description = entity.Description;
            Image = $"{urlServerImage}/{entity.Image}";
            CreatedDate = entity.CreatedDate;
            CreatedBy = entity.ApplicationUser?.FullName;
            Type = entity.Category?.Name.ToLower();
            DisplayOrder = entity.DisplayOrder;
        }

        public PostResponse(Scholarship entity, string urlServerImage)
        {
            Id = entity.Id;
            Name = entity.Name;
            Slug = entity.Slug;
            Description = entity.Description;
            Image = $"{urlServerImage}/{entity.Image}";
            CreatedDate = entity.CreatedDate;
            CreatedBy = entity.ApplicationUser?.FullName;
            Type = "scholarship";
            DisplayOrder = entity.DisplayOrder;
        }

    }
}
