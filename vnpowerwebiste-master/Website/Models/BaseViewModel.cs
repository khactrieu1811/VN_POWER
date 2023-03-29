using Microsoft.AspNetCore.Mvc.Rendering;
using Entities.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Website.Models
{
    public class BaseViewModel<T>
    {
        public string SelectedStatus { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public List<SelectListItem> ListItems { get; set; }
        public PaginatedList<T> Data { get; set; }
        public List<T> List { get; set; }

    }

    public class ContactViewModel<T>: BaseViewModel<T>
    {
        public string SelectedContactType { get; set; }
        public List<SelectListItem> ContactTypes { get; set; }
    }
}
