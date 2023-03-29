using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model.APIs
{
    public class EventDetailResponse : PostDetailResponse
    {
        public string TimeEvent { get; set; }
        public DateTime EndDate { get; set; }
        public EventDetailResponse(Post entity)
        {
            Id = entity.Id;
            Name = entity.Name;
            Slug = entity.Slug;
            Description = entity.Description;
            Image = entity.Image;
            CreatedDate = entity.CreatedDate;
            PostContent = entity.PostContent;
            CreatedBy = entity.ApplicationUser?.FullName;
            TimeEvent = entity.TimeEvent;
            EndDate = entity.RegisterEndDateEvent.Value;
        }

        public EventDetailResponse(Post entity, string urlServerImage)
        {
            Id = entity.Id;
            Name = entity.Name;
            Slug = entity.Slug;
            Description = entity.Description;
            Image = $"{urlServerImage}/{entity.Image}";
            CreatedDate = entity.CreatedDate;
            PostContent = entity.PostContent;
            CreatedBy = entity.ApplicationUser?.FullName;
            TimeEvent = entity.TimeEvent;
            EndDate = entity.RegisterEndDateEvent.Value;
        }

    }
}
