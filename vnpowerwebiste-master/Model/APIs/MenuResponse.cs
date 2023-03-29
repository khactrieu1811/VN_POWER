using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class MenuResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string PostLink { get; set; }
        public int DisplayOrder { get; set; }
        public List<MenuResponse> Children { get; set; } = new List<MenuResponse>();
        public MenuResponse(NavigationMenu entity, bool isEnglish)
        {
            Id = entity.Id;
            Name = isEnglish == true ? entity.NameEng : entity.Name;
            PostLink = entity.ExternalUrl ?? "";
            DisplayOrder = entity.DisplayOrder;
        }
    }
}
