
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Entities
{
    public partial class Post
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsLocked { get; set; }
        public bool IsApproved { get; set; }
        public bool IsEnglish { get; set; }
        public bool IsHotPost { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string TimeEvent { get; set; }
        public DateTime? RegisterEndDateEvent { get; set; }
        public int PostType { get; set; }
        public string Slug { get; set; }
        public string PostContent { get; set; }
        public string MetaDescription { get; set; }
        public string Image { get; set; }
        public string ExternalLink { get; set; } // Maybe facebook
        public Guid CategoryId { get; set; }
        public virtual Category Category { get; set; }
        public string UserId { get; set; }
        public int? DisplayOrder { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
        public virtual ICollection<PostTag> PostTags { get; set; }

    }
}
