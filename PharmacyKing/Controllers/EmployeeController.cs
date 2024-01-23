using Core.Database;
using Core.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace PharmacyKing.Controllers
{
    public class EmployeeController : Controller
    {
		private readonly ApplicationDb _context;
		private readonly UserManager<ApplicationUser> _userManager;
		private readonly SignInManager<ApplicationUser> _signInManager;

		public EmployeeController(ApplicationDb context, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
			_context = context;
			_userManager = userManager;
			_signInManager = signInManager;

		}
        public IActionResult Index()
        {
            return View();
        }
		[HttpGet]
		public IActionResult AllEmployee()
		{
			return View();
		}
	}
}
