using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
	public class Department: Basemodel
	{
		public Guid? CompanyId { get; set; }
		[Display(Name = "Company")]
		[ForeignKey("CompanyId")]
		public virtual Company Company { get; set; }

		[Display(Name = "Department Name")]
		public new string Name { get; set; }

		public int? BranchId { get; set; }
		[Display(Name = "Company Branch")]
		[ForeignKey("BranchId")]
		public virtual CompanyBranch CompanyBranch { get; set; }

		public string LineManagerId { get; set; }
		[Display(Name = "LineManager")]
		[ForeignKey("LineManagerId")]
		public virtual ApplicationUser LineManager { get; set; }
	}
}
