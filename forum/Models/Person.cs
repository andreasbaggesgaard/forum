using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace forum.Models
{
	public class Person : IdentityUser
	{
        public string Picture { get; set; }
        public string Joined { get; set; }
		public ICollection<Thread> Thread { get; set; }
		public ICollection<Post> Post { get; set; }

		/*public int ID { get; set; }
        public DateTime Created { get; }
		[Required]
		[Display(Name = "Username")]
		public string Username { get; set; }
		[Required]
		[Display(Name = "Password")]
		public string Password { get; set; }
        public string Picture { get; set; }

		public ICollection<Thread> Thread { get; set; }
		public ICollection<Post> Post { get; set; }*/

		/*[Required]
		[StringLength(50, ErrorMessage = "First name cannot be longer than 50 characters.")]
		[Column("FirstName")]
		[Display(Name = "First Name")]
		public string FirstName { get; set; }
		[Required]
		[StringLength(50)]
		[Display(Name = "Last Name")]
		public string LastName { get; set; }

		[Display(Name = "Full Name")]
		public string FullName
		{
			get
			{
				return LastName + ", " + FirstName;
			}
		}*/


	}
}
