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
using Business.IRepostitory;
using Common;
using Entities.Entities;
using Entities.Helpers;
using Model;
using Website.Helpers;
using Website.Models;

namespace Website.Controllers
{
    [Authorize(JwtBearerDefaults.AuthenticationScheme)]
    public class BannersController : BaseController
    {
        private readonly IBannerRepository _bannerRepository;
        private readonly ILogger<BannersController> _logger;
        private readonly IMapper _mapper;
        private readonly int _pageSize = 30;
        public BannersController(IBannerRepository bannerRepository,
            ILogger<BannersController> logger, IMapper mapper)
        {
            _bannerRepository = bannerRepository;
            _logger = logger;
            _mapper = mapper;
        }
        
        [HttpGet("banners/Index")]
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

            int statusFilter = 0;
            if (!string.IsNullOrEmpty(status))
            {
                statusFilter = status.ToString().ToInt32();
            }
            dateTimeTodate = DateTime.ParseExact(todate, _formatDateTime, CultureInfo.InvariantCulture);
            
            var rs = _bannerRepository.GetAllData().
                Where(x => (string.IsNullOrEmpty(filter) ||
                x.Name.Contains(filter.ToString())) &&
               // x.StartDate.Date >= dateTimeFromdate &&
                x.StartDate.Date <= dateTimeTodate &&
                (statusFilter == 0 || x.Status == statusFilter)).AsQueryable().OrderByDescending(x=>x.Status).AsNoTracking();
            var data = await PaginatedList<Banner>.CreateAsync(rs, page ?? 1, _pageSize);
            var vm = new BaseViewModel<Banner>
            {
                FromDate = fromdate,
                ToDate = todate,
                SelectedStatus = status.ToString(),
                ListItems = StatusList.ListItems.ToList()
            };
            vm.Data = data;
            return View(vm);           
        }

        [HttpGet("banners/Addbanner")]
        public IActionResult AddBanner()
        {
            return View();
        }

        [HttpPost("banners/Addbanner")]
        public IActionResult AddBanner(BannerModel model)
        {
            if (ModelState.IsValid)
            {
                var banner = _mapper.Map<Banner>(model);
                if(model.StartDate > model.EndDate)
                {
                    ModelState.AddModelError(string.Empty, $"Ngày kết thúc phải lớn hơn ngày bắt đầu");
                    return View();
                }    
                banner.Status = ApplicationStatus.InProgress.GetHashCode();
               
                if (model.FileImage != null)
                {
                    string folder = $"UploadFiles/Images/Banners/{DateTime.Now:yyyyMMdd}/";
                    banner.ImageLink = ImageUtils.UploadFileImage(model.FileImage, folder);

                }
                _bannerRepository.Add(banner);
                return RedirectToAction("Index");

            }
            return View();
        }

        [HttpGet("banners/Edit/{id}")]
        public IActionResult Edit(Guid id)
        {

            var banner = _bannerRepository.GetAllData().FirstOrDefault(x => x.Id == id);
            if (banner != null && banner.Status != ApplicationStatus.Completed.GetHashCode())
            {
                var model = new BannerModel
                {
                    Id = banner.Id,
                    Name = banner.Name,
                    Status = banner.Status,
                    Type = banner.Type,
                    Url = banner.Url,
                    LinkWeb = banner.LinkWeb,
                    StartDate = banner.StartDate,
                    EndDate = banner.EndDate,
                    Position = banner.Position,
                    Title = banner.Title,                    
                    ImageLink = banner.ImageLink,
                  
                };
                return View(model);
            }
            return RedirectToAction("Index");
        }

        [HttpPost("banners/Edit")]
        public IActionResult Edit(BannerModel model)
        {
            try
            {
                var banner = _bannerRepository.GetAllData().FirstOrDefault(x=>x.Id == model.Id);

                if (banner != null)
                {

                    banner.Name = model.Name;
                    banner.Position = model.Position;
                    banner.StartDate = model.StartDate;
                    banner.Title = model.Title;
                    banner.Url = model.Url;
                 
                    if (model.FileImage != null)
                    {
                        string folder = $"UploadFiles/Images/Banners/{DateTime.Now:yyyyMMdd}/";
                        banner.ImageLink = ImageUtils.UploadFileImage(model.FileImage, folder);

                    }
                    _bannerRepository.Update(banner);
                    return RedirectToAction("Index");

                }
                ModelState.AddModelError(string.Empty, string.Format(MessageConstants.NotExists, "Banner"));

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                var error = new ResponseModel<int>() { Message = string.Format(MessageConstants.Error, ""), Success = false };

            }
            return View(model);
        }

        [HttpGet("banners/RemoveBanner/{id}")]
        public IActionResult RemoveBanner(Guid id)
        {
            try
            {
                var banner = _bannerRepository.GetAllData().FirstOrDefault(x => x.Id == id);
                if (banner != null)
                {
                    var rs = new ResponseModel<int>()
                    {
                        Message = "Banner đã được xử lý",
                        Success = false
                    };
                    if (banner.Status != ApplicationStatus.Completed.GetHashCode())
                    {
                        banner.Status = ApplicationStatus.Delete.GetHashCode();
                        _bannerRepository.Update(banner);
                        rs.Message = string.Format(MessageConstants.Success, "Xóa Banner");
                        rs.Success = true;
                    }
                    return Json(rs);
                }
                var notExist = new ResponseModel<int>() { Message = string.Format(MessageConstants.NotExists, "Banner"), Success = false };
                return Json(notExist);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                var error = new ResponseModel<int>() { Message = string.Format(MessageConstants.Error, ""), Success = false };
                return Json(error);
            }

        }
        [HttpGet("banners/ApproveBanner/{id}/{status}")]
        public IActionResult ApproveBanner(Guid id, int status)
        {
            try
            {
                var banner = _bannerRepository.GetAllData().FirstOrDefault(x => x.Id == id);

                if (banner != null)
                {
                    var rs = new ResponseModel<int>();                    

                     banner.Status = status;
                    _bannerRepository.Update(banner);
                    if (banner.Status == ApplicationStatus.InProgress.GetHashCode())
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
                var notExist = new ResponseModel<int>() { Message = string.Format(MessageConstants.NotExists, "Banner"), Success = false };
                return Json(notExist);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                var error = new ResponseModel<int>() { Message = string.Format(MessageConstants.Error, ""), Success = false };
                return Json(error);
            }
        }
    }
}