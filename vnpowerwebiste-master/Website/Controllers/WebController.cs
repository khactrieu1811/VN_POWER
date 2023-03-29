using AutoMapper;
using Business.IRepostitory;
using Entities.Entities;
using Entities.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Model;
using System;
using System.Linq;
using System.Threading.Tasks;
using Website.Helpers;
using Website.Models;

namespace Website.Controllers
{
    public class WebController : Controller
    {
        private readonly IProductRepository _productRepository;
        private readonly IPostRepository _postRepository;
        private readonly ICategoryProductRepository _categoryProductRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        private readonly int _pageSize = 6;
        public WebController(IProductRepository productRepository,ICategoryProductRepository categoryProductRepository,
            ICategoryRepository categoryRepository,IPostRepository postRepository,
            IMapper mapper)
        {
            _categoryProductRepository = categoryProductRepository;
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
            _postRepository = postRepository;

            _mapper = mapper;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Contact()
        {
            return View();
        }
        public IActionResult Gallery()
        {
            return View();
        }
        public async Task<IActionResult> Products(int? page)
        {
            var rs = _productRepository.GetAllData().
                Where(x =>x.IsApproved==true).OrderByDescending(x => x.DisplayOrder).AsNoTracking();
            var data = await PaginatedList<Product>.CreateAsync(rs, page ?? 1, _pageSize);
            var vm = new BaseViewModel<Product>
            {
                ListItems = StatusList.ListPostStatus.ToList()
            };
            vm.Data = data;
            return View(vm);
        }
        [HttpGet("Web/Products/{Slug}")]
        public async Task<IActionResult> ProductId(int? page,int?pageSize, string slug)
        {
            pageSize ??= 6;
            var data = await _productRepository.GetProductById(slug, page, pageSize.Value);
            var vm = new BaseViewModel<Product>
            {
                ListItems = StatusList.ListPostStatus.ToList()
            };
            vm.Data = data;
            return View(vm);
        }
        public async Task<IActionResult> Posts(int? page)
        {
            var rs = _postRepository.GetAllData().
                Where(x => x.IsApproved == true).OrderByDescending(x => x.DisplayOrder).AsNoTracking();
            var data = await PaginatedList<Post>.CreateAsync(rs, page ?? 1, _pageSize);
            var vm = new BaseViewModel<Post>
            {
                ListItems = StatusList.ListPostStatus.ToList()
            };
            vm.Data = data;
            return View(vm);
        }
        [HttpGet("Web/Posts/{Slug}")]
        public async Task<IActionResult> PostId(int? page, int? pageSize, string slug)
        {
            pageSize ??= 6;
            var data = await _postRepository.GetPostById(slug, page, pageSize.Value);
            var vm = new BaseViewModel<Post>
            {
                ListItems = StatusList.ListPostStatus.ToList()
            };
            vm.Data = data;
            return View(vm);
        }
        [HttpGet("Web/Products/Chi-tiet/{MetaTitle}")]
        public async Task<IActionResult> ProductDetail(string metaTitle)
        {
            var data = await _productRepository.GetProductDetail(metaTitle);
            var vm = new BaseViewModel<ProductModel>();
            vm.List=data;
            return View(vm);
        }
        [HttpGet("Web/Posts/Chi-tiet/{Slug}")]
        public async Task<IActionResult> PostDetail(string slug)
        {
            var data = await _postRepository.GetPostDetail(slug);
            var vm = new BaseViewModel<PostModel>();
            vm.List = data;
            return View(vm);
        }
    }
}
