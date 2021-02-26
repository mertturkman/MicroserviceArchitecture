using System;
using System.Collections.Generic;
using System.Text;

namespace MailNotification.Infrastructure.Entities
{
    public class MailTemplate
    {
        public string Name { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public bool IsBodyHtml { get; set; }
        public ICollection<SentMail> SentMails { get; set; }
    }
}
