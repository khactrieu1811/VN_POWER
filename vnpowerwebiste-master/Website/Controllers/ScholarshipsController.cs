using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Common;
using Entities.Entities;
using Entities.Helpers;
using Model;
using Website.Helpers;
using Website.Models;
using System.Security.Claims;
using Business.IRepostitory;

namespace Website.Controllers
{
    [Authorize(JwtBearerDefaults.AuthenticationScheme)]
    public class ScholarshipsController : BaseController
    {
        private readonly IScholarshipRepository _scholarshipRepository;
        private readonly ILogger<ScholarshipsController> _logger;
        private readonly IMapper _mapper;
        private readonly int _pageSize = 30;
        public ScholarshipsController(IScholarshipRepository scholarshipRepository,
            ILogger<ScholarshipsController> logger, IMapper mapper)
        {
            _scholarshipRepository = scholarshipRepository;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet()]
        public async Task<IActionResult> Index(int? page)
        {
            var filter = HttpContext.Request.Query["search"];
            var status = HttpContext.Request.Query["SelectedStatus"];
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

            bool aprroveFilter = false;
            if (!string.IsNullOrEmpty(status))
            {
                aprroveFilter = bool.Parse(status);
            }
            dateTimeTodate = DateTime.ParseExact(todate, _formatDateTime, CultureInfo.InvariantCulture);

            var rs = _scholarshipRepository.GetAllData()
                .Include(x => x.ScholarshipType).Include(x => x.Region)
                .Where(x => (string.IsNullOrEmpty(filter) ||
                x.Name.Contains(filter.ToString()))
                && (string.IsNullOrEmpty(status) || x.IsApproved == aprroveFilter)
                && x.CreatedDate.Date >= dateTimeFromdate
                && x.CreatedDate.Date <= dateTimeTodate).AsQueryable().OrderByDescending(x => x.CreatedDate).AsNoTracking();
            var data = await PaginatedList<Scholarship>.CreateAsync(rs, page ?? 1, _pageSize);
            var vm = new BaseViewModel<Scholarship>
            {
                FromDate = fromdate,
                ToDate = todate,
                SelectedStatus = status.ToString(),
                ListItems = StatusList.ListPostStatus.ToList()
            };
            vm.Data = data;
            return View(vm);
        }

        [HttpGet()]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost()]
        [ValidateAntiForgeryToken]
        public IActionResult Add(ScholarshipModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    model.Slug = CreateSlug(model.Name);
                    model.IsApproved = false;
                    model.IsLocked = false;
                    model.CreatedDate = DateTime.Now;
                    model.UserId = User.FindFirst(ClaimTypes.Name).Value;
                    model.EndDate = DateTime.ParseExact(model.EndDateString, "dd/MM/yyyy HH:mm",
                                       CultureInfo.InvariantCulture);
                    if (model.FileImage != null)
                    {
                        string folder = $"UploadFiles/Images/entitys/{DateTime.Now:yyyyMMdd}/";
                        model.Image = ImageUtils.UploadFileImage(model.FileImage, folder);

                    }
                    _scholarshipRepository.Insert(model);
                    return RedirectToAction("Index");

                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                ModelState.AddModelError(string.Empty, string.Format(MessageConstants.Error, ""));
            }

