using System;

namespace Model.Permissions
{
	public class UserViewModel
	{
		public string Id { get; set; }

		public string UserName { get; set; }

		public string Email { get; set; }

		public RoleViewModel[] Roles { get; set; }
	}
	public class UserRegisterModel
	{
		public string Id { get; set; }
		public string HISCode { get; set; }
		public string UserName { get; set; }
		public string FullName { get; set; }

		public string Email { get; set; }
		public string PhoneNumber { get; set; }
		public string Sex { get; set; }
		public string Birthday { get; set; }
		public string Address { get; set; }

	}
}