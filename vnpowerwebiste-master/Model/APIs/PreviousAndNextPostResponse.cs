using System;
using System.Collections.Generic;
using System.Text;

namespace Model.APIs
{
    public class PreviousAndNextPostResponse
    {
        public PostResponse Previous { get; set; }
        public PostResponse Next { get; set; }
    }
}
