using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class PostDetailResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }
        public string Description { get; set; }
        public string PostContent { get; set; }
        public string Image { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }

        public PostDetailResponse()
        {

        }
        public PostDetailResponse(Post entity)
        {
            Id = entity.Id;
            Name = entity.Name;
            Slug = entity.Slug;
            Description = entity.Description;
            Image = entity.Image;
            CreatedDate = entity.CreatedDate;
            PostContent = entity.PostContent;
            CreatedBy = entity.ApplicationUser?.FullName;
        }

        public PostDetailResponse(Post entity, string urlServerImage)
        {
            Id = entity.Id;
            Name = entity.Name;
            Slug = entity.Slug;
            Description = entity.Description;
            Image = $"{urlServerImage}/{entity.Image}";
            CreatedDate = entity.CreatedDate;
            PostContent = entity.PostContent;
            CreatedBy = entity.ApplicationUser?.FullName;
        }
    }
}
