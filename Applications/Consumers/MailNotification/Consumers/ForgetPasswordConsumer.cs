using CrossCutting.Events.User;
using MailNotification.Infrastructure;
using MailNotification.Infrastructure.Entities;
using MailNotification.Infrastructure.Repositories;
using MailNotification.Infrastructure.Service;
using MassTransit;
using System.Threading.Tasks;

namespace MailNotification.Consumers
{
    public class ForgetPasswordConsumer: IConsumer<ForgetPassword>
    {
        private readonly IService _service;
        private readonly IRepository _repository;
        
        public ForgetPasswordConsumer(IService service, IRepository repository)
        {
            _service = service;
            _repository = repository;
        }
        public async Task Consume(ConsumeContext<ForgetPassword> context)
        {
            SentMail sentMail = PrepareSentMail(context.Message);
            _service.SendMail(sentMail);
        }

        public SentMail PrepareSentMail(ForgetPassword message)
        {
            MailTemplate mailTemplate = _repository.FindMailTemplateByName(Const.MailTemplate_ForgetPassword);

            return new SentMail
            {
                To = message.Mail,
                Subject = mailTemplate.Subject,
                Body = mailTemplate.Body.Replace("{token}", message.Token),
                IsBodyHtml = true,
                MailTemplate = mailTemplate
            };
        }
    }
}
