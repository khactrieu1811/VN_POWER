using System;
using System.Collections.Generic;
using System.Text;

namespace Common
{
    public  class PagedResultBase
    {
        public int CurrentPage { get; set; }
        public int PageCount { get; set; }
        public int PageSize { get; set; }
        public int TotalItems { get; set; }

        public bool HasPreviousPage
        {
            get;set;
        }

        public bool HasNextPage
        {
            get;set;
        }
   
    }

    public class PagedResult<T> : PagedResultBase where T : class
    {
        public IList<T> Results { get; set; }

        public PagedResult()
        {
            Results = new List<T>();
        }
    }

}
