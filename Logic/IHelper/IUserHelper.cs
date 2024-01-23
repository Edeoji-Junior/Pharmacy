using Core.Models;
using Core.Viewmodels;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.IHelper
{
	public interface IUserHelper
	{
		Task<ApplicationUser> FindUserByEmailAsync(string email);
		Task<ApplicationUser> FindUserByUserNameAsync(string username);
		ApplicationUser FindByUserId(string id);
		ApplicationUser FindByUserName(string username);
		Task<Userverification> CreateUserTokenAsync(string email);
		ApplicationUser FindUserByEmail(string email);
		bool VerifyUserToken(Guid token);
		Task<Userverification> GetUserToken(Guid token);
		Task<bool> MarkTokenAsUsed(Userverification userVerification);
		Task<ApplicationUser> FindUserByUserIdAsync(string id);
		Task<ApplicationUser> CreateUser(ApplicationUserViewModel model);
	}
}
