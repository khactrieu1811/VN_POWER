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
    public class PartnersController : BaseController
    {
        private readonly IPartnerRepository _partnerRepository;
        private readonly ILogger<PartnersController> _logger;
        private readonly IMapper _mapper;
        private readonly int _pageSize = 30;
        public PartnersController(IPartnerRepository partnerRepository,
            ILogger<PartnersController> logger, IMapper mapper)
        {
            _partnerRepository = partnerRepository;
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

            int statusFilter = 0;
            if (!string.IsNullOrEmpty(status))
            {
                statusFilter = status.ToString().ToInt32();
            }
            dateTimeTodate = DateTime.ParseExact(todate, _formatDateTime, CultureInfo.InvariantCulture);
            
            var rs = _partnerRepository.GetAllData().
                Where(x => (string.IsNullOrEmpty(filter) ||
                x.Name.Contains(filter.ToString())) &&
                (statusFilter == 0 || x.Status == statusFilter)).AsQueryable().OrderByDescending(x=>x.Status).AsNoTracking();
            var data = await PaginatedList<Partner>.CreateAsync(rs, page ?? 1, _pageSize);
            var vm = new BaseViewModel<Partner>
            {
                FromDate = fromdate,
                ToDate = todate,
                SelectedStatus = status.ToString(),
                ListItems = StatusList.ListItems.ToList()
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
        public IActionResult Add(PartnerModel model)
        {
            if (ModelState.IsValid)
            {
                var partner = _mapper.Map<Partner>(model);

                partner.Status = ApplicationStatus.InProgress.GetHashCode();
                partner.CreatedDate = DateTime.Now;
                if (model.FileImage != null)
                {
                    string folder = $"UploadFiles/Images/Partners/{DateTime.Now:yyyyMMdd}/";
                    partner.Logo = ImageUtils.UploadFileImage(model.FileImage, folder);

                }
                _partnerRepository.Add(partner);
                return RedirectToAction("Index");

            }
            return View();
        }

        [HttpGet("partners/Edit/{id}")]
        public IActionResult Edit(int id)
        {

            var partner = _partnerRepository.GetAllData().FirstOrDefault(x => x.Id == id);
            var model = _mapper.Map<PartnerModel>(partner);
            return View(model);
            //return RedirectToAction("Index");
        }

        [HttpPost("partners/Edit/{id}")]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, PartnerModel model)
        {
            try
            {
                var partner = _partnerRepository.GetAllData().FirstOrDefault(x=>x.Id == id);

                if (partner != null)
                {

                    partner.Name = model.Name;
                    partner.Description = model.Description;
                    partner.IsEnglish = model.IsEnglish;
                    partner.PostLink = model.PostLink;
                    partner.UpdatedDate = DateTime.Now;
                    if (model.FileImage != null)
                    {
                        string folder = $"UploadFiles/Images/Partners/{DateTime.Now:yyyyMMdd}/";
                        partner.Logo = ImageUtils.UploadFileImage(model.FileImage, folder);

                    }
                    _partnerRepository.Update(partner);
                    return RedirectToAction("Index");

                }
                ModelState.AddModelError(string.Empty, string.Format(MessageConstants.NotExists, "Partner"));

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                var error = new ResponseModel<int>() { Message = string.Format(MessageConstants.Error, ""), Success = false };

            }
            return View(model);
        }

        [HttpDelete("partners/Delete/{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var partner = _partnerRepository.GetAllData().FirstOrDefault(x => x.Id == id);
                if (partner != null)
                {
                    var rs = new ResponseModel<int>()
                    {
                        Message = "Partner đã được xử lý",
                        Success = false
                    };
                    if (partner.Status != ApplicationStatus.Completed.GetHashCode())
                    {
                        partner.Status = ApplicationStatus.Delete.GetHashCode();
                        _partnerRepository.Update(partner);
                        rs.Message = string.Format(MessageConstants.Success, "Xóa Partner");
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
        [HttpGet("partners/Approve/{id}/{status}")]
        public IActionResult Approve(int id, int status)
        {
            try
            {
                var partner = _partnerRepository.GetAllData().FirstOrDefault(x => x.Id == id);

                if (partner != null)
                {
                    var rs = new ResponseModel<int>();

                    partner.Status = status;
                    partner.IsApproved = true;
                    _partnerRepository.Update(partner);
                    if (partner.Status == ApplicationStatus.InProgress.GetHashCode())
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
    }
}