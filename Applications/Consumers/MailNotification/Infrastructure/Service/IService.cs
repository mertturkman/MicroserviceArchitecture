using MailNotification.Infrastructure.Entities;

namespace MailNotification.Infrastructure.Service
{
    public interface IService
    {
        void SendMail(SentMail mail);
    }
}
