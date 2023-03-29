namespace Model.Permissions
{
	public class RoleViewModel
	{
		public string Id { get; set; }

		public string Name { get; set; }

		public bool Selected { get; set; }
	}

	public class RoleModel
	{
		public string Id { get; set; }

		public string Name { get; set; }
		public string Description { get; set; }

		public bool Selected { get; set; }
	}
}