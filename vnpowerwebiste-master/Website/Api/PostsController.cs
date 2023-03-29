using Business.IRepostitory;
using Common;
using Entities.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Model;
using Model.APIs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Website.Api
{
    [Route("api")]
    [ApiController]
    public class PostsController : ControllerBaseApi
    {

        private readonly IPostRepository _postRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly ILogger<HomesController> _logger;
        public PostsController(ILogger<HomesController> logger,
            IHttpContextAccessor httpContextAccessor,
            IPostRepository postRepository,
            ICategoryRepository categoryRepository) : base(httpContextAccessor)
        {
            _logger = logger;
            _postRepository = postRepository;
            _categoryRepository = categoryRepository;
        }

        [HttpGet("Blogs/{language}")]
        public async Task<IActionResult> Blogs(string language, int? page, int? pageSize)
        {
            pageSize ??= 10;
            string type = PostConstant.Blog;
            var data = await _postRepository.GetPosts(language, GetUrlServerImage(), type, page, pageSize.Value);
            var rs = new PagedResult<PostResponse>()
            {
                CurrentPage = data.PageIndex,
                TotalItems = data.TotalRows,
                PageSize = pageSize.Value,
                Results = data.Select(x => new PostResponse(x, GetUrlServerImage())).ToList(),
                PageCount = data.TotalPages
            };

            return Ok(rs);
        }

        [HttpGet("Blogs/Detail/{slug}")]
        public async Task<IActionResult> BlogDetail(string slug)
        {
            var data = await _postRepository.GetAllData().Include(x => x.ApplicationUser).FirstOrDefaultAsync(x => x.Slug == slug);
            return Ok(new PostDetailResponse(data, GetUrlServerImage()));
        }

        [HttpGet("Events/{language}")]
        public async Task<IActionResult> Events(string language, int? page, int? pageSize)
        {
            pageSize ??= 10;
            string type = PostConstant.Event;
            var data = await _postRepository.GetPosts(language, GetUrlServerImage(), type, page, pageSize.Value);
            var rs = new PagedResult<EventResponse>()
            {
                CurrentPage = data.PageIndex,
                TotalItems = data.TotalRows,
                PageSize = pageSize.Value,
                Results = data.Select(x => new EventResponse(x, GetUrlServerImage())).ToList(),
                PageCount = data.TotalPages
            };
            return Ok(rs);
        }


        [HttpGet("Events/Detail/{slug}")]
        public async Task<IActionResult> EventsDetail(string slug)
        {
            var data = await _postRepository.GetAllData().Include(x => x.ApplicationUser).FirstOrDefaultAsync(x => x.Slug == slug);
            return Ok(new EventDetailResponse(data, GetUrlServerImage()));
        }

        [HttpGet("News/{language}")]
        public async Task<IActionResult> News(string language, int? page, int? pageSize)
        {
            pageSize ??= 10;
            string type = PostConstant.News;
            var data = await _postRepository.GetPosts(language, GetUrlServerImage(), type, page, pageSize.Value);
            var rs = new PagedResult<PostResponse>()
            {
                CurrentPage = data.PageIndex,
                TotalItems = data.TotalRows,
                PageSize = pageSize.Value,
                Results = data.Select(x => new PostResponse(x, GetUrlServerImage())).ToList(),
                PageCount = data.TotalPages
            };
            return Ok(rs);
        }


        [HttpGet("News/Detail/{slug}")]
        public async Task<IActionResult> NewsDetail(string slug)
        {
            var data = await _postRepository.GetAllData().Include(x => x.ApplicationUser).FirstOrDefaultAsync(x => x.Slug == slug);
            return Ok(new PostDetailResponse(data, GetUrlServerImage()));
        }

        [HttpGet("Collabs/{language}")]
        public async Task<IActionResult> Collabs(string language, int? page, int? pageSize)
        {
            pageSize ??= 10;
            string type = PostConstant.CollaborativeProgram;
            var data = await _postRepository.GetPosts(language, GetUrlServerImage(), type, page, pageSize.Value);
            var rs = new PagedResult<PostResponse>()
            {
                CurrentPage = data.PageIndex,
                TotalItems = data.TotalRows,
                PageSize = pageSize.Value,
                Results = data.Select(x => new PostResponse(x, GetUrlServerImage())).ToList(),
                PageCount = data.TotalPages
            };
            return Ok(rs);
        }

        [HttpGet("Collabs/Detail/{slug}")]
        public async Task<IActionResult> CollabDetail(string slug)
        {
            var data = await _postRepository.GetAllData().Include(x => x.ApplicationUser).FirstOrDefaultAsync(x => x.Slug == slug);
            return Ok(new PostDetailResponse(data, GetUrlServerImage()));
        }

        [HttpGet("Posts/GetPreviousAndNext/{slug}")]
        public async Task<IActionResult> GetPreviousAndNext(string slug)
        {
            var data = await _postRepository.GetAllData().FirstOrDefaultAsync(x => x.Slug == slug);
            var next = _postRepository.GetAllData().Include(i => i.Category)
                  .Where(t => t.CreatedDate > data.CreatedDate && t.CategoryId == data.CategoryId && t.IsApproved)
                  .OrderByDescending(t => t.CreatedDate)
                  .Take(1).FirstOrDefault();
            var prev = _postRepository.GetAllData().Include(i => i.Category)
                             .Where(t => t.CreatedDate < data.CreatedDate && t.CategoryId == data.CategoryId)
                             .OrderByDescending(t => t.CreatedDate)
                             .Take(1).FirstOrDefault();
            if (prev == null)
            {
                prev = data;
            }
            if (next == null)
            {
                next = data;
            }

            var rs = new PreviousAndNextPostResponse()
            {
                Previous = new PostResponse(prev, GetUrlServerImage()),
                Next = new PostResponse(next, GetUrlServerImage())

            };

            return Ok(rs);
        }

        [HttpGet("Pages/{slug}")]
        public async Task<IActionResult> PageDetail(string slug, string language)
        {
            bool isEnglish = language.ToUpper() == "EN";
            var category = _categoryRepository.GetAllData().FirstOrDefault(x => x.Slug == slug);
            if(category != null)
            {
                var data = await _postRepository.GetAllData().Include(x => x.ApplicationUser)
                    .FirstOrDefaultAsync(x =>x.CategoryId == category.Id && x.IsEnglish == isEnglish);
                if(data != null)
                {
                    return Ok(new PostDetailResponse(data, GetUrlServerImage()));
                }
               
            }
            return BadRequest();
           
        }
    }
}
