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
using System.Security.Claims;

namespace Website.Controllers
{
    [Authorize(JwtBearerDefaults.AuthenticationScheme)]
    public class PostsController : BaseController
    {
        private readonly IPostRepository _postRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly ILogger<PostsController> _logger;
        private readonly IMapper _mapper;
        private readonly int _pageSize = 30;
        public PostsController(IPostRepository postRepository, ICategoryRepository categoryRepository,
            ILogger<PostsController> logger, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _postRepository = postRepository;
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

            var rs = _postRepository.GetAllData().Include(x => x.Category).
                Where(x => (string.IsNullOrEmpty(filter) ||
                x.Name.Contains(filter.ToString()))
                && (string.IsNullOrEmpty(status) || x.IsApproved == aprroveFilter)
                && x.CreatedDate.Date >= dateTimeFromdate
                && x.CreatedDate.Date <= dateTimeTodate).AsQueryable().OrderByDescending(x => x.CreatedDate).AsNoTracking();
            var data = await PaginatedList<Post>.CreateAsync(rs, page ?? 1, _pageSize);
            var vm = new BaseViewModel<Post>
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
        public IActionResult Add(PostModel model)
        {
            if (ModelState.IsValid)
            {
                var post = _mapper.Map<Post>(model);
                post.Slug = CreateSlug(model.Name);
                post.PostContent = model.PostContent;
                post.IsApproved = false;
                post.IsLocked = false;
                post.CreatedDate = DateTime.Now;
                post.UserId = User.FindFirst(ClaimTypes.Name).Value;
                if (model.FileImage != null)
                {
                    string folder = $"UploadFiles/Images/Posts/{DateTime.Now:yyyyMMdd}/";
                    post.Image = ImageUtils.UploadFileImage(model.FileImage, folder);

                }

                if (!string.IsNullOrEmpty(model.EndDateString))
                {
                    post.RegisterEndDateEvent = DateTime.ParseExact(model.EndDateString, "dd/MM/yyyy HH:mm",
                                     CultureInfo.InvariantCulture); 
                }
                _postRepository.Add(post);
                return RedirectToAction("Index");

            }
            return View();
        }

        [HttpGet("posts/Edit/{id}")]
        public IActionResult Edit(Guid id)
        {

            var post = _postRepository.GetAllData().FirstOrDefault(x => x.Id == id);
            if (post != null)
            {
                var model = _mapper.Map<PostModel>(post);
                var cate = _categoryRepository.GetAllData().FirstOrDefault(x =>x.Id == model.CategoryId);
                if (cate != null && cate.Name == PostConstant.Event)
                {
                   model.EndDateString = model.RegisterEndDateEvent.Value.ToString("dd/MM/yyyy HH:mm");
                }
              
                return View(model);
            }
            return RedirectToAction("Index");
        }

        [HttpPost()]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Guid id, PostModel model)
        {
            try
            {
                var post = _postRepository.GetAllData().FirstOrDefault(x => x.Id == id);

                if (post != null)
                {
                   
                    post.IsEnglish = model.IsEnglish;
                    post.IsHotPost = model.IsHotPost;
                    post.MetaDescription = model.MetaDescription;
                    post.Name = model.Name;
                    post.Slug = CreateSlug(model.Name);
                    post.PostContent = model.PostContent;
                    post.ExternalLink = model.ExternalLink;
                    post.Description = model.Description;
                    post.CategoryId = model.CategoryId;
                    if (model.DisplayOrder != null)
                    {
                        post.DisplayOrder = model.DisplayOrder;
                    }
                    if (!string.IsNullOrEmpty(model.EndDateString))
                    {
                        post.RegisterEndDateEvent = DateTime.ParseExact(model.EndDateString, "dd/MM/yyyy HH:mm",
                                         CultureInfo.InvariantCulture); 
                    }
                    
                    if (!string.IsNullOrEmpty(model.TimeEvent))
                    {
                        post.TimeEvent = model.TimeEvent;
                    }
                    post.UpdatedDate = DateTime.Now;
                    if (model.FileImage != null)
                    {
                        string folder = $"UploadFiles/Images/Posts/{DateTime.Now:yyyyMMdd}/";
                        post.Image = ImageUtils.UploadFileImage(model.FileImage, folder);

                    }
                    _postRepository.Update(post);
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

        [HttpDelete("posts/Delete/{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                var post = _postRepository.GetAllData().FirstOrDefault(x => x.Id == id);
                if (post != null)
                {
                    var rs = new ResponseModel<int>()
                    {
                        Message = "Bài viết đã được xử lý",
                        Success = false
                    };
                    if (post.IsLocked)
                    {
                        _postRepository.Delete(post);
                        rs.Message = string.Format(MessageConstants.Success, "Xóa bài viết");
                        rs.Success = true;
                    }
                    return Json(rs);
                }
                var notExist = new ResponseModel<int>() { Message = string.Format(MessageConstants.NotExists, "Bài viết"), Success = false };
                return Json(notExist);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                var error = new ResponseModel<int>() { Message = string.Format(MessageConstants.Error, ""), Success = false };
                return Json(error);
            }

        }

        [HttpGet("posts/Approve/{id}/{isApprove}")]
        public IActionResult Approve(Guid id, bool isApprove)
        {
            try
            {
                var post = _postRepository.GetAllData().FirstOrDefault(x => x.Id == id);

                if (post != null)
                {
                    var rs = new ResponseModel<int>();

                    post.IsApproved = isApprove;
                    _postRepository.Update(post);
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

        [HttpGet("posts/ChangeState/{id}/{state}")]
        public IActionResult ChangeState(Guid id, bool state)
        {
            try
            {
                var post = _postRepository.GetAllData().FirstOrDefault(x => x.Id == id);

                if (post != null)
                {
                    var rs = new ResponseModel<int>();

                    post.IsLocked = state;
                    _postRepository.Update(post);
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
            var existed = _postRepository.GetAllData().Where(x => x.Slug.Contains(newSlug)).ToList();
            if (existed.Any())
            {
                newSlug = $"{newSlug}_{(existed.Count + 1)}";
            }
            return newSlug;
        }
    }
}