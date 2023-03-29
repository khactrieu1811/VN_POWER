using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Entities
{
    public class Tag
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }
        public string Description { get; set; }
        public virtual ICollection<PostTag> PostTags { get; set; }
        public virtual ICollection<ScholarshipTag> ScholarshipTags { get; set; }
    }
}
