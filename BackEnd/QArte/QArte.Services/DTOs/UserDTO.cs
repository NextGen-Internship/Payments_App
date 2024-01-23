using System;
namespace QArte.Services.DTOs
{
	public class UserDTO
	{
		public int ID { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Username { get; set; }
		public string Password { get; set; }
		public string Email { get; set; }
		public string PictureURL { get; set; }
		public string PhoneNumber { get; set; }
		public bool isBanned { get; set; }
		public int RoleID { get; set; }
		public int? BankAccountID { get; set; }

		public List<PageDTO>? Pages { get; set; }
    }
}

