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
	public class ThreadController : Controller
	{
		private readonly ForumContext _context;
		private readonly IDBService _dbService;
		private readonly UserManager<Person> _userManager;
        private readonly IHostingEnvironment _environment;

		public ThreadController(UserManager<Person> userManager, IDBService dbService, ForumContext context, IHostingEnvironment environment)
		{
			_userManager = userManager;
			_dbService = dbService;
			_context = context;
            _environment = environment;
		}

		private Task<Person> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);

		public IActionResult Index()
		{
			var model = new ThreadsViewModel()
			{
				Threads = _dbService.GetAllThreads()
			};

			return View(model);
		}

		[HttpGet]
		public IActionResult GetThread(int id)
		{

			var model = new ThreadsViewModel()
			{
				Thread = _dbService.GetThread(id),
				Posts = _context.Posts.Where(i => i.ThreadID == id).Include(c => c.Person).AsNoTracking(),
			};

			return View(model);
		}

		public IActionResult AddThread()
		{

			return View();
		}

		[HttpPost]
		public async Task<IActionResult> AddThread(ThreadsViewModel model)
		{
			var user = await GetCurrentUserAsync();
			var userID = user?.Id;

			if (ModelState.IsValid)
			{

				var newThread = new Thread()
				{
					PersonID = userID,
					Subject = model.Thread.Subject,
					Text = model.Thread.Text,
                    Picture = UploadImage(model.Picture),
					Created = DateTime.Now.ToString()
				};

				_dbService.AddThread(newThread);

				return RedirectToAction("Index", "Home");
			}
			return View();
		}

		public string UploadImage(IFormFile Picture)
		{
			if (Picture == null)
			{
				return "http://placehold.it/500x500";
			}

			var uploadFolder = "uploads";
			var uploads = Path.Combine(_environment.WebRootPath, uploadFolder);

			using (var fileStream = new FileStream(Path.Combine(uploads, Picture.FileName), FileMode.Create))
			{
				Picture.CopyTo(fileStream);
			}

			return string.Concat(uploadFolder, "/", Picture.FileName);
		}

	}
}
