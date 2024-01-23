using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class Company
    {
        [Key]
        [Display(Name = "Company Id")]
        public Guid Id { get; set; }

        [Display(Name = "Description")]
        public string? Description { get; set; }

        [Display(Name = "DateCreated")]
        public DateTime DateCreated { get; set; }

        [Display(Name = "Address")]
        public string? Address { get; set; }

        [Display(Name = "Contact Person")]
        public string? ContactPerson { get; set; }
        [Display(Name = "Company Email")]
        public string? Email { get; set; }

        [Display(Name = "Phone Number")]
        public string? Phone { get; set; }

        [Display(Name = "Mobile Number")]
        public string? Mobile { get; set; }

        [Display(Name = "Company's Website")]
        public string? Website { get; set; }

		public int? CountryId { get; set; }
		[Display(Name = "Country")]
		[ForeignKey("CountryId")]
		public virtual Country? Country { get; set; }

		public int? StateId { get; set; }
		[Display(Name = "State")]
		[ForeignKey("StateId")]
		public virtual State? State { get; set; }


		[Display(Name = "Postal Code")]
        public string? PostalCode { get; set; }

        public string? LogoUrl { get; set; }
        public string? Name { get; set; }
        public bool Active { get; set; }
        public bool Deleted { get; set; }

        [NotMapped]
        [Required(ErrorMessage = "Please choose a file or folder from your device")]
        [Display(Name = "Logo Url")]
        public IFormFile? CompanyLogoUrl { get; set; }

        public string? CreatedById { get; set; }
        [Display(Name = "CreatedBy")]
        [ForeignKey("CreatedById")]
        public virtual ApplicationUser? CreatedBy { get; set; }
    }
}
