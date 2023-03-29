using Business.IRepository;
using System;
using System.Collections.Generic;
using System.Text;
using Entities.Entities;
using Model.APIs;
using Entities.Helpers;
using System.Threading.Tasks;
using Model;
using System.Linq;

namespace Business.IRepostitory
{
    public interface IProductRepository:IRepository<Product>
    {
        Task<List<ProductModel>> GetAllHotProduct();
        Task<PaginatedList<Product>> GetProductById(string slug, int? page, int pageSize);
        Task<List<ProductModel>> GetProductDetail(string metaTitle);
    }
}
