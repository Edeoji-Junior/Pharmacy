using Core.Database;
using Core.Models;
using Core.Viewmodels;
using Logic.IHelper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Net.WebSockets;


namespace Logic.Helper
{
    public class AdminHelper: IAdminHelper
    {
		private readonly ApplicationDb _context;
		private readonly UserManager<ApplicationUser> _userManager;
		private readonly RoleManager<IdentityRole> _roleManager;

		public AdminHelper(ApplicationDb context, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
			_context = context;
			_userManager = userManager;
			_roleManager = roleManager;
		}
		public async Task<IdentityRole> CreateRole(RoleViewModel model)
		{
			try
			{
				if (model != null)
				{
					var user = new IdentityRole
					{
						Name = model.Name,
					};
					await _context.Roles.AddAsync(user);
					await _context.SaveChangesAsync();
					return user;
				}
				return null;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
        public IdentityRole EditRoleName(RoleViewModel roleViewModel, Guid roleId)
        {
            try
            {
                if (roleViewModel != null && roleId != Guid.Empty)
                {
                    // Retrieve the role by roleId
                    var role = _context.Roles.Find(roleId.ToString());

                    if (role != null)
                    {
                        // Update the role name with the new name from RoleViewModel
                        role.Name = roleViewModel.Name;

                        // Save changes to the database
                        var saveRole = _context.Update(role);

                        if (saveRole != null)
                        {
                            // If the update was successful, return the updated role
                            _context.SaveChanges(); 
                            return role;
                        }
                        else
                        {
                            return null;
                        }
                    }
                    else
                    {
                        return null;
                    }
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions appropriately, log them, and throw a custom exception if needed
                throw new Exception("An error occurred while editing the role.", ex);
            }
        }

    }
}
