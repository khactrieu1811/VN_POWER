using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities.Entities
{
	[Table(name: "AspNetRoleMenuPermission")]
	public class RoleMenuPermission
	{
		public string RoleId { get; set; }
		public Guid NavigationMenuId { get; set; }
		public NavigationMenu NavigationMenu { get; set; }
		
	}
}
