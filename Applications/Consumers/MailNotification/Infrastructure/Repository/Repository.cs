using MailNotification.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

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
            _mailNotificationContext.Entry(sentMail).State = EntityState.Added;
            _mailNotificationContext.SaveEntities();
        }

        public MailTemplate FindMailTemplateByName(string name)
        {
            return _mailNotificationContext.MailTemplates.Single(mailTemplate => mailTemplate.Name == name);
        }
    }
}
