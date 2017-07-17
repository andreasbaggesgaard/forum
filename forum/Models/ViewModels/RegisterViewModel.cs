﻿using System;
using forum.Models;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using System.Linq;
using System.ComponentModel.DataAnnotations;

namespace forum.Models.ViewModels
{
    public class RegisterViewModel
    {
		/*[Required]
		[EmailAddress]
		[Display(Name = "Email")]
		public string Email { get; set; }*/

		[Required]
		[Display(Name = "Username")]
		public string Username { get; set; }

		[Required]
		[DataType(DataType.Password)]
		[Display(Name = "Password")]
		public string Password { get; set; }

		[DataType(DataType.Password)]
		[Display(Name = "Confirm password")]
		[Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
		public string ConfirmPassword { get; set; }
        public IFormFile Picture { get; set; }

    }
}