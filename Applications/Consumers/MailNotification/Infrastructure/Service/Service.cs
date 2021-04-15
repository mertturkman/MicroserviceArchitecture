using MailKit.Net.Smtp;
using MailNotification.Infrastructure.Entities;
using MailNotification.Infrastructure.Repositories;
using MailNotification.Settings;
using Microsoft.Extensions.Options;
using MimeKit;
using MimeKit.Text;

namespace MailNotification.Infrastructure.Service
{
	public class Service : IService
	{
		private readonly MailKitMailSenderSettings _mailSettings;
		private readonly IRepository _repository;

		public Service(IRepository repository, IOptions<MailKitMailSenderSettings> mailSettings)
		{
			_mailSettings = mailSettings.Value;
			_repository = repository;
		}

		public void SendMail(SentMail mail)
		{
			mail.From = _mailSettings.From;

			MimeMessage message = new MimeMessage();
			message.To.Add(MailboxAddress.Parse(mail.To));
			message.From.Add(MailboxAddress.Parse(mail.From));

			message.Subject = mail.Subject;
			if(mail.IsBodyHtml)
            {
				message.Body = new TextPart(TextFormat.Html) 
				{
					Text = mail.Body
				};
			}
			else
            {
				message.Body = new TextPart(TextFormat.Text)
				{
					Text =  mail.Body
				};
			}

			using (SmtpClient emailClient = new SmtpClient())
			{
				emailClient.Connect(_mailSettings.Server, _mailSettings.Port);
				emailClient.AuthenticationMechanisms.Remove("XOAUTH2");
				emailClient.Authenticate(_mailSettings.Username, _mailSettings.Password);
				emailClient.Send(message);
				emailClient.Disconnect(true);
			}

			_repository.CreateSentMail(mail);
		}
	}
}
