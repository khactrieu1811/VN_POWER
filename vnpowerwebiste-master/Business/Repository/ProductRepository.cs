using Business.IRepostitory;
using Entities.DAL;
using Entities.Entities;
using Microsoft.Extensions.Caching.Memory;
using Model;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Entities.Helpers;

namespace Business.Repository
{

    public class ProductRepository: Repository<Product>,IProductRepository
    {
        public ProductRepository(VNPowerContext context) : base(context)
        {
           
        }
		public async Task<List<ProductModel>> GetAllHotProduct()
		{
			var items = await (from r in context.Products
							  where r.IsApproved==true && r.IsHotPost==true
							   select new ProductModel()
							   {
								   Id = r.Id,
								   Name = r.Name,
								   Price=r.Price,
								   DisplayOrder=r.DisplayOrder,
								   Description=r.Description,
								   Detail=r.Detail,
								   Image=r.Image
							   })
                               .ToListAsync();

			return items;
		}
		public async Task<PaginatedList<Product>> GetProductById(string slug, int? page, int pageSize)
		{
			var category = context.CategoryProducts.FirstOrDefault(x => x.Slug == slug);
			var rs = context.Products.Include(x => x.CategoryProduct)
				.Where(x => x.IsApproved && x.CategoryId == category.Id).AsQueryable()
				.OrderByDescending(x => x.DisplayOrder).AsNoTracking();
			return await PaginatedList<Product>.CreateAsync(rs, page ?? 1, pageSize);
		}
		public async Task<List<ProductModel>> GetProductDetail(string metaTitle)
		{
			var items = await (from r in context.Products
							   join m in context.CategoryProducts on r.CategoryId equals m.Id
							   where r.IsApproved == true && r.MetaTitle == metaTitle
							   select new ProductModel()
							   {
								   Id = r.Id,
								   Name = r.Name,
								   Price = r.Price,
								   DisplayOrder = r.DisplayOrder,
								   Description = r.Description,
								   Detail = r.Detail,
								   Image = r.Image,
								   CategoryName = m.Name
							   }).ToListAsync();

			return items;
		}
	}
}
