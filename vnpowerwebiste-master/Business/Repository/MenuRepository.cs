using Business.IRepostitory;
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
    public class MenuRepository : Repository<NavigationMenu>, IMenuRepository
    {
     
        private IMemoryCache _cache;
        private readonly VNPowerContext _context;
        public MenuRepository(VNPowerContext context, IMemoryCache cache) : base(context)
        {
            _cache = cache;
            _context = context;
        }

        public List<MenuResponse> GetMenusByCache(string language = "EN")
        {
            bool isEnglish = language.ToUpper() == "EN";
            string keyCache = $"Menus_{language}";
            // Look for cache key.
            if (!_cache.TryGetValue(keyCache, out List<MenuResponse> cacheEntry))
            {
                // Key not in cache, so get data.
                var list = _context.NavigationMenu.Where(x => !x.IsAdmin && x.Visible).ToList();
                cacheEntry = new List<MenuResponse>();
                foreach (var menu in list.Where(x=>x.ParentMenuId == null))
                {
                    var item = new MenuResponse(menu, isEnglish);
                    item.Children = list.Where(x => x.ParentMenuId == menu.Id).Select(x => new MenuResponse(x, isEnglish)).ToList();
                    cacheEntry.Add(item);
                }
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
