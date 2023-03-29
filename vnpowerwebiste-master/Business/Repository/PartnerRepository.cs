using Business.IRepostitory;
using Common;
using Entities.DAL;
using Entities.Entities;
using Microsoft.Extensions.Caching.Memory;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Business.Repository
{
    public class PartnerRepository : Repository<Partner>, IPartnerRepository
    {
        private IMemoryCache _cache;
        private readonly VNPowerContext _context;
        public PartnerRepository(VNPowerContext context, IMemoryCache cache) : base(context)
        {
            _cache = cache;
            _context = context;
        }

        public List<PartnerResponse> GetPartnersByCache(string language = "EN", string urlServerImage = "")
        {
            bool isEnglish = language.ToUpper() == "EN";
            string keyCache = $"Partner_{language}";
            // Look for cache key.
            if (!_cache.TryGetValue(keyCache, out List<PartnerResponse> cacheEntry))
            {
                // Key not in cache, so get data.
                cacheEntry = _context.Partners.Where(x => x.IsEnglish == isEnglish && x.IsApproved)
                    .Select(p => new PartnerResponse(p, urlServerImage)).ToList();

                // Set cache options.
                var cacheEntryOptions = new MemoryCacheEntryOptions()
                    // Keep in cache for this time, reset time if accessed.
                    .SetSlidingExpiration(TimeSpan.FromSeconds(10));

                // Save data in cache.
                _cache.Set(keyCache, cacheEntry, cacheEntryOptions);
            }
            return cacheEntry;
        }
    }
}
