using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Entities
{
    public class TrackingAgreeCondition
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string HISCode { get; set; }
        public string UserId { get; set; }
        public string IpAddress { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
