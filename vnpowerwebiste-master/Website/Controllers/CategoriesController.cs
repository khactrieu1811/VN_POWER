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
    public class CategoriesController : BaseController
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly ILogger<CategoriesController> _logger;
        private readonly IMapper _mapper;
        private readonly int _pageSize = 30;
        public CategoriesController(ICategoryRepository categoryRepository,
            ILogger<CategoriesController> logger, IMapper mapper)
        {

            _categoryRepository = categoryRepository;
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

            var rs = _categoryRepository.GetAllData().
                Where(x => (string.IsNullOrEmpty(filter) ||
                x.Name.Contains(filter.ToString()))
                && x.DateCreated.Date >= dateTimeFromdate
                && x.DateCreated.Date <= dateTimeTodate).AsQueryable().OrderByDescending(x => x.OrderDisplay).AsNoTracking();
            var data = await PaginatedList<Category>.CreateAsync(rs, page ?? 1, _pageSize);
            var vm = new BaseViewModel<Category>
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
        public IActionResult Add(CategoryModel model)
        {
            if (ModelState.IsValid)
            {
                var category = _mapper.Map<Category>(model);
                category.Slug = CreateSlug(model.Name);
                category.IsLocked = false;
                category.DateCreated = DateTime.Now;

                if (model.FileImage != null)
                {
                    string folder = $"UploadFiles/Images/Category/{DateTime.Now:yyyyMMdd}/";
                    category.Image = ImageUtils.UploadFileImage(model.FileImage, folder);
                }

                _categoryRepository.Add(category);
                return RedirectToAction("Index");

            }
            return View();
        }
        [HttpGet("categories/Edit/{id}")]
        public IActionResult Edit(Guid id)
        {

            var category = _categoryRepository.GetAllData().FirstOrDefault(x => x.Id == id);
            if (category != null)
            {
                var model = _mapper.Map<CategoryModel>(category);
                var cate = _categoryRepository.GetAllData().FirstOrDefault(x => x.Id == model.ParentId);

                return View(model);
            }
            return RedirectToAction("Index");
        }

        [HttpPost()]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Guid id, CategoryModel model)
        {
            try
            {
                var category = _categoryRepository.GetAllData().FirstOrDefault(x => x.Id == id);

                if (category != null)
                {

                    category.PageTitle = model.PageTitle;
                    category.Path = model.Path;
                    category.Colour = model.Colour;
                    category.ExtendedDataString = model.ExtendedDataString;
                    category.MetaDescription = model.MetaDescription;
                    category.Name = model.Name;
                    category.Slug = CreateSlug(model.Name);
                    category.Description = model.Description;
                    category.ParentId = model.ParentId;
                    if (model.OrderDisplay != null)
                    {
                        category.OrderDisplay = model.OrderDisplay;
                    }
                    category.DateCreated = DateTime.Now;
                    if (model.FileImage != null)
                    {
                        string folder = $"UploadFiles/Images/Category/{DateTime.Now:yyyyMMdd}/";
                        category.Image = ImageUtils.UploadFileImage(model.FileImage, folder);

                    }
                    _categoryRepository.Update(category);
                    return RedirectToAction("Index");
                }
                ModelState.AddModelError(string.Empty, string.Format(MessageConstants.NotExists, "Bài viết"));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                var error = new ResponseModel<int>() { Message = string.Format(MessageConstants.Error, ""), Success = false };

            }
            return View(model);
        }
        [HttpDelete("categories/Delete/{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                var category = _categoryRepository.GetAllData().FirstOrDefault(x => x.Id == id);
                if (category != null)
                {
                    var rs = new ResponseModel<int>()
                    {
                        Message = "Xóa chuyên mục",
                        Success = false
                    };
                    if (category.IsLocked)
                    {
                        _categoryRepository.Delete(category);
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
        [HttpGet("categories/ChangeState/{id}/{state}")]
        public IActionResult ChangeState(Guid id, bool state)
        {
            try
            {
                var category = _categoryRepository.GetAllData().FirstOrDefault(x => x.Id == id);

                if (category != null)
                {
                    var rs = new ResponseModel<int>();

                    category.IsLocked = state;
                    _categoryRepository.Update(category);
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
            var existed = _categoryRepository.GetAllData().Where(x => x.Slug.Contains(newSlug)).ToList();
            if (existed.Any())
            {
                newSlug = $"{newSlug}_{(existed.Count + 1)}";
            }
            return newSlug;
        }
    }
}