using Business.IRepostitory;
using Entities.DAL;
using Entities.Entities;
using Model.Permissions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Business.Repository
{
	public class DataAccessService : IDataAccessService
	{
		private readonly VNPowerContext _context;

		public DataAccessService(VNPowerContext context)
		{
			_context = context;
		}

		public async Task<List<NavigationMenuViewModel>> GetMenuItemsAsync(ClaimsPrincipal principal)
		{
			var isAuthenticated = principal.Identity.IsAuthenticated;
			if (!isAuthenticated)
				return new List<NavigationMenuViewModel>();

			var roleIds = await GetUserRoleIds(principal);
			var data = await (from menu in _context.RoleMenuPermission
							  where roleIds.Contains(menu.RoleId)
							  select menu)
							  .Select(m => new NavigationMenuViewModel()
							  {
								  Id = m.NavigationMenu.Id,
								  Name = m.NavigationMenu.Name,
								  Area = m.NavigationMenu.Area,
								  ActionName = m.NavigationMenu.ActionName,
								  ControllerName = m.NavigationMenu.ControllerName,
								  IsExternal = m.NavigationMenu.IsExternal,
								  ExternalUrl = m.NavigationMenu.ExternalUrl,
								  DisplayOrder = m.NavigationMenu.DisplayOrder,
								  ParentMenuId = m.NavigationMenu.ParentMenuId,
								  Visible = m.NavigationMenu.Visible,
								  IsMenu = m.NavigationMenu.IsMenu,
							  }).Distinct().ToListAsync();

			return data;
		}

		public async Task<bool> GetMenuItemsAsync(ClaimsPrincipal ctx, string ctrl, string act)
		{
			var result = false;
			var roleIds = await GetUserRoleIds(ctx);
			var data = await (from menu in _context.RoleMenuPermission
							  where roleIds.Contains(menu.RoleId)
							  select menu)
							  .Select(m => m.NavigationMenu).Distinct().ToListAsync();

			foreach (var item in data)
			{
				result = (item.ControllerName == ctrl && item.ActionName == act);
				if (result)
					break;
			}

			return result;
		}

		public async Task<List<NavigationMenuViewModel>> GetPermissionsByRoleIdAsync(string name)
		{
			var items = await (from r in _context.Roles
							   join rm in _context.RoleMenuPermission on r.Id equals rm.RoleId
							   join m in _context.NavigationMenu on rm.NavigationMenuId equals m.Id
								where r.Name == name && m.IsAdmin
							   select new NavigationMenuViewModel()
							   {
								   Id = m.Id,
								   Name = m.Name,
								   Area = m.Area,
								   ActionName = m.ActionName,
								   ControllerName = m.ControllerName,
								   IsExternal = m.IsExternal,
								   ExternalUrl = m.ExternalUrl,
								   DisplayOrder = m.DisplayOrder,
								   ParentMenuId = m.ParentMenuId,
								   Visible = m.Visible,
								   IsMenu = m.IsMenu,
								   Permitted = r.Name == name,
								   RoleId = r.Id,
								   RoleName = r.Name,
								   Image = m.Image
							   })
							   .AsNoTracking()
							   .ToListAsync();

			return items;
		}


		public async Task<bool> SetPermissionsByRoleIdAsync(string id, IEnumerable<Guid> permissionIds)
		{
			var existing = await _context.RoleMenuPermission.Where(x => x.RoleId == id).ToListAsync();
			_context.RemoveRange(existing);

			foreach (var item in permissionIds)
			{
				await _context.RoleMenuPermission.AddAsync(new RoleMenuPermission()
				{
					RoleId = id,
					NavigationMenuId = item,
				});
			}

			var result = await _context.SaveChangesAsync();

			return result > 0;
		}

		private async Task<List<string>> GetUserRoleIds(ClaimsPrincipal ctx)
		{
			var userId = GetUserId(ctx);
			var data = await (from role in _context.UserRoles
							  where role.UserId == userId
							  select role.RoleId).ToListAsync();

			return data;
		}

		private string GetUserId(ClaimsPrincipal user)
		{
			return ((ClaimsIdentity)user.Identity).FindFirst(ClaimTypes.Name)?.Value;
		}
		public async Task<List<SettingModel>> GetAllSetting()
		{
			var items = await (from r in _context.Settings
							   select new SettingModel
							   {
								   Logo = r.Logo,
								   CompanyInfo=r.CompanyInfo

							   })
							   .ToListAsync();

			return items;
		}
	}
}
