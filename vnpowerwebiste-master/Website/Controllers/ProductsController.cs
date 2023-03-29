using AutoMapper;
using Business.IRepostitory;
using Common;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Entities.Entities;
using Entities.Helpers;
using Model;
using Website.Helpers;
using Website.Models;
using System.Security.Claims;
namespace Website.Controllers
{
    [Authorize(JwtBearerDefaults.AuthenticationScheme)]
    public class ProductsController : BaseController
    {
        private readonly IProductRepository _productRepository;
        private readonly ILogger<ProductsController> _logger;
        private readonly IMapper _mapper;
        private readonly int _pageSize = 30;
        public ProductsController(IProductRepository productRepository,
            ILogger<ProductsController> logger, IMapper mapper)
        {
            _productRepository = productRepository;
            _logger = logger;
            _mapper = mapper;
        }
        [HttpGet("products/Index")]
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

            var rs = _productRepository.GetAllData().Include(x => x.ApplicationUser).
                Where(x => (string.IsNullOrEmpty(filter) ||
                x.Name.Contains(filter.ToString()))
                && (string.IsNullOrEmpty(status) || x.IsApproved == aprroveFilter)
                && x.CreatedDate.Date >= dateTimeFromdate
                && x.CreatedDate.Date <= dateTimeTodate).AsQueryable().OrderByDescending(x => x.CreatedDate).AsNoTracking();
            var data = await PaginatedList<Product>.CreateAsync(rs, page ?? 1, _pageSize);
            var vm = new BaseViewModel<Product>
            {
                FromDate = fromdate,
                ToDate = todate,
                SelectedStatus = status.ToString(),
                ListItems = StatusList.ListPostStatus.ToList()
            };
            vm.Data = data;
            return View(vm);
        }
        [HttpGet("products/Add")]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost()]
        [ValidateAntiForgeryToken]
        public IActionResult Add(ProductModel model)
        {
            if (ModelState.IsValid)
            {
                var product = _mapper.Map<Product>(model);
                product.MetaTitle = CreateTitle(model.Name);
                product.IsApproved = false;
                product.IsLocked = false;
                product.CreatedDate = DateTime.Now;
                product.UserId = User.FindFirst(ClaimTypes.Name).Value;
                if (model.FileImage != null)
                {
                    string folder = $"UploadFiles/Images/Posts/{DateTime.Now:yyyyMMdd}/";
                    product.Image = ImageUtils.UploadFileImage(model.FileImage, folder);

                }

                if (model.PromotionStartDate>model.PromotionEndDate)
                {
                    ModelState.AddModelError(string.Empty, $"Ngày kết thúc phải lớn hơn ngày bắt đầu");
                    return View();
                }
                _productRepository.Add(product);
                return RedirectToAction("Index");

            }
            return View();
        }
        [HttpGet("products/Edit/{id}")]
        public IActionResult Edit(Guid id)
        {

            var product = _productRepository.GetAllData().FirstOrDefault(x => x.Id == id);
            if (product != null)
            {
                var model = _mapper.Map<ProductModel>(product);

                return View(model);
            }
            return RedirectToAction("Index");
        }
        [HttpPost()]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Guid id, ProductModel model)
        {
            try
            {
                var product = _productRepository.GetAllData().FirstOrDefault(x => x.Id == id);

                if (product != null)
                {
                    
                    product.Name = model.Name;
                    product.MetaTitle = model.MetaTitle;
                    product.IsHotPost = model.IsHotPost;
                    product.Description = model.Description;
                    product.Price = model.Price;
                    product.MetaTitle = CreateTitle(model.Name);
                    product.PromotionPrice = model.PromotionPrice;
                    product.PromotionStartDate = model.PromotionStartDate;
                    product.PromotionEndDate = model.PromotionEndDate;
                    product.Quantity = model.Quantity;
                    product.Warranty = model.Warranty;
                    product.Detail = model.Detail;
                    product.CategoryId = model.CategoryId;
                    product.UpdatedDate = DateTime.Now;
                    if (model.DisplayOrder != null)
                    {
                        product.DisplayOrder = model.DisplayOrder;
                    }
                    product.UpdatedDate = DateTime.Now;
                    if (model.FileImage != null)
                    {
                        string folder = $"UploadFiles/Images/Posts/{DateTime.Now:yyyyMMdd}/";
                        product.Image = ImageUtils.UploadFileImage(model.FileImage, folder);

                    }
                    _productRepository.Update(product);
                    return RedirectToAction("Index");
                }
                ModelState.AddModelError(string.Empty, string.Format(MessageConstants.NotExists, "Sản phẩm"));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                var error = new ResponseModel<int>() { Message = string.Format(MessageConstants.Error, ""), Success = false };

            }
            return View(model);
        }
        //Xóa sản phẩm
        [HttpDelete("products/Delete/{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                var product = _productRepository.GetAllData().FirstOrDefault(x => x.Id == id);
                if (product != null)
                {
                    var rs = new ResponseModel<int>()
                    {
                        Message = "Sản phẩm đã được xử lý",
                        Success = false
                    };
                    if (product.IsLocked)
                    {
                        _productRepository.Delete(product);
                        rs.Message = string.Format(MessageConstants.Success, "Xóa sản phẩm");
                        rs.Success = true;
                    }
                    return Json(rs);
                }
                var notExist = new ResponseModel<int>() { Message = string.Format(MessageConstants.NotExists, "Sản phẩm"), Success = false };
                return Json(notExist);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                var error = new ResponseModel<int>() { Message = string.Format(MessageConstants.Error, ""), Success = false };
                return Json(error);
            }

        }
        [HttpGet("products/Approve/{id}/{isApprove}")]
        public IActionResult Approve(Guid id, bool isApprove)
        {
            try
            {
                var product = _productRepository.GetAllData().FirstOrDefault(x => x.Id == id);

                if (product != null)
                {
                    var rs = new ResponseModel<int>();

                    product.IsApproved = isApprove;
                    _productRepository.Update(product);
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

        [HttpGet("products/ChangeState/{id}/{state}")]
        public IActionResult ChangeState(Guid id, bool state)
        {
            try
            {
                var product = _productRepository.GetAllData().FirstOrDefault(x => x.Id == id);

                if (product != null)
                {
                    var rs = new ResponseModel<int>();

                    product.IsLocked = state;
                    _productRepository.Update(product);
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
        private string CreateTitle(string name)
        {
            var newTitle = StringUtils.CreateUrlSlug(name);
            var existed = _productRepository.GetAllData().Where(x => x.MetaTitle.Contains(newTitle)).ToList();
            if (existed.Any())
            {
                newTitle = $"{newTitle}_{(existed.Count + 1)}";
            }
            var check = _productRepository.GetAllData().Where(x => x.MetaTitle == newTitle).ToList();
            while(_productRepository.GetAllData().Where(x => x.MetaTitle == newTitle).ToList().Count() != 0)
            {
                int i = 1;
                newTitle = $"{newTitle}_{i}";
                i++;
            }
            return newTitle;
        }

    }
}
