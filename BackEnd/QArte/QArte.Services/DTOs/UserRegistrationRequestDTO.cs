using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace QArte.Services.DTOs
{
	public class UserRegistrationRequestDTO
	{

		[Required]
		public string Name { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
	}
}
