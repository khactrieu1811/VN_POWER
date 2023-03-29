using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class ScholarshipResponse : PostResponse
    {
        public string Label { get; set; }
        public DateTime EndDate { get; set; }
        public ScholarshipResponse(Scholarship entity)
        {
            Id = entity.Id;
            Name = entity.Name;
            Label = entity.Label;
            Slug = entity.Slug;
            Description = entity.Description;
            Image = entity.Image;
            CreatedDate = entity.CreatedDate;
            CreatedBy = entity.ApplicationUser?.FullName;
            EndDate = entity.EndDate;
        }

        public ScholarshipResponse(Scholarship entity, string urlServerImage)
        {
            Id = entity.Id;
            Name = entity.Name;
            Label = entity.Label;
            Slug = entity.Slug;
            Description = entity.Description;
            Image = $"{urlServerImage}/{entity.Image}";
            CreatedDate = entity.CreatedDate;
            CreatedBy = entity.ApplicationUser?.FullName;
            EndDate = entity.EndDate;
        }
      
    }
}
