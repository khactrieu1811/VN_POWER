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
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
		public CategoryRepository(VNPowerContext context) : base(context)
        {
        }
		public async Task<List<CategoryModel>> GetAllCategory()
		{
			var items = await (from r in context.Categories
							   select new CategoryModel()
							   {
								   Id = r.Id,
								   Name = r.Name,
								   Slug = r.Slug,
								   ParentId=r.ParentId,
								   OrderDisplay=r.OrderDisplay
							   })
							   .ToListAsync();

			return items;
		}
	}
}
