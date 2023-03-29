using System;
using System.Collections.Generic;

namespace Entities.Entities
{
    public partial class Region : BaseEntity
    {
        public string Name { get; set; }
        public string NameEN { get; set; }
        public string Description { get; set; }
        public string DescriptionEN { get; set; }
        public ICollection<Scholarship> Scholarships { get; set; }
    }
}
