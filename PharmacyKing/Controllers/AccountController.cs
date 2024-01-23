using Core.Database;
using Core.Enums;
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
    public class AccountController : Controller
    {
        private readonly ApplicationDb _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
		private readonly IDropDownHelper _dropDownHelper;
		private readonly IUserHelper _userHelper;

		public AccountController(ApplicationDb context, UserManager<ApplicationUser> userManager, 
            SignInManager<ApplicationUser> signInManager, IUserHelper userHelper,
            IDropDownHelper dropDownHelper)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
			_dropDownHelper = dropDownHelper;
            _userHelper = userHelper;
		}
		public IActionResult Index()
		{
			return View();
		}
		
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        public async Task<IActionResult> AddUsers(string applicationUserViewModel)
        {
            try
            {
                if (applicationUserViewModel != null)
                {
                    var userDetails = JsonConvert.DeserializeObject<ApplicationUserViewModel>(applicationUserViewModel);
                    if (userDetails != null)
                    {
                        if (userDetails.Password != userDetails.ConfirmPassword)
                        {
							return Json(new { isError = true, msg = "Password and Confirm Password does not match" });
						}
                        var checkIfUserNameExist = _userHelper.FindByUserName(User.Identity.Name);
                        if (checkIfUserNameExist != null)
                        {
							return Json(new { isError = true, msg = "User name already exist, Please choose anther Username!" });
						}
                        var checkIfEmailExist = _userHelper.FindUserByEmail(userDetails.Email);
                        if (checkIfEmailExist != null)
                        {
							return Json(new { isError = true, msg = "Email already exist, Please choose anther Email!" });
						}
                        else
                        {
							var saveUser = await _userHelper.CreateUser(userDetails);
							if (saveUser != null)
							{
								var isInRole = await _userManager.AddToRoleAsync(saveUser, "Admin");
								if (isInRole != null)
								{
									return Json(new { isError = false, msg = "Registration successful. Login to your email to verify account.",  });
								}
                                else
                                {
									return Json(new { isError = true, msg = "Incorrect username or Password!" });
								}
							}
						}

                        
                    }
					return Json(new { isError = true, msg = "invalid registration" });
				}
				return Json(new { isError = true, msg = "Please fill the form correctly" });
			}
            catch (Exception)
            {

                throw;
            }
        }
        [HttpGet]
		public IActionResult Login()
		{
			return View();
		}
        [HttpPost]
        public async Task<IActionResult> Login(string loginViewModel)
        {
            try
            {
                if (loginViewModel != null)
                {
                    var loginUserDetails = JsonConvert.DeserializeObject<ApplicationUserViewModel>(loginViewModel);
                    if (loginUserDetails != null) 
                    {
                        var ifEmailIsCorrect = _userHelper.FindUserByEmail(loginUserDetails.Email);
                        if (ifEmailIsCorrect == null)
                        {
							return Json(new { isError = true, msg = "Invalid user Email" });
						}
						var isloginUser =await _signInManager.PasswordSignInAsync(ifEmailIsCorrect, loginUserDetails.Password, true, true);

						if (isloginUser != null)
						{
							var isInRole = await _userManager.GetRolesAsync(ifEmailIsCorrect).ConfigureAwait(false);
							if (isInRole.Count() > 0)
							{
								if (isInRole.FirstOrDefault().Contains("Admin"))
								{
									return Json(new { isError = false, msg = "Login was successful"});
                                    //return RedirectToAction("Index", "Admin");
								}
								else
								{
									return Json(new { isError = false, url = "/User/Index" });
								}
							}
							return Json(new { isError = true, msg = "invalid user Role", });
						}
					}
                }
                return Json(new { isError = true, msg = "incorrect username or password", });
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult ForgotPassword()
        {
            return View();
        }
        [HttpGet]
        public IActionResult ResetPassword()
        {
            return View();
        }
        [HttpGet]
        public IActionResult EmailVerify()
        {
            return View();
        }

        [HttpGet]
        public IActionResult UserVerification()
        {
            return View();
        }
    }
}
