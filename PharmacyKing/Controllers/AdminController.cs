using Core.Database;
using Core.Models;
using Core.Viewmodels;
using Logic.Helper;
using Logic.IHelper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace PharmacyKing.Controllers
{
    public class AdminController : Controller
    {
		private readonly ApplicationDb _context;
		private readonly IUserHelper _userHelper;
		private readonly SignInManager<ApplicationUser> _signInManager;
		private readonly IAdminHelper _adminHelper;

		public AdminController(ApplicationDb context, IUserHelper userHelper, IAdminHelper adminHelper)
        {
            _context = context;
			_userHelper = userHelper;
			_adminHelper = adminHelper;
		}
		[HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AddRoles()
		{
			var roles = _context.Roles.ToList();
			return View(roles);
		}

        [HttpPost]
        public async Task<IActionResult> AddRole(RoleViewModel roleViewModel)
		{
			try
			{
				try
				{
					if (roleViewModel != null)
					{
						var saveRoles = await _adminHelper.CreateRole(roleViewModel);
						if (saveRoles != null)
						{
							// Role created successfully
							return RedirectToAction("AddRoles", "Admin");
						}
						return View("Error", saveRoles);
					}
					return View(roleViewModel);
				}
				catch (Exception)
				{

					throw;
				}
			}
			catch (Exception)
			{

				throw;
			}
		}

        [HttpGet]
        public JsonResult EditRole(string edeitRoleId)
        {
			if (edeitRoleId != null)
			{
				var role = _context.Roles.Find(edeitRoleId);

				if (role != null)
				{
					return Json(role);
				}
			}
			return Json(null);

		}

        [HttpPost]
		public async Task<JsonResult> AddSaveRole(string saveEditedRole) 
		{
			try
			{
				if (saveEditedRole != null)
				{
					var rolesDetails = JsonConvert.DeserializeObject<RoleViewModel>(saveEditedRole);
					if (rolesDetails != null)
					{
						var EditedRoleToSave = _adminHelper.EditRoleName(rolesDetails, rolesDetails.Id);
						if (EditedRoleToSave != null)
						{
							return Json(new { isError = false, msg = "User Role edited successfully." });
						}
						return Json(new { isError = true, msg = "Unable to edit User Role" });
					}
					
				}
				return Json(new { isError = true, msg = "Something went wrong." });
			}
			catch (Exception)
			{

				throw;
			}
		}
    }
}
