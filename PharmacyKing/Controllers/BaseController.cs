using Microsoft.AspNetCore.Mvc;
using PharmacyKing.Models;

namespace PharmacyKing.Controllers
{
	public class BaseController : Controller
	{
		protected void SetMessage(string message, Messages.Category messageType)
		{
			Messages msg = new Messages(message, (int)messageType);
			TempData["Message"] = msg;
		}
	}
}
