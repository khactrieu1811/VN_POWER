using Model;
using Model.Permissions;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Business.IRepostitory
{
	public interface IDataAccessService
	{
		Task<bool> GetMenuItemsAsync(ClaimsPrincipal ctx, string ctrl, string act);
		Task<List<NavigationMenuViewModel>> GetMenuItemsAsync(ClaimsPrincipal principal);
		Task<List<NavigationMenuViewModel>> GetPermissionsByRoleIdAsync(string id);
		Task<bool> SetPermissionsByRoleIdAsync(string id, IEnumerable<Guid> permissionIds);
		Task<List<SettingModel>> GetAllSetting();
	}
}
