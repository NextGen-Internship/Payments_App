﻿using System;
using System.ComponentModel.DataAnnotations;

namespace QArte.Services.DTOs
{
	public class RequestAuthDTO
	{
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}

