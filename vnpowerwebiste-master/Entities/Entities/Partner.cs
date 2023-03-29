using System;
using System.Collections.Generic;

namespace Entities.Entities
{
    public partial class Partner : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsEnglish { get; set; }
        public bool IsLocked { get; set; }
        public bool IsApproved { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string Logo { get; set; }
        public string PostLink { get; set; } 
       
    }
}
