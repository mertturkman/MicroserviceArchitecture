using MailNotification.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MailNotification.Infrastructure.Repositories
{
    public interface IRepository
    {
        MailTemplate FindMailTemplateByName(string name);
        void CreateSentMail(SentMail sentMail);
    }
}
