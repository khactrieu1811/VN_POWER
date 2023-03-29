using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Entities
{
    public class PostTag
    {
        public Guid PostId { get; set; }
        public virtual Post Post { get; set; }
        public Guid TagId { get; set; }
        public virtual Tag Tag { get; set; }

    }
}
