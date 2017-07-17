using System;
using forum.Models;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using System.Linq;
using System.ComponentModel.DataAnnotations;

namespace forum.Models.ViewModels
{
    public class UsersViewModel
    {
		[MinLength(5)]
		[MaxLength(1024)]
        public string Username { get; set; }
		[MinLength(5)]
		[MaxLength(1024)]
        public string Password { get; set; }

        public IEnumerable<Person> Users { get; set; }

        public Person User { get; set; }

    }
}
