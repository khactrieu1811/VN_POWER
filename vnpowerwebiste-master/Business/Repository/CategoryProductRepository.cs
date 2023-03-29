using Business.IRepostitory;
using Entities.DAL;
using Entities.Entities;
using Model;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Business.Repository
{
    public class CategoryProductRepository : Repository<CategoryProduct>, ICategoryProductRepository
    {
        public CategoryProductRepository(VNPowerContext context) : base(context)
        {

        }
		public async Task<List<CategoryProductModel>> GetAllCategoryProduct()
		{
			var items = await (from r in context.CategoryProducts
							   select new CategoryProductModel()
							   {
								   Id = r.Id,
								   Name = r.Name,
								   Slug = r.Slug,
								   ParentId = r.ParentId,
								   OrderDisplay = r.OrderDisplay
							   })
							   .ToListAsync();

			return items;
		}

	}
}