            return View();
        }

        [HttpGet("scholarships/Edit/{id}")]
        public IActionResult Edit(Guid id)
        {

            var entity = _scholarshipRepository.GetAllData().Include(x=>x.ScholarshipTags).ThenInclude(x=>x.Tag).FirstOrDefault(x => x.Id == id);
            if (entity != null)
            {
                var model = _mapper.Map<ScholarshipModel>(entity);
                var tags = entity.ScholarshipTags.Select(x => x.Tag).ToList();
                model.Tags = string.Join(",", tags.Select(x=>x.Name).Distinct());
                model.EndDateString = model.EndDate.ToString("dd/MM/yyyy HH:mm");
                return View(model);
            }
            return RedirectToAction("Index");
        }

        [HttpPost()]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Guid id, ScholarshipModel model)
        {
            try
            {
                var entity = _scholarshipRepository.GetAllData().FirstOrDefault(x => x.Id == id);

                if (entity != null)
                {
                    entity.IsEnglish = model.IsEnglish;
                    entity.MetaDescription = model.MetaDescription;
                    entity.Name = model.Name;
                    entity.Slug = CreateSlug(model.Name);
                    entity.PostContent = model.PostContent;
                    entity.ExternalLink = model.ExternalLink;
                    entity.Description = model.Description;
                    entity.IsHotPost = model.IsHotPost;
                    // entity.RegionId = model.RegionId;
                    // entity.ScholarshipTypeId = model.ScholarshipTypeId;
                    entity.Label = model.Label;
                    entity.EndDate = DateTime.ParseExact(model.EndDateString, "dd/MM/yyyy HH:mm",
                                       CultureInfo.InvariantCulture); 
                   
                    if(model.DisplayOrder != null)
                    {
                        entity.DisplayOrder = model.DisplayOrder;
                    }
                    entity.UpdatedDate = DateTime.Now;
                    if (model.FileImage != null)
                    {
                        string folder = $"UploadFiles/Images/entitys/{DateTime.Now:yyyyMMdd}/";
                        entity.Image = ImageUtils.UploadFileImage(model.FileImage, folder);

                    }
                    _scholarshipRepository.Update(entity, model.Tags);
                    return RedirectToAction("Index");
                }
                ModelState.AddModelError(string.Empty, string.Format(MessageConstants.NotExists, "Học bổng"));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                var error = new ResponseModel<int>() { Message = string.Format(MessageConstants.Error, ""), Success = false };
                ModelState.AddModelError(string.Empty, error.Message);
            }

            return View(model);
        }

        [HttpDelete("scholarships/Delete/{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                var entity = _scholarshipRepository.GetAllData().FirstOrDefault(x => x.Id == id);
                if (entity != null)
                {
                    var rs = new ResponseModel<int>()
                    {
                        Message = "Bài viết đã được xử lý",
                        Success = false
                    };
                    if (entity.IsLocked)
                    {
                        _scholarshipRepository.Delete(entity);
                        rs.Message = string.Format(MessageConstants.Success, "Xóa bài viết");
                        rs.Success = true;
                    }
                    return Json(rs);
                }
                var notExist = new ResponseModel<int>() { Message = string.Format(MessageConstants.NotExists, "Partner"), Success = false };
                return Json(notExist);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                var error = new ResponseModel<int>() { Message = string.Format(MessageConstants.Error, ""), Success = false };
                return Json(error);
            }

        }

        [HttpGet("scholarships/Approve/{id}/{isApprove}")]
        public IActionResult Approve(Guid id, bool isApprove)
        {
            try
            {
                var entity = _scholarshipRepository.GetAllData().FirstOrDefault(x => x.Id == id);

                if (entity != null)
                {
                    var rs = new ResponseModel<int>();

                    entity.IsApproved = isApprove;
                    _scholarshipRepository.Update(entity);
                    if (!isApprove)
                    {
                        rs.Message = string.Format(MessageConstants.Success, "Bỏ Duyệt");
                        rs.Success = true;
                    }
                    else
                    {
                        rs.Message = string.Format(MessageConstants.Success, "Duyệt");
                        rs.Success = true;
                    }


                    return Json(rs);
                }
                var notExist = new ResponseModel<int>() { Message = string.Format(MessageConstants.NotExists, "Partner"), Success = false };
                return Json(notExist);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                var error = new ResponseModel<int>() { Message = string.Format(MessageConstants.Error, ""), Success = false };
                return Json(error);
            }
        }

        [HttpGet("scholarships/ChangeState/{id}/{state}")]
        public IActionResult ChangeState(Guid id, bool state)
        {
            try
            {
                var entity = _scholarshipRepository.GetAllData().FirstOrDefault(x => x.Id == id);

                if (entity != null)
                {
                    var rs = new ResponseModel<int>();

                    entity.IsLocked = state;
                    _scholarshipRepository.Update(entity);
                    if (!state)
                    {
                        rs.Message = string.Format(MessageConstants.Success, "Mở bài viết");
                        rs.Success = true;
                    }
                    else
                    {
                        rs.Message = string.Format(MessageConstants.Success, "Khóa bài");
                        rs.Success = true;
                    }


                    return Json(rs);
                }
                var notExist = new ResponseModel<int>() { Message = string.Format(MessageConstants.NotExists, "Partner"), Success = false };
                return Json(notExist);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                var error = new ResponseModel<int>() { Message = string.Format(MessageConstants.Error, ""), Success = false };
                return Json(error);
            }
        }

        private string CreateSlug(string name)
        {
            var newSlug = StringUtils.CreateUrlSlug(name);
            var existed = _scholarshipRepository.GetAllData().Where(x => x.Slug.Contains(newSlug)).ToList();
            if (existed.Any())
            {
                newSlug = $"{newSlug}_{(existed.Count + 1)}";
            }
            return newSlug;
        }
    }
}