using System;
using forum.Models;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using System.Linq;
using System.ComponentModel.DataAnnotations;

namespace forum.Models.ViewModels
{
    public class LoginViewModel
    {
		public string Username { get; set; }
		public string Password { get; set; }

    }
}
