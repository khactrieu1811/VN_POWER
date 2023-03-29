using Business.IRepository;
using Entities.Entities;
using Model;
using System.Collections.Generic;

namespace Business.IRepostitory
{
    public interface IPartnerRepository : IRepository<Partner>
    {
        List<PartnerResponse> GetPartnersByCache(string language, string absUrl);

    }
}
