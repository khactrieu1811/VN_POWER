using Business.IRepostitory;
using Common;
using Entities.DAL;
using Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Repository
{
    public class BannerRepository : Repository<Banner>, IBannerRepository
    {
        private IMemoryCache _cache;
        private readonly VNPowerContext _context;
        public BannerRepository(VNPowerContext context, IMemoryCache cache) : base(context)
        {
            _cache = cache;
            _context = context;
        }

        public List<BannerResponse> GetBannersByCache(string language = "EN", string urlServerImage = "")
        {
            bool isEnglish = language.ToUpper() == "EN";
            string keyCache = $"Banner_{language}";
            // Look for cache key.
            if (!_cache.TryGetValue(keyCache, out List<BannerResponse> cacheEntry))
            {
                // Key not in cache, so get data.
                cacheEntry = _context.Banners.Where(x => x.IsEnglish == isEnglish
                && x.Status == ApplicationStatus.Completed.GetHashCode())
                    .Select(p => new BannerResponse(p, urlServerImage)).ToList();

                // Set cache options.
                var cacheEntryOptions = new MemoryCacheEntryOptions()
                    // Keep in cache for this time, reset time if accessed.
                    .SetSlidingExpiration(TimeSpan.FromSeconds(10));

                // Save data in cache.
                _cache.Set(keyCache, cacheEntry, cacheEntryOptions);
            }
            return cacheEntry;
        }
        public async Task<List<BannerModel>> GetAllBanners()
        {
            var items = await (from r in context.Banners
                               where r.StartDate<=DateTime.Now && r.EndDate>=DateTime.Now && r.Status==2
                               select new BannerModel()
                               {
                                   Id = r.Id,
                                   Name = r.Name,
                                   ImageLink=r.ImageLink,
                                   LinkWeb=r.LinkWeb,
                                   Title=r.Title,
                               })
                               .ToListAsync();

            return items;
        }
    }
}
