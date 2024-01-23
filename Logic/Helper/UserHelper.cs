using Core.Database;
using Core.Models;
using Core.Viewmodels;
using Logic.IHelper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Logic.Helper
{
	public class UserHelper : IUserHelper
	{
		private readonly ApplicationDb _context;
		private readonly UserManager<ApplicationUser> _userManager;
		public UserHelper(ApplicationDb context, UserManager<ApplicationUser> userManager)
        {
			_context = context;
			_userManager = userManager;
		}
		public async Task<ApplicationUser> FindUserByEmailAsync(string email)
        {
            return await _userManager.Users.Where(x => x.Email == email).FirstOrDefaultAsync();
        }
        public async Task<ApplicationUser> FindUserByUserNameAsync(string username)
        {
            return await _userManager.Users.Where(x => x.UserName == username).FirstOrDefaultAsync();
        } 
        public async Task<ApplicationUser> FindUserByUserIdAsync(string id)
        {
            return await _userManager.Users.Where(x => x.Id == id).FirstOrDefaultAsync();
        }
		public ApplicationUser FindByUserId(string id)
		{
			return _userManager.Users.Where(x => x.Id == id).FirstOrDefault();
		}
		public ApplicationUser FindUserByEmail(string email)
		{
			return _userManager.Users.Where(x => x.Email == email).FirstOrDefault();
		}
		public ApplicationUser FindByUserName(string username)
		{
			return _userManager.Users.Where(s => s.UserName == username)?.FirstOrDefault();
		}
		public async Task<Userverification> CreateUserTokenAsync(string email)
		{
			try
			{
				if (email != null)
				{
					var user = await _context.ApplicationUsers.Where(x => x.Email == email).FirstOrDefaultAsync();
					if (user != null)
					{
						var userToVerifyToken = new Userverification()
						{
							UserId = user.Id,
						};
						await _context.Userverifications.AddAsync(userToVerifyToken);
						await _context.SaveChangesAsync();
						return userToVerifyToken;
					}
				}
				return null;
			}
			catch (Exception)
			{

				throw;
			}
		}
		public bool VerifyUserToken(Guid token)
		{
			try
			{
				if (token != null)
				{
					var checkToken = _context.Userverifications.Where(x => x.Token == token).Include(p => p.User).FirstOrDefault();
					if (checkToken != null)
					{
						checkToken.Used = true;
						checkToken.DateUsed = DateTime.Now;
						checkToken.User.EmailConfirmed = true;
						_context.Update(checkToken);
						_context.SaveChanges();
						return true;
					}
				}
				return false;
			}
			catch (Exception)
			{

				throw;
			}
		}
		public async Task<Userverification> GetUserToken(Guid token)
		{
			return await _context.Userverifications.Where(t => t.Used != true && t.Token == token)?.Include(s => s.User).FirstOrDefaultAsync();
		}
		public async Task<bool> MarkTokenAsUsed(Userverification userVerification)
		{
			var VerifiedUser = _context.Userverifications.Where(s => s.UserId == userVerification.User.Id && s.Used != true).FirstOrDefault();
			if (VerifiedUser != null)
			{
				userVerification.Used = true;
				userVerification.DateUsed = DateTime.Now;
				_context.Update(userVerification);
				await _context.SaveChangesAsync();
				return true;
			}
			return false;
		}
        public async Task<ApplicationUser> CreateUser(ApplicationUserViewModel model)
		{
			if (model != null)
			{
				var user = new ApplicationUser()
				{
					Email = model.Email,
					UserName = model.Email,
					Password = model.Password,
					ConfirmPassword = model.ConfirmPassword,
				};
				if (user.UserName != null && user.Email != null)
				{
                    var result =  _userManager.CreateAsync(user, model.Password).Result;
                    if (result.Succeeded)
                    {
                        return user;
                    }
                }
                return null;
            }
			return null;
		}
    }
}
