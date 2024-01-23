using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Core.Models
{
    public class CompanyBranch : Basemodel
    {
        public Guid? CompanyId { get; set; }
        [Display(Name = "Company")]
        [ForeignKey("CompanyId")]
        public virtual Company? Company { get; set; }

        public int? CountryId { get; set; }
        [Display(Name = "Country")]
        [ForeignKey("CountryId")]
        public virtual Country? Country { get; set; }

        public int? StateId { get; set; }
        [Display(Name = "State")]
        [ForeignKey("StateId")]
        public virtual State? State { get; set; }


        [Display(Name = "Branch Name")]
        public new string? Name { get; set; }

        public string? Address { get; set; }

        [Display(Name = "Postal Code")]
        public string? PostalCode { get; set; }


        [Display(Name = "Branch Latitude")]
        public double Latitude { get; set; }

        [Display(Name = "Branch Longitude")]
        public double Longitude { get; set; }

        [Display(Name = "Branch CloclIn Radius")]
        public double AcceptedRadius { get; set; }
    }
}
