using System;
namespace QArte.Services.DTOs
{
	public class RoleDTO
	{
		public int ID { get; set; }
		public string ERole { get; set; }

		public List<string> Users;
	}
}

