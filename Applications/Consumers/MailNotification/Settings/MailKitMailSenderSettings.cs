using System;
using System.Collections.Generic;
using System.Text;

namespace MailNotification.Settings
{
    public class MailKitMailSenderSettings
    {
        public string Server { get; set; }
        public int Port { get; set; }
        public string From { get; set; }
        public string FromName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
