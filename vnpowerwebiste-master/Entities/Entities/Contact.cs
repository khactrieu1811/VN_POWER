using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Entities
{
    public partial class Contact
    {
        public int Id { get; set; }
        public string Subject { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Content { get; set; }
        public string RegisterFor { get; set; }
        public string Slug { get; set; }
        public string ReplyContent { get; set; }
        public DateTime ReplyDate { get; set; }
        public string UserReplyId { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public int Status { get; set; }
        public virtual ApplicationUser UserReply {get; set; }
    }
}
