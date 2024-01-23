using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Enums
{
	public enum OrderedEnumList
	{
		[Description("For Booked")]
		Booked,
		[Description("For Canceled")]
		Canceled,
		[Description("For Delivered")]
		Delivered,
	}
}
