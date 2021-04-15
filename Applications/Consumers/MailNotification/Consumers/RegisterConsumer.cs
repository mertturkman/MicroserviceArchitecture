using System;
using MassTransit;
using System.Threading.Tasks;
using MailNotification.Infrastructure.Repositories;
using CrossCutting.Events.User;
using MailNotification.Infrastructure.Entities;
using MailNotification.Infrastructure;
using MailNotification.Infrastructure.Service;

namespace MailNotification.Consumers
{
    public class RegisterConsumer: IConsumer<Register> 
    {
        private IRepository _repository { get; set; }
        private IService _service { get; set; }
        public RegisterConsumer(IRepository repository, IService service)
        {
            _repository = repository;
            _service = service;
        }
        public async Task Consume(ConsumeContext<Register> context)
        {
            SentMail sentMail = PrepareSentMail(context.Message);
            _service.SendMail(sentMail);
        }

        public SentMail PrepareSentMail(Register message)
        {
            MailTemplate mailTemplate = _repository.FindMailTemplateByName(Const.MailTemplate_Register);

            return new SentMail
            {
                To = message.Mail,
                Subject = mailTemplate.Subject,
                Body = mailTemplate.Body.Replace("{fullname}", message.GetFullName()),
                IsBodyHtml = true,
                MailTemplate = mailTemplate
            };
        }
    }
}