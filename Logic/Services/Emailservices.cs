using Hangfire;
using Logic.IHelper;
using MailKit.Security;
using MimeKit.Text;
using MimeKit;
using System.Net.Mail;

namespace Logic.Services
{
	public interface IEmailService
	{
		bool SendEmail(string toEmail, string subject, string message);
		void Send(EmailMessage emailMessage);
		void CallHangfire(EmailMessage emailMessage);
		void SendEmailWithAttachment(string toEmail, string subject, string message, string path);
		void SendWithAttachment(EmailMessage emailMessage, string path);
		void SendEmailWithoutHangfire(string toEmail, string subject, string message);
		void CallHangfires(EmailMessage emailMessage, string path);
	}

	public class Emailservices : IEmailService
	{
		private IEmailConfiguration _emailConfiguration;

		public Emailservices(IEmailConfiguration emailConfiguration)
        {
			_emailConfiguration = emailConfiguration;

		}
		public bool SendEmail(string toEmail, string subject, string message)
		{
			EmailAddress fromAddress = new EmailAddress()
			{
				Name = "Pharmacy King",
				Address = _emailConfiguration.SmtpUsername,
			};
			List<EmailAddress> fromAddressList = new List<EmailAddress>
				{
					fromAddress
				};
			EmailAddress toAddress = new EmailAddress()
			{
				Address = toEmail
			};
			List<EmailAddress> toAddressList = new List<EmailAddress>
				{
				toAddress
			};

			EmailMessage emailMessage = new EmailMessage()
			{
				FromAddresses = fromAddressList,
				ToAddresses = toAddressList,
				Subject = subject,
				Content = message
			};

			Send(emailMessage);

			//CallHangfire(emailMessage);
			return true;
		}
		public void CallHangfire(EmailMessage emailMessage)
		{
			BackgroundJob.Enqueue(() => Send(emailMessage));
		}
		public void Send(EmailMessage emailMessage)
		{
			var message = new MimeMessage();
			message.To.AddRange(emailMessage.ToAddresses.Select(x => new MailboxAddress(x.Name, x.Address)));
			message.From.AddRange(emailMessage.FromAddresses.Select(x => new MailboxAddress(x.Name, x.Address)));

			message.Subject = emailMessage.Subject;
			//We will say we are sending HTML. But there are options for plaintext etc. 
			message.Body = new TextPart(TextFormat.Html)
			{
				Text = emailMessage.Content
			};

			//Be careful that the SmtpClient class is the one from Mailkit not the framework!
			using (var emailClient = new MailKit.Net.Smtp.SmtpClient())
			{
				emailClient.ServerCertificateValidationCallback = (s, c, h, e) => true;
				// emailClient.Timeout = 30000;
				//emailClient.LocalDomain = "https://localhost:44300";
				//The last parameter here is to use SSL (Which you should!)
				emailClient.Connect(_emailConfiguration.SmtpServer, _emailConfiguration.SmtpPort, SecureSocketOptions.Auto);

				//Remove any OAuth functionality as we won't be using it. 
				emailClient.AuthenticationMechanisms.Remove("XOAUTH2");

				emailClient.Authenticate(_emailConfiguration.SmtpUsername, _emailConfiguration.SmtpPassword);

				emailClient.Send(message);

				emailClient.Disconnect(true);
			}
		}
		public void SendEmailWithAttachment(string toEmail, string subject, string message, string path)
		{
			EmailAddress fromAddress = new EmailAddress()
			{
				Name = "Techleft Hr ",
				Address = _emailConfiguration.SmtpUsername,
			};

			List<EmailAddress> fromAddressList = new List<EmailAddress>
			{
			   fromAddress
			};

			EmailAddress toAddress = new EmailAddress()
			{
				Name = "BiviHr Support Team ",

				Address = toEmail
			};

			List<EmailAddress> toAddressList = new List<EmailAddress>
			{
			   toAddress
			};

			EmailMessage emailMessage = new EmailMessage()
			{
				FromAddresses = fromAddressList,
				ToAddresses = toAddressList,
				Subject = subject,
				Content = message,
				// Attachments = path
			};
			CallHangfires(emailMessage, path);
		}
		public void CallHangfires(EmailMessage emailMessage, string path)
		{
			BackgroundJob.Enqueue(() => SendWithAttachment(emailMessage, path));
		}
		public void SendWithAttachment(EmailMessage emailMessage, string path)
		{
			var message = new MimeMessage();
			message.To.AddRange(emailMessage.ToAddresses.Select(x => new MailboxAddress(x.Name, x.Address)));
			message.From.AddRange(emailMessage.FromAddresses.Select(x => new MailboxAddress(x.Name, x.Address)));
			message.Subject = emailMessage.Subject;

			var body = new TextPart(TextFormat.Html)
			{
				Text = emailMessage.Content
			};

			var attachment = new MimePart("image", "gif")
			{
				Content = new MimeContent(File.OpenRead(path)),
				ContentDisposition = new ContentDisposition(ContentDisposition.Attachment),
				ContentTransferEncoding = ContentEncoding.Base64,
				FileName = Path.GetFileName(path)
			};
			var multipart = new Multipart("mixed");
			multipart.Add(body);
			multipart.Add(attachment);
			message.Attachments.Append(attachment);
			message.Body = multipart;
			//Be careful that the SmtpClient class is the one from Mailkit not the framework!
			using (var emailClient = new MailKit.Net.Smtp.SmtpClient())
			{
				emailClient.ServerCertificateValidationCallback = (s, c, h, e) => true;
				// emailClient.Timeout = 30000;
				//emailClient.LocalDomain = "https://localhost:44300";
				//The last parameter here is to use SSL (Which you should!)
				emailClient.Connect(_emailConfiguration.SmtpServer, _emailConfiguration.SmtpPort, SecureSocketOptions.Auto);
				//Remove any OAuth functionality as we won't be using it. 
				emailClient.AuthenticationMechanisms.Remove("XOAUTH2");
				emailClient.Authenticate(_emailConfiguration.SmtpUsername, _emailConfiguration.SmtpPassword);
				emailClient.Send(message);
				emailClient.Disconnect(true);
			}
		}
		public void SendEmailWithoutHangfire(string toEmail, string subject, string message)
		{
			EmailAddress fromAddress = new EmailAddress()
			{
				Name = "BiviHr Support Team",
				Address = _emailConfiguration.SmtpUsername,

			};
			List<EmailAddress> fromAddressList = new List<EmailAddress>
			{
				fromAddress
			};
			EmailAddress toAddress = new EmailAddress()
			{
				Address = toEmail
			};
			List<EmailAddress> toAddressList = new List<EmailAddress>
			{
				toAddress
			};
			EmailMessage emailMessage = new EmailMessage()
			{
				FromAddresses = fromAddressList,
				ToAddresses = toAddressList,
				Subject = subject,
				Content = message
			};
			Send(emailMessage);
		}
	}
}
