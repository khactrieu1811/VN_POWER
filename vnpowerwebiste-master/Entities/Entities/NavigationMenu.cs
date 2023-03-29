using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities.Entities
{
	[Table(name: "AspNetNavigationMenu")]
	public class NavigationMenu
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public Guid Id { get; set; }

		public string Name { get; set; }
		public string NameEng { get; set; }

		[ForeignKey("ParentNavigationMenu")]
		public Guid? ParentMenuId { get; set; }

		public virtual NavigationMenu ParentNavigationMenu { get; set; }

		public string Area { get; set; }

		public string ControllerName { get; set; }

		public string ActionName { get; set; }

		public bool IsExternal { get; set; }

		public string ExternalUrl { get; set; }

		public int DisplayOrder { get; set; }

		[NotMapped]
		public bool Permitted { get; set; }

		public bool Visible { get; set; }
		public bool IsMenu { get; set; }
		public bool IsAdmin { get; set; }
		public string Image { get; set; }
	}
}
