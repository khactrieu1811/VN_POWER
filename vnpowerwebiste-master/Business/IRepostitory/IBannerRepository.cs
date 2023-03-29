using Business.IRepository;
using Entities.Entities;
using Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.IRepostitory
{
    public interface IBannerRepository : IRepository<Banner>
    {
        List<BannerResponse> GetBannersByCache(string language, string urlServerImage);
        Task<List<BannerModel>> GetAllBanners();

    }
}
