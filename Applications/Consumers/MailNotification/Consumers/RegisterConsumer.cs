using System;
using MassTransit;
using System.Threading.Tasks;
using MailNotification.Infrastructure.Repositories;

namespace MailNotification.Consumers
{
    public class RegisterConsumer: IConsumer<CrossCutting.Events.User.Register> 
    {
        private IRepository _repository { get; set; }
        public RegisterConsumer(IRepository repository)
        {
            _repository = repository;
        }
        public async Task Consume(ConsumeContext<CrossCutting.Events.User.Register> context)
        {
            Console.Out.WriteLine(context.Message.GetFullName());
        }
    }
}