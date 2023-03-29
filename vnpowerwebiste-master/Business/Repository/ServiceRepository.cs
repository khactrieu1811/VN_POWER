using Business.IRepostitory;
using Common;
using Entities.DAL;
using Entities.Entities;
using Microsoft.Extensions.Caching.Memory;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Repository
{
    public class ServiceRepository : Repository<Service>, IServiceRepository
    {
        private IMemoryCache _cache;
        private readonly VNPowerContext _context;
        public ServiceRepository(VNPowerContext context, IMemoryCache cache) : base(context)
        {
            _cache = cache;
            _context = context;
        }
        public List<ServiceResponse> GetServicesByCache(string language = "EN", string urlServerImage = "")
        {
            bool isEnglish = language.ToUpper() == "EN";
            string keyCache = $"Services_{language}";
            // Look for cache key.
            if (!_cache.TryGetValue(keyCache, out List<ServiceResponse> cacheEntry))
            {
                // Key not in cache, so get data.
                cacheEntry = _context.Services.Where(x => x.IsEnglish == isEnglish
                && x.IsApproved).Select(p => new ServiceResponse(p, urlServerImage)).ToList();

                // Set cache options.
                var cacheEntryOptions = new MemoryCacheEntryOptions()
                    // Keep in cache for this time, reset time if accessed.
                    .SetSlidingExpiration(TimeSpan.FromSeconds(1));

                // Save data in cache.
                _cache.Set(keyCache, cacheEntry, cacheEntryOptions);
            }
            return cacheEntry;
        }
    }
}
