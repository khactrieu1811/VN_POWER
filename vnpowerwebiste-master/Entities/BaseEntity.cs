using System;
using System.Collections.Generic;
using System.Text;

namespace BioNet.Entities.Entities
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public int Status { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
