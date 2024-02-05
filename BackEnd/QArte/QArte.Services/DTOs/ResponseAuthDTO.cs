using System;
using System.ComponentModel.DataAnnotations;

namespace QArte.Services.DTOs
{
	public class ResponseAuthDTO
	{
		public string Email { get; set; }

		public bool? isBanned { get; set; }

		public string Role { get; set; }

		public string Token { get; set; }

		public string Message { get; set; }
	}
}

