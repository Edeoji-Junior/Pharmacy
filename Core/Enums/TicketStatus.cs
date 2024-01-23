using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Enums
{
	public enum TicketStatus
	{
		[Description("For Booked")]
		Open,
		[Description("For Canceled")]
		InProgress,
		[Description("For Delivered")]
		Closed,
	}
}
