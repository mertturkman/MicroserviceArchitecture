using MailNotification.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailNotification.Infrastructure.Repositories
{
    public class Repository : IRepository
    {
        private readonly MailNotificationContext _mailNotificationContext;
        public Repository(MailNotificationContext mailNotificationContext)
        {
            _mailNotificationContext = mailNotificationContext;
        }

        public void CreateSentMail(SentMail sentMail)
        {
            _mailNotificationContext.SentMails.Add(sentMail);
            _mailNotificationContext.SaveEntities();
        }

        public MailTemplate FindMailTemplateByName(string name)
        {
            return _mailNotificationContext.MailTemplates.Single(mailTemplate => mailTemplate.Name == name);
        }
    }
}
