using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Website.Controllers
{
    public class BaseController: Controller
    {
        public readonly string _formatDateTime = "dd/MM/yyyy";
        public readonly int _pageSizeDefault = 10;
        public readonly int _rangeDayDefault = 30;
        
    }
}
