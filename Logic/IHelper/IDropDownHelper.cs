using Core.Enums;
using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Logic.Helper.DropDownHelper;

namespace Logic.IHelper
{
    public interface IDropDownHelper
    {
		Task<List<State>> GetState();
		Task<List<Country>> GetCountry();
		Task<List<CommonDropDown>> GetDropdownByKey(DropdownEnum dropDownKey, bool deleteOption = false);
		Task<List<CompanyBranch>> GetCompanyBranchDropDown(string userName);
		Task<List<Department>> GetCompanyInBranches(int branchId);
		List<DropdownEnumModel> GetDropdown();
	}
}
