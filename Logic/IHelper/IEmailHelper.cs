using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.IHelper
{
    public interface IEmailHelper
    {
		bool SendEmailVerification(ApplicationUser user, string linkToClick);
		//bool PasswordResetConfirmation(ApplicationUser applicationUser);
		//bool ForgotPasswordTemplateEmailer(ApplicationUser applicationUser, string linkToClick);
	}
}
