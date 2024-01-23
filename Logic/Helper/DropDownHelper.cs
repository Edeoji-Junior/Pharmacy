using Core.Database;
using Core.Enums;
using Core.Models;
using Logic.IHelper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic.FileIO;


namespace Logic.Helper
{
    public class DropDownHelper: IDropDownHelper
    {
		private readonly ApplicationDb _context;
		private readonly UserManager<ApplicationUser> _userManager;
		private readonly IUserHelper _userHelper;

		public DropDownHelper(ApplicationDb context, UserManager<ApplicationUser> userManager, IUserHelper userHelper)
        {
			_context = context;
			_userManager = userManager;
			_userHelper = userHelper;
		}
		public List<DropdownEnumModel> GetDropdown()
		{
			var common = new DropdownEnumModel()
			{
				Id = 0,
				Name = "-- Select --"

			};
			var enumList = ((DropdownEnum[])Enum.GetValues(typeof(DropdownEnum))).Select(c => new DropdownEnumModel() { Id = (int)c, Name = c.ToString() }).ToList();
			enumList.Insert(0, common);
			return enumList;
		}
		public class DropdownEnumModel
		{
			public int Id { get; set; }
			public string? Name { get; set; }
		}
		public async Task<List<State>> GetState()
		{
			try
			{
				var common = new State
				{
					Id = 0,
					Name = "<--- select state ---->"
				};
				var selectedState = await _context.States.OrderBy(x => x.Name).Where(x=> x.Active && !x.Deleted).ToListAsync();
				if (selectedState != null)
				{
					selectedState.Insert(0, common);
				}
				return null;
			}
			catch (Exception)
			{

				throw;
			}
		}
		public async Task<List<Country>> GetCountry()
		{
			try
			{
				var common = new Country()
				{
					Id = 0,
					Name = "<------ select country --->"
				};
				var selectCountry = await _context.Countries.OrderBy(x => x.Name).Where(x => x.Active && !x.Deleted).ToListAsync();
				if (selectCountry != null)
				{
					selectCountry.Insert(0, common);
				}
				return null;
			}
			catch (Exception)
			{

				throw;
			}
		}
		public async Task<List<CommonDropDown>> GetDropdownByKey(DropdownEnum dropDownKey, bool deleteOption = false)
		{
			try
			{
				var common = new CommonDropDown()
				{
					Id = 0,
					Name = "<---- select Gender --->"
				};
				var selectGender = await _context.CommonDropDowns.OrderBy(s=> s.Deleted == deleteOption && s.DropdownKey ==(int)dropDownKey).OrderBy(s=> s.Name).ToListAsync();
				if (selectGender != null) 
				{
					selectGender.Insert(0, common);
				}
				return null;
			}
			catch (Exception)
			{

				throw;
			}
		}
		public async Task<List<CompanyBranch>> GetCompanyBranchDropDown(string userName)
		{
			try
			{
				if (userName != null)
				{
					var getUserName = _context.ApplicationUsers.Where(x => x.UserName == userName).FirstOrDefault();
	
					var common = new CompanyBranch()
					{
						Id = 0,
						Name = "<---- select company branch"
					};
					if (getUserName != null)
					{
						var selectBranch = await _context.CompanyBranches.OrderBy(x => x.Name).Where(x => x.CompanyId == getUserName.CompanyId && !x.Deleted == true).ToListAsync();
						if (selectBranch != null)
						{
							selectBranch.Insert(0, common);
							return selectBranch;
						}
					}
					return null;
				}
				return null;
			}
			catch (Exception)
			{
				throw;
			}
		}
		public async Task<List<Department>> GetCompanyInBranches(int branchId)
		{
			try
			{
				if (branchId > 0)
				{
					var common = new Department()
					{
						Id = 0,
						Name = "<---- select Department ---->"
					};
					var selectDepartment =await _context.Departments.Where(x=> x.BranchId == branchId && x.Active && !x.Deleted).ToListAsync();
					if (selectDepartment != null)
					{
						selectDepartment.Insert(0, common);
						return selectDepartment;
					}
					return null;
				}
				return null;
			}
			catch (Exception)
			{

				throw;
			}
		}
	}
}
