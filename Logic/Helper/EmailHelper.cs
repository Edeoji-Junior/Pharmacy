using Core.Models;
using Logic.IHelper;
using Logic.Services;
using Microsoft.AspNetCore.Identity;



namespace Logic.Helper
{
    public class EmailHelper : IEmailHelper
    {
		private readonly IEmailConfiguration _emailConfiguration;
		private readonly IEmailService emailService;
		private readonly UserManager<ApplicationUser> _userManager;

		public EmailHelper(IEmailConfiguration emailConfiguration, IEmailService emailService, UserManager<ApplicationUser> userManager)
        {
			_emailConfiguration = emailConfiguration;
			this.emailService = emailService;
			_userManager = userManager;

		}
		public bool SendEmailVerification(ApplicationUser user, string linkToClick)
		{
			if (user != null && linkToClick != null)
			{
				string toEmail = user.Email;
				string subject = "Greate Pharmacy King and Store";

				var message = "Dear " + user.FirstName + "," + "</br> " +
				 "This is to notify you, that you have been registered successfully with Greate Pharmacy King and Store." + "<br/>" +
				 "Kindly click on the button to verify your email <br/> <br/>" +
				 "<button> <a href='" + linkToClick + "'> Verify </a>" + "</button> <br/>" +
				 "or copy the link " + linkToClick + "to a browser to continue. <br/> <br/>" +
				  "Kind regards,<br/>" +
				  "Greate PharcyKing Group.";
				var isSent = emailService.SendEmail(toEmail, subject, message);
				
				if (isSent)
				{
					return true;
				}
			}
			return false;
		}
		public bool PasswordResetConfirmation(ApplicationUser applicationUser)
		{
			if (applicationUser.Email != null)
			{
				var loggedInUser = _userManager.FindByNameAsync(applicationUser.Email).Result;
				string toEmail = applicationUser.Email;
				string subject = "Password Reset Successfully";
				string message = "Password reset Successfully, please login with your new details to continue" + "</br>" +
					"<br/>Need help? We’re here for you." + "<br/>" +
					"Simply reply to this email to contact us. <br/>" +
					"<br/>" +

					"Kind regards,<br/>" +
					 _emailConfiguration.AdminEmail;
				if (toEmail != null && loggedInUser != null)
				{
					emailService.SendEmail(toEmail, subject, message);
					return true;

				}
			};
			return false;
		}
	}
}
