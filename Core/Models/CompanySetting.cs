using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
	public class CompanySetting
	{
		[Key]
		public Guid CompanyId { get; set; }
		[Display(Name = "Company")]
		[ForeignKey("CompanyId")]
		public virtual Company Company { get; set; }
		public bool ShowAllClientsInAllScheduleScreen { get; set; }
		public bool ShowAllStaffInAllScheduleScreen { get; set; }
		public bool ShowLeaveModule { get; set; }
		public bool ShowClockIn { get; set; }
		public bool ShowPayroll { get; set; }
		public bool ShowProject { get; set; }
		public bool ShowSchedule { get; set; }
		public bool Deleted { get; set; }
		public bool Active { get; set; }
	}
}
