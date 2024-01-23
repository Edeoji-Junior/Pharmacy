using Microsoft.AspNetCore.Mvc;

namespace PharmacyKing.Controllers
{
	public class UserController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}

	}
}
