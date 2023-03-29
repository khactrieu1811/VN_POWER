using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Entities
{
    public class ScholarshipTag
    {
        public Guid ScholarshipId { get; set; }
        public virtual Scholarship Scholarship { get; set; }
        public Guid TagId { get; set; }
        public virtual Tag Tag { get; set; }

    }
}
