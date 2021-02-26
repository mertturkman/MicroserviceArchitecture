using System;
using System.Collections.Generic;
using System.Text;

namespace MailNotification.Infrastructure.Entities
{
    public class SentMail
    {
        public Guid Id { get; set; }
        public string Status { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public bool IsBodyHtml { get; set; }
        public DateTime SentDate { get; set; }
        public MailTemplate MailTemplate { get; set; }
    }
}
