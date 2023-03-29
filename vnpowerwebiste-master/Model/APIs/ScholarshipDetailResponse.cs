using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class ScholarshipDetailResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }
        public string Description { get; set; }
        public string PostContent { get; set; }
        public string Image { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime EndDate { get; set; }
        public ScholarshipDetailResponse(Scholarship entity)
        {
            Id = entity.Id;
            Name = entity.Name;
            Slug = entity.Slug;
            Description = entity.Description;
            Image = entity.Image;
            CreatedDate = entity.CreatedDate;
            PostContent = entity.PostContent;
            CreatedBy = entity.ApplicationUser?.FullName;
            EndDate = entity.EndDate;
        }

        public ScholarshipDetailResponse(Scholarship entity, string urlServerImage)
        {
            Id = entity.Id;
            Name = entity.Name;
            Slug = entity.Slug;
            Description = entity.Description;
            Image = $"{urlServerImage}/{entity.Image}";
            CreatedDate = entity.CreatedDate;
            PostContent = entity.PostContent;
            CreatedBy = entity.ApplicationUser?.FullName;
            EndDate = entity.EndDate;
        }
    }
}
