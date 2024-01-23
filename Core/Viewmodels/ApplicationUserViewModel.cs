using Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Viewmodels
{
	public class ApplicationUserViewModel
	{
		public string? FirstName { get; set; }
		public string? LastName { get; set; }
		public string? Address { get; set; }
		public string? Email { get; set; }
		public string? CreatedBy { get; set; }
		public DateTime DateOfBirth { get; set; }
		public string? ProfilePicture { get; set; }
		public string? LicenseNumber { get; set; }
		public string? FulName => FirstName + LastName;
		public bool? Active { get; set; }
		public bool? IsDeleted { get; set; }
		public string? Password { get; set; }
		public string? ConfirmPassword { get; set; }
		public string? UserName { get; set; }
		public string? StorageConditions { get; set; }
		public int ProductId { get; set; }
		public string? Products { get; set; }
		public string? Orders { get; set; }
		public DateTime? DateCreated { get; set; }
		public int? CompanyBranchId { get; set; }
		public string? CompanyBranch { get; set; }

		public Guid? CompanyId { get; set; }
		
		public string? Company { get; set; }

		public int? GenderId { get; set; }
		
		public string? Gender { get; set; }

		public int LineManagerId { get; set; }
		
		public string? LineManager { get; set; }
	}
}
