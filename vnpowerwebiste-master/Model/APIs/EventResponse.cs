using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model.APIs
{
    public class EventResponse : PostResponse
    {
        public string TimeEvent { get; set; }
        public DateTime EndDate { get; set; }
        public EventResponse(Post entity)
        {
            Id = entity.Id;
            Name = entity.Name;
            Slug = entity.Slug;
            Description = entity.Description;
            Image = entity.Image;
            CreatedDate = entity.CreatedDate;
            CreatedBy = entity.ApplicationUser?.FullName;
            TimeEvent = entity.TimeEvent;
            EndDate = entity.RegisterEndDateEvent.Value;
            Type = entity.Category?.Name.ToLower();
        }

        public EventResponse(Post entity, string urlServerImage)
        {
            Id = entity.Id;
            Name = entity.Name;
            Slug = entity.Slug;
            Description = entity.Description;
            Image = $"{urlServerImage}/{entity.Image}";
            CreatedDate = entity.CreatedDate;
            CreatedBy = entity.ApplicationUser?.FullName;
            TimeEvent = entity.TimeEvent;
            EndDate = entity.RegisterEndDateEvent.Value;
            Type = entity.Category?.Name.ToLower();
        }

    }
}
