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
    public class CategoryProductsController : BaseController
    {
        private readonly ICategoryProductRepository _categoryProductRepository;
        private readonly ILogger<CategoryProductsController> _logger;
        private readonly IMapper _mapper;
        private readonly int _pageSize = 30;
        public CategoryProductsController(ICategoryProductRepository categoryProductRepository,
            ILogger<CategoryProductsController> logger, IMapper mapper)
        {

            _categoryProductRepository = categoryProductRepository;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet()]
        public async Task<IActionResult> Index(int? page)
        {
            var filter = HttpContext.Request.Query["search"];
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
            dateTimeTodate = DateTime.ParseExact(todate, _formatDateTime, CultureInfo.InvariantCulture);

            var rs = _categoryProductRepository.GetAllData().
                Where(x => (string.IsNullOrEmpty(filter) ||
                x.Name.Contains(filter.ToString()))
                && x.DateCreated.Date >= dateTimeFromdate
                && x.DateCreated.Date <= dateTimeTodate).AsQueryable().OrderByDescending(x => x.OrderDisplay).AsNoTracking();
            var data = await PaginatedList<CategoryProduct>.CreateAsync(rs, page ?? 1, _pageSize);
            var vm = new BaseViewModel<CategoryProduct>
            {
                FromDate = fromdate,
                ToDate = todate,
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
        public IActionResult Add(CategoryProductModel model)
        {
            if (ModelState.IsValid)
            {
                var categoryproduct = _mapper.Map<CategoryProduct>(model);
                categoryproduct.Slug = CreateSlug(model.Name);
                categoryproduct.IsLocked = false;
                categoryproduct.DateCreated = DateTime.Now;

                if (model.FileImage != null)
                {
                    string folder = $"UploadFiles/Images/CategoryProduct/{DateTime.Now:yyyyMMdd}/";
                    categoryproduct.Image = ImageUtils.UploadFileImage(model.FileImage, folder);
                }

                _categoryProductRepository.Add(categoryproduct);
                return RedirectToAction("Index");

            }
            return View();
        }
        [HttpGet("categoryProducts/Edit/{id}")]
        public IActionResult Edit(Guid id)
        {

            var categoryproduct = _categoryProductRepository.GetAllData().FirstOrDefault(x => x.Id == id);
            if (categoryproduct != null)
            {
                var model = _mapper.Map<CategoryProductModel>(categoryproduct);
                var cate = _categoryProductRepository.GetAllData().FirstOrDefault(x => x.Id == model.ParentId);

                return View(model);
            }
            return RedirectToAction("Index");
        }

        [HttpPost()]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Guid id, CategoryProductModel model)
        {
            try
            {
                var category = _categoryProductRepository.GetAllData().FirstOrDefault(x => x.Id == id);

                if (category != null)
                {
                    category.Name = model.Name;
                    category.Slug = CreateSlug(model.Name);
                    category.Description = model.Description;
                    category.PageTitle = model.PageTitle;
                    category.Path = model.Path;
                    category.Colour = model.Colour;
                    category.ExtendedDataString = model.ExtendedDataString;
                    category.MetaDescription = model.MetaDescription;
                    category.ParentId = model.ParentId;
                    if (model.OrderDisplay != null)
                    {
                        category.OrderDisplay = model.OrderDisplay;
                    }
                    category.DateCreated = DateTime.Now;
                    if (model.FileImage != null)
                    {
                        string folder = $"UploadFiles/Images/CategoryProduct/{DateTime.Now:yyyyMMdd}/";
                        category.Image = ImageUtils.UploadFileImage(model.FileImage, folder);

                    }
                    _categoryProductRepository.Update(category);
                    return RedirectToAction("Index");
                }
                ModelState.AddModelError(string.Empty, string.Format(MessageConstants.NotExists, "Chuyên mục"));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                var error = new ResponseModel<int>() { Message = string.Format(MessageConstants.Error, ""), Success = false };

            }
            return View(model);
        }
        [HttpDelete("categoryProducts/Delete/{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                var category = _categoryProductRepository.GetAllData().FirstOrDefault(x => x.Id == id);
                if (category != null)
                {
                    var rs = new ResponseModel<int>()
                    {
                        Message = "Xóa chuyên mục",
                        Success = false
                    };
                    if (category.IsLocked)
                    {
                        _categoryProductRepository.Delete(category);
                        rs.Message = string.Format(MessageConstants.Success, "Xóa chuyên mục");
                        rs.Success = true;
                    }
                    return Json(rs);
                }
                var notExist = new ResponseModel<int>() { Message = string.Format(MessageConstants.NotExists, "Chuyên mục"), Success = false };
                return Json(notExist);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                var error = new ResponseModel<int>() { Message = string.Format(MessageConstants.Error, ""), Success = false };
                return Json(error);
            }

        }
        [HttpGet("categoryProducts/ChangeState/{id}/{state}")]
        public IActionResult ChangeState(Guid id, bool state)
        {
            try
            {
                var category = _categoryProductRepository.GetAllData().FirstOrDefault(x => x.Id == id);

                if (category != null)
                {
                    var rs = new ResponseModel<int>();

                    category.IsLocked = state;
                    _categoryProductRepository.Update(category);
                    if (!state)
                    {
                        rs.Message = string.Format(MessageConstants.Success, "Mở chuyên mục");
                        rs.Success = true;
                    }
                    else
                    {
                        rs.Message = string.Format(MessageConstants.Success, "Khóa chuyên mục");
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
            var existed = _categoryProductRepository.GetAllData().Where(x => x.Slug.Contains(newSlug)).ToList();
            if (existed.Any())
            {
                newSlug = $"{newSlug}_{(existed.Count + 1)}";
            }
            return newSlug;
        }

    }
}
