using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using forum.Services;
using forum.Models.ViewModels;
using forum.Models;
using forum.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.IO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;

namespace forum.Controllers
{
    public class HomeController : Controller
    {
		private readonly IDBService _dbService;
        private readonly ForumContext _context;
		private readonly UserManager<Person> _userManager;
		private readonly SignInManager<Person> _signInManager;
        private readonly IHostingEnvironment _environment;

        public HomeController(UserManager<Person> userManager, SignInManager<Person> signInManager, ForumContext context, IDBService dbService, IHostingEnvironment environment)
		{
			_dbService = dbService;
            _context = context;
			_userManager = userManager;
			_signInManager = signInManager;
            _environment = environment;
		}

		private Task<Person> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);

        public async Task<IActionResult> Index()
        {
			var user = await GetCurrentUserAsync();

            var model = new ThreadsViewModel()
            {
                Threads = _context.Threads.Include(c => c.Person).AsNoTracking(),
                Posts = _context.Posts.Include(c => c.Person).OrderByDescending(c => c.Created).AsNoTracking(),
                People = _dbService.GetAllUsers().OrderByDescending(c => c.Joined),
                Person = user
            };

            return View(model);
        }

		public IActionResult Register()
		{

			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Register(RegisterViewModel model)
		{
            var user = new Person { UserName = model.Username, Picture = UploadImage(model.Picture), Joined = DateTime.Now.ToString() };
			IdentityResult result = await _userManager.CreateAsync(user, model.Password);
			if (result.Succeeded)
			{
                //return RedirectToAction("Index");
                TempData["path"] = UploadImage(model.Picture);
                return View();
			}
			else
			{
				return View();
			}
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

		public IActionResult Login()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Login(LoginViewModel model)
		{
            Microsoft.AspNetCore.Identity.SignInResult result = await _signInManager.PasswordSignInAsync(model.Username, model.Password, isPersistent: true, lockoutOnFailure: false);
			if (result.Succeeded)
			{
				return RedirectToAction("Index");
			}
			else
			{
				return View();
			}
		}

		[HttpPost]
		public async Task<IActionResult> LogOff()
		{
			await _signInManager.SignOutAsync();
			return RedirectToAction("Index");
		}

        public IActionResult Error()
        {
            return View();
        }
    }
}
