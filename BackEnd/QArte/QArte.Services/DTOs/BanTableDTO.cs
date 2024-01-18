using System;
namespace QArte.Services.DTOs
{
	public class BanTableDTO
	{
		public int ID { get; set; }
		public int BanID { get; set; }

        public List<UserDTO> Users;
    }
}

