using AutoMapper;
using Business.IRepostitory;
using Common;
using Entities.Entities;
using Entities.Helpers;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Website.Helpers;
using Website.Models;

namespace Website.Controllers
{
    [Authorize(JwtBearerDefaults.AuthenticationScheme)]
    public class RegisterInformationController : BaseController
    {
        private readonly IContactRepository _contactRepository;
        private readonly IScholarshipRepository _scholarshipRepository;
        private readonly IPostRepository _postRepository;
        private readonly ILogger<RegisterInformationController> _logger;
        private readonly IMapper _mapper;
        private readonly int _pageSize = 20;

        public RegisterInformationController(ILogger<RegisterInformationController> logger,
           IMapper mapper, IContactRepository contactRepository
            , IScholarshipRepository scholarshipRepository
            , IPostRepository postRepository)
        {
            _contactRepository = contactRepository;
            _scholarshipRepository = scholarshipRepository;
            _postRepository = postRepository;
            _logger = logger;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index(int? page)
        {
            var filter = HttpContext.Request.Query["search"];
            var status = HttpContext.Request.Query["SelectedStatus"];
            var type = HttpContext.Request.Query["SelectedContactType"];
            var fromdate = HttpContext.Request.Query["fromdate"];
            var todate = HttpContext.Request.Query["todate"];

            DateTime dateTimeFromdate = DateTime.Now.Date;
            DateTime dateTimeTodate = DateTime.Now.Date;

            if (string.IsNullOrEmpty(fromdate))
            {
                fromdate = DateTime.Now.AddDays(-_rangeDayDefault).ToString(_formatDateTime);

            }
            dateTimeFromdate = DateTime.ParseExact(fromdate, _formatDateTime, CultureInfo.InvariantCulture);

            if (string.IsNullOrEmpty(todate))
            {
                todate = DateTime.Now.AddYears(1).ToString(_formatDateTime);

            }

            int statusContact = 0;
            if (!string.IsNullOrEmpty(status))
            {
                statusContact = status.ToString().ToInt32();
            }
            dateTimeTodate = DateTime.ParseExact(todate, _formatDateTime, CultureInfo.InvariantCulture);

            var rs = _contactRepository.GetAllData()
                .Include(x => x.UserReply)
                .Where(x => (string.IsNullOrEmpty(filter) ||
                x.FullName.Contains(filter.ToString()))
                && (string.IsNullOrEmpty(type) || x.RegisterFor == type.ToString())
                && (statusContact == 0 || x.Status == statusContact)
                && x.CreateDate.Date >= dateTimeFromdate
                && x.CreateDate.Date <= dateTimeTodate).AsQueryable().OrderByDescending(x => x.CreateDate).AsNoTracking();
            var data = await PaginatedList<Contact>.CreateAsync(rs, page ?? 1, _pageSize);
            var vm = new ContactViewModel<Contact>
            {
                FromDate = fromdate,
                ToDate = todate,
                SelectedStatus = status.ToString(),
                SelectedContactType = type.ToString(),
                ListItems = StatusList.ListItemStatusContact.ToList(),
                ContactTypes = StatusList.ListRegister.ToList()
            };
            vm.Data = data;
            return View(vm);
        }

        [HttpGet("RegisterInformation/Edit/{id}")]
        public IActionResult Edit(int id)
        { 
            var entity = _contactRepository.GetAllData().FirstOrDefault(x => x.Id == id);
            var data = _mapper.Map<ContactModel>(entity);
            if(entity.RegisterFor == RegisterConstant.Scholarship)
            {
                var scholarship = _scholarshipRepository.GetAllData().FirstOrDefault(x => x.Slug == entity.Slug);
                data.RegisterForName = scholarship.Name;
            }
            else if(entity.RegisterFor == RegisterConstant.Event)
            {
                var post = _postRepository.GetAllData().FirstOrDefault(x => x.Slug == entity.Slug);
                data.RegisterForName = post.Name;
            }
            return View(data);
        }

        [HttpPost("RegisterInformation/Edit/{id}")]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, ContactModel model)
        {
            try
            {
                var contact = _contactRepository.GetAllData().FirstOrDefault(x => x.Id == id);
                var useId = User.FindFirst(ClaimTypes.Name).Value;
                if (contact != null)
                {
                    contact.FullName = model.FullName;
                    contact.Phone = model.Phone;
                    contact.Email = model.Email;
                    contact.ReplyContent = model.ReplyContent;
                    contact.ReplyDate = DateTime.Now;
                    contact.UserReplyId = useId;
                    if (!string.IsNullOrEmpty(model.ReplyContent))
                    {
                        contact.Status = ContactStatus.Replied.GetHashCode();
                    }
                    _contactRepository.Update(contact);
                    return RedirectToAction("Index");
                }
                ModelState.AddModelError(string.Empty, string.Format(MessageConstants.NotExists, "Thông tin liên hệ"));

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                var error = new ResponseModel<int>() { Message = string.Format(MessageConstants.Error, ""), Success = false };

            }
            return View(model);
        }

        public IActionResult ShowDeleteConfirm(int id)
        {
            return PartialView("_Delete", id);
        }

        [HttpDelete("registerinformation/delete/{id}")]
        public IActionResult Delete(int id)
        {
            var rs = new ResponseModel<int>();
            var contact = _contactRepository.GetAllData().FirstOrDefault(x => x.Id == id);
            if(contact != null && contact.Status == ContactStatus.NotYet.GetHashCode())
            {
                _contactRepository.Delete(contact);
                rs.Success = true;
                rs.Message = $"Xóa thông tin {contact.FullName} Thành công!";
            }
            else
            {
                rs.Message = "Xóa thất bại, vui lòng kiểm tra lại thông tin";
            }
            return Json(rs);
        }
    }
}
