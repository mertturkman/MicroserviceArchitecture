using CrossCutting.EventBus.Abstractions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using User.Domain.SeedWork;
using User.Infrastructure;

namespace User.Application.Abstractions.Command
{
    public class CommandDispatcher : ICommandDispatcher
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly IIntegrationEventBus _eventBus;
        private readonly UserContext _context;

        public CommandDispatcher(IServiceProvider serviceProvider, UserContext context, IIntegrationEventBus eventBus)
        {
            _serviceProvider = serviceProvider;
            _context = context;
            _eventBus = eventBus;
        }

        public async Task HandleAsync<TCommand>(TCommand command) where TCommand : ICommand
        {
            await _context.BeginTransactionAsync();
            
            var service = _serviceProvider.GetService(typeof(ICommandHandler<TCommand>)) as ICommandHandler<TCommand>;
            await service.ExecuteAsync(command);

            foreach (var entry in _context.ChangeTracker.Entries().Where(entry => (entry.State == EntityState.Added ||
                entry.State == EntityState.Modified) && entry.Entity is Entity))
            {
                Entity entity = entry.Entity as Entity;
                entity.Version = entity.Version + 1;
                entity.UpdatedTime = DateTime.UtcNow;

                if(entry.State == EntityState.Added)
                {
                    entity.CreatedTime = entity.UpdatedTime;
                }

                if(entity.GetUncommitedIntegrationEvents() != null)
                {
                    foreach (var uncommitedEvent in entity.GetUncommitedIntegrationEvents())
                    {
                        await _eventBus.Publish(uncommitedEvent.Event);
                    }
                }
            }

            await _context.CommitTransactionAsync();
        }
    }
}
