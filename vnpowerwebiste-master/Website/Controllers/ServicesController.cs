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
    public class ServicesController : BaseController
    {
        private readonly IServiceRepository _serviceRepository;
        private readonly ILogger<ServicesController> _logger;
        private readonly IMapper _mapper;
        private readonly int _pageSize = 30;
        public ServicesController(IServiceRepository serviceRepository,
            ILogger<ServicesController> logger, IMapper mapper)
        {
            _serviceRepository = serviceRepository;
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

            int statusFilter = 0;
            if (!string.IsNullOrEmpty(status))
            {
                statusFilter = status.ToString().ToInt32();
            }
           
            var rs = _serviceRepository.GetAllData().
                Where(x => (string.IsNullOrEmpty(filter) ||
                x.Name.Contains(filter.ToString())) &&
                (statusFilter == 0 || x.Status == statusFilter)).AsQueryable().OrderByDescending(x=>x.Status).AsNoTracking();
            var data = await PaginatedList<Service>.CreateAsync(rs, page ?? 1, _pageSize);
            var vm = new BaseViewModel<Service>
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
        public IActionResult Add(ServiceModel model)
        {
            if (ModelState.IsValid)
            {
                var Service = _mapper.Map<Service>(model);

                Service.Status = ApplicationStatus.InProgress.GetHashCode();
                Service.CreatedDate = DateTime.Now;
                if (model.FileImage != null)
                {
                    string folder = $"UploadFiles/Images/Services/{DateTime.Now:yyyyMMdd}/";
                    Service.Logo = ImageUtils.UploadFileImage(model.FileImage, folder);

                }
                _serviceRepository.Add(Service);
                return RedirectToAction("Index");

            }
            return View();
        }

        [HttpGet("Services/Edit/{id}")]
        public IActionResult Edit(int id)
        {

            var Service = _serviceRepository.GetAllData().FirstOrDefault(x => x.Id == id);
            var model = _mapper.Map<ServiceModel>(Service);
            return View(model);
        }

        [HttpPost("Services/Edit")]
        public IActionResult Edit(ServiceModel model)
        {
            try
            {
                var entity = _serviceRepository.GetAllData().FirstOrDefault(x=>x.Id == model.Id);

                if (entity != null)
                {

                    entity.Name = model.Name;
                    entity.Description = model.Description;
                    entity.IsEnglish = model.IsEnglish;
                    entity.PostLink = model.PostLink;
                    entity.UpdatedDate = DateTime.Now;
                    if (model.FileImage != null)
                    {
                        string folder = $"UploadFiles/Images/Services/{DateTime.Now:yyyyMMdd}/";
                        entity.Logo = ImageUtils.UploadFileImage(model.FileImage, folder);

                    }
                    _serviceRepository.Update(entity);
                    return RedirectToAction("Index");

                }
                ModelState.AddModelError(string.Empty, string.Format(MessageConstants.NotExists, "Dịch vụ"));
                
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                var error = new ResponseModel<int>() { Message = string.Format(MessageConstants.Error, ""), Success = false };

            }
            return View(model);
        }

        [HttpDelete("Services/Delete/{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var Service = _serviceRepository.GetAllData().FirstOrDefault(x => x.Id == id);
                if (Service != null)
                {
                    var rs = new ResponseModel<int>()
                    {
                        Message = "Service đã được xử lý",
                        Success = false
                    };
                    if (Service.Status != ApplicationStatus.Completed.GetHashCode())
                    {
                        Service.Status = ApplicationStatus.Delete.GetHashCode();
                        _serviceRepository.Update(Service);
                        rs.Message = string.Format(MessageConstants.Success, "Xóa Service");
                        rs.Success = true;
                    }
                    return Json(rs);
                }
                var notExist = new ResponseModel<int>() { Message = string.Format(MessageConstants.NotExists, "Service"), Success = false };
                return Json(notExist);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                var error = new ResponseModel<int>() { Message = string.Format(MessageConstants.Error, ""), Success = false };
                return Json(error);
            }

        }
        [HttpGet("Services/Approve/{id}/{status}")]
        public IActionResult Approve(int id, int status)
        {
            try
            {
                var Service = _serviceRepository.GetAllData().FirstOrDefault(x => x.Id == id);

                if (Service != null)
                {
                    var rs = new ResponseModel<int>();

                    Service.Status = status;
                    Service.IsApproved = true;
                    _serviceRepository.Update(Service);
                    if (Service.Status == ApplicationStatus.InProgress.GetHashCode())
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
                var notExist = new ResponseModel<int>() { Message = string.Format(MessageConstants.NotExists, "Service"), Success = false };
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