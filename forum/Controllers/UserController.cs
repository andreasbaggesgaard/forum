using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using forum.Services;
using forum.Models.ViewModels;
using forum.Models;
using forum.Data;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace forum.Controllers
{
    public class UserController : Controller
    {
		private readonly ForumContext _context;
		private readonly IDBService _dbService;

		public UserController(IDBService dbService, ForumContext context)
		{
			_dbService = dbService;
			_context = context;
		}
      
        public IActionResult Index()
        {
            return View();
        }

		[HttpPost]
		public IActionResult CreateUser(UsersViewModel model)
		{

            /* var newUser = new User()
            {
                Username = model.Username,
                Password = model.Password
            }; 

            _dbService.AddUser(newUser);

            TempData["userMessage"] = "User created!";*/


			return RedirectToAction("Index");
		}
    }
}
