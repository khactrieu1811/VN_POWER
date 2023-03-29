using Business.IRepostitory;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Website.Helpers;

namespace Website.Api
{
    [Route("api")]
    [ApiController]
    public class HomesController : ControllerBaseApi
    {
        private readonly IPartnerRepository _partnerRepository;
        private readonly IServiceRepository _serviceRepository;
        private readonly IMenuRepository _menuRepository;
        private readonly IPostRepository _postRepository;
        private readonly IBannerRepository _bannerRepository;
        private readonly ILogger<HomesController> _logger;
        public HomesController(ILogger<HomesController> logger, IHttpContextAccessor httpContextAccessor,
            IPartnerRepository partnerRepository,
            IServiceRepository serviceRepository,
            IMenuRepository menuRepository,
            IBannerRepository bannerRepository,
            IPostRepository postRepository) : base(httpContextAccessor)
        {
            _logger = logger;
            _partnerRepository = partnerRepository;
            _serviceRepository = serviceRepository;
            _postRepository = postRepository;
            _bannerRepository = bannerRepository;
            _menuRepository = menuRepository;
            _httpContextAccessor = httpContextAccessor;
        }

        [HttpGet("Partners/{language}")]
        public IActionResult GetPartners(string language)
        {
            var data = _partnerRepository.GetPartnersByCache(language, GetUrlServerImage());
            return Ok(data);
        }


        [HttpGet("Banners/{language}")]
        public IActionResult GetBanners(string language)
        {

            var data = _bannerRepository.GetBannersByCache(language, GetUrlServerImage());
            return Ok(data);
        }

        [HttpGet("Services/{language}")]
        public IActionResult GetServices(string language)
        {
            var data = _serviceRepository.GetServicesByCache(language, GetUrlServerImage());
            return Ok(data);
        }

        [HttpGet("Menus/{language}")]
        public IActionResult GetMenus(string language)
        {

            var data = _menuRepository.GetMenusByCache(language);
            return Ok(data);
        }

        [HttpGet("Blogs/TopBlogs/{language}")]
        public IActionResult TopBlogs(string language)
        {

            var data = _postRepository.GetPostsByCache(language, GetUrlServerImage(), 3);
            return Ok(data);
        }

        [HttpGet("HotTopics/{language}")]
        public IActionResult HotTopics(string language)
        {
            var data = _postRepository.GetHotPostsByCache(language, GetUrlServerImage(), 3).OrderBy(x=>x.DisplayOrder);
            return Ok(data);
        }

        [HttpGet("CollaborativePrograms/{language}")]
        public IActionResult CollaborativePrograms(string language)
        {
            var data = _postRepository.GetCollaborativeProgramsByCache(language, GetUrlServerImage(), 3);
            return Ok(data);
        }

    }
}
