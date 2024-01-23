using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace Core.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Address { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string? LicenseNumber { get; set; }
        public string? FulName => FirstName + LastName;
        public bool? Active { get; set; }
        public bool? IsDeleted { get; set; }
        public string? Password { get; set; }
        public string? ConfirmPassword { get; set; }
        public string? ProfilePicture { get; set; }
       
        public string? StorageConditions { get; set; }
        public int ProductId { get; set; }  
        public ICollection<Product> Products { get; set; }
        public ICollection<Order> Orders { get; set; }
        public DateTime? DateCreated { get; set; }
		public int? CompanyBranchId { get; set; }

		[Display(Name = "CompanyBranch")]
		[ForeignKey("CompanyBranchId")]
		public virtual CompanyBranch CompanyBranch { get; set; }

		public Guid? CompanyId { get; set; }
		[Display(Name = "Company")]
		[ForeignKey("CompanyId")]
		public virtual Company? Company { get; set; }

		public int? GenderId { get; set; }
		[Display(Name = "Gender")]
		[ForeignKey("GenderId")]
		public virtual CommonDropDown? Gender { get; set; }

		public string LineManagerId { get; set; }
		[Display(Name = "LineManager")]
		[ForeignKey("LineManagerId")]
		public virtual ApplicationUser LineManager { get; set; }
	}
}
