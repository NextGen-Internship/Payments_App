using System;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace QArte.Services.DTOs
{
	public class RegisterDTO
	{
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Username { get; set; }
        public string? Address { get; set; }
        public string? Country { get; set; }
        public string? City { get; set; }
        public string? postalCode { get; set; }
        public string? IBAN { get; set; }


        [EmailAddress]
        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; } = string.Empty;
        
        //[Required(ErrorMessage = "Username is required")]
        //public string UserName { get; set; } = string.Empty;

        //[Required(ErrorMessage = "Address is required")]
        //public string Address { get; set; } = string.Empty;

        //[Required(ErrorMessage = "Country is required")]
        //public string Country { get; set; } = string.Empty;

        //[Required(ErrorMessage = "City is required")]
        //public string City { get; set; } = string.Empty;
    }
}

