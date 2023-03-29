using Business.IRepostitory;
using Common;
using Entities.DAL;
using Entities.Entities;
using Entities.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Business.Repository
{
    public class PostRepository : Repository<Post>, IPostRepository
    {
        private IMemoryCache _cache;
        public PostRepository(VNPowerContext context, IMemoryCache cache) : base(context)
        {
            _cache = cache;
        }

        public List<PostResponse> GetPostsByCache(string language, string urlServerImage, int take = 3)
        {
            bool isEnglish = language.ToUpper() == "EN";
            string keyCache = $"GetPostsByCache_{language}";
            // Look for cache key.
            if (!_cache.TryGetValue(keyCache, out List<PostResponse> cacheEntry))
            {
                var category = context.Categories.FirstOrDefault(x => x.Name == PostConstant.Blog);
                // Key not in cache, so get data.
                cacheEntry = context.Posts.Include(c => c.Category).Where(x => x.IsEnglish == isEnglish
                && x.IsApproved && x.CategoryId == category.Id).OrderByDescending(x => x.CreatedDate).Take(take)
                    .Select(p => new PostResponse(p, urlServerImage)).ToList();

                // Set cache options.
                var cacheEntryOptions = new MemoryCacheEntryOptions()
                    // Keep in cache for this time, reset time if accessed.
                    .SetSlidingExpiration(TimeSpan.FromSeconds(1));

                // Save data in cache.
                _cache.Set(keyCache, cacheEntry, cacheEntryOptions);
            }
            return cacheEntry;
        }

        public List<PostResponse> GetHotPostsByCache(string language, string urlServerImage, int take)
        {
            bool isEnglish = language.ToUpper() == "EN";
            string keyCache = $"HotPosts_{language}";
            // Look for cache key.
            if (!_cache.TryGetValue(keyCache, out List<PostResponse> cacheEntry))
            {
                // Key not in cache, so get data.
                cacheEntry = context.Posts.Include(c => c.Category)
                    .Where(x => x.IsEnglish == isEnglish
                && x.IsApproved && x.IsHotPost).OrderByDescending(x => x.CreatedDate)
                .Take(take).Select(p => new PostResponse(p, urlServerImage)).ToList();

                var scholarship = context.Scholarships.Where(x => x.IsEnglish == isEnglish
                && x.IsApproved && x.IsHotPost).OrderByDescending(x => x.CreatedDate)
                .Take(take).Select(p => new PostResponse(p, urlServerImage)).ToList();
                cacheEntry.AddRange(scholarship);

                // Set cache options.
                var cacheEntryOptions = new MemoryCacheEntryOptions()
                    // Keep in cache for this time, reset time if accessed.
                    .SetSlidingExpiration(TimeSpan.FromSeconds(1));

                // Save data in cache.
                _cache.Set(keyCache, cacheEntry, cacheEntryOptions);
            }
            return cacheEntry;
        }

        public List<PostResponse> GetCollaborativeProgramsByCache(string language, string urlServerImage, int take)
        {
            bool isEnglish = language.ToUpper() == "EN";
            string keyCache = $"CollaborativePrograms_{language}";
            // Look for cache key.
            if (!_cache.TryGetValue(keyCache, out List<PostResponse> cacheEntry))
            {
                var category = context.Categories.FirstOrDefault(x => x.Name == "CollaborativeProgram");
                // Key not in cache, so get data.
                cacheEntry = context.Posts.Include(c => c.Category).Include(x => x.ApplicationUser).Where(x => x.IsEnglish == isEnglish
                  && x.IsApproved && x.CategoryId == category.Id).OrderByDescending(x => x.CreatedDate).Take(take).Select(p => new PostResponse(p, urlServerImage)).ToList();

                // Set cache options.
                var cacheEntryOptions = new MemoryCacheEntryOptions()
                    // Keep in cache for this time, reset time if accessed.
                    .SetSlidingExpiration(TimeSpan.FromSeconds(1));

                // Save data in cache.
                _cache.Set(keyCache, cacheEntry, cacheEntryOptions);
            }
            return cacheEntry;
        }

        public async Task<PaginatedList<Post>> GetPosts(string language, string urlServerImage, string type, int? page, int pageSize)
        {
            bool isEnglish = language.ToUpper() == "EN";
            var category = context.Categories.FirstOrDefault(x => x.Name == type);
            var rs = context.Posts.Include(x=>x.Category).Include(x=>x.ApplicationUser)
                .Where(x => x.IsApproved &&
                    x.IsEnglish == isEnglish && x.CategoryId == category.Id).AsQueryable()
                .OrderByDescending(x => x.CreatedDate).AsNoTracking();
     
            return await PaginatedList<Post>.CreateAsync(rs, page ?? 1, pageSize);
        }
        public async Task<PaginatedList<Post>> GetPostById(string slug, int? page, int pageSize)
        {
            var category = context.Categories.FirstOrDefault(x => x.Slug == slug);
            var rs = context.Posts.Include(x => x.Category)
                .Where(x => x.IsApproved && x.CategoryId == category.Id).AsQueryable()
                .OrderByDescending(x => x.DisplayOrder).AsNoTracking();
            return await PaginatedList<Post>.CreateAsync(rs, page ?? 1, pageSize);
        }
        public async Task<List<PostModel>> GetPostDetail(string slug)
        {
            var items = await (from r in context.Posts
                               where r.IsApproved == true && r.Slug == slug
                               select new PostModel()
                               {
                                   Id = r.Id,
                                   Name = r.Name,
                                   PostContent=r.PostContent,
                                   DisplayOrder = r.DisplayOrder,
                                   Description = r.Description,
                                   Image = r.Image,
                               }).ToListAsync();

            return items;
        }
    }
}
