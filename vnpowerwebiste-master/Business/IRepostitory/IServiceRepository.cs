using Business.IRepository;
using Entities.Entities;
using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.IRepostitory
{
    public interface IServiceRepository : IRepository<Service>
    {
        List<ServiceResponse> GetServicesByCache(string language, string urlServerImage);
    }
}
