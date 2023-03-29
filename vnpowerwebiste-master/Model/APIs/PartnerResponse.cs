using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class PartnerResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Logo { get; set; }
        public string PostLink { get; set; }
        public PartnerResponse(Partner entity)
        {
            Id = entity.Id;
            Name = entity.Name;
            Description = entity.Description ?? "";
            Logo = entity.Logo;
            PostLink = entity.PostLink ?? "";
        }
        public PartnerResponse(Partner entity, string urlServerImage)
        {
            Id = entity.Id;
            Name = entity.Name;
            Description = entity.Description ?? "";
            Logo = $"{urlServerImage}/{entity.Logo}";
            PostLink = entity.PostLink ?? "";
        }
    }
}
