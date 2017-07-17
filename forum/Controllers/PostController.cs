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
using Microsoft.AspNetCore.Identity;

namespace forum.Controllers
{
    public class PostController : Controller
    {
        private readonly ForumContext _context;
        private readonly IDBService _dbService;
        private readonly UserManager<Person> _userManager;

        public PostController(UserManager<Person> userManager, IDBService dbService, ForumContext context)
        {
            _userManager = userManager;
            _dbService = dbService;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        private Task<Person> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);
            
		[HttpPost]
        public async Task<IActionResult> AddPost(ThreadsViewModel model)
        {
            var user = await GetCurrentUserAsync();
            var userID = user?.Id;

            if (ModelState.IsValid){
                
				var newPost = new Post()
				{
                    PersonID = userID,
					ThreadID = model.Thread.ID,
					Text = model.Post.Text,
                    Created = DateTime.Now.ToString()
				};

				_dbService.AddPost(newPost);

				return RedirectToAction("GetThread", "Thread", new { id = model.Thread.ID });
            }
            return RedirectToAction("GetThread", "Thread", new { id = model.Thread.ID });
		}

        [HttpPost]
		public IActionResult RemovePost(ThreadsViewModel model)
		{

            _dbService.RemovePost(model.Post.ID);

            return RedirectToAction("GetThread", "Thread", new { id = model.Thread.ID });
        }
    }
}
