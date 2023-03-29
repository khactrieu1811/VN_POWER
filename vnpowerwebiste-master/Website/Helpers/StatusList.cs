using Common;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Website.Helpers
{
    public static class StatusList
    {
        public  static IEnumerable<SelectListItem> ListItems
        {
            get
            {
                yield return new SelectListItem { Text = "Tất cả", Value = "" };
                yield return new SelectListItem { Text = "Đang xử lý", Value = "1" };
                yield return new SelectListItem { Text = "Hoàn thành", Value = "2" };
                yield return new SelectListItem { Text = "Đã xóa", Value = "-1" };

            }
        }

        public static IEnumerable<SelectListItem> ListPostStatus
        {
            get
            {
                yield return new SelectListItem { Text = "Tất cả", Value = "" };
                yield return new SelectListItem { Text = "Chưa duyệt", Value = "False" };
                yield return new SelectListItem { Text = "Đã duyệt", Value = "True" };
            }
        }


        public static IEnumerable<SelectListItem> ListItemStatusContact
        {
            get
            {
                yield return new SelectListItem { Text = "Tất cả", Value = "" };
                yield return new SelectListItem { Text = "Chưa trả lời", Value = ContactStatus.NotYet.GetHashCode().ToString() };
                yield return new SelectListItem { Text = "Đã trả lời", Value = ContactStatus.Replied.GetHashCode().ToString() };
                yield return new SelectListItem { Text = "Đã xóa", Value = ContactStatus.Deleted.GetHashCode().ToString() };

            }
        }

        public static IEnumerable<SelectListItem> ListRegister
        {
            get
            {
                yield return new SelectListItem { Text = RegisterConstant.Home, Value = RegisterConstant.Home };
                yield return new SelectListItem { Text = RegisterConstant.Event, Value = RegisterConstant.Event };
                yield return new SelectListItem { Text = RegisterConstant.Scholarship, Value = RegisterConstant.Scholarship };
            }
        }

    }

}
