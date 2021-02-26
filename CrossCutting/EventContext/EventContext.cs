using System.Collections.Concurrent;
using System.Collections.Generic;
using CrossCutting.EventBus.Abstractions;

namespace Crosscutting.EventContext
{
    public class EventContext : IEventContext
    {
        private BlockingCollection<IEvent> raisedIntegrationEvents { get; }
        private IIntegrationEventBus eventBus { get; }

        public EventContext(IIntegrationEventBus eventBus)
        {
            this.raisedIntegrationEvents = new BlockingCollection<IEvent>();
            this.eventBus = eventBus;
        }

        public void AddRaisedIntegrationEvent(IEvent @event)
        {
            raisedIntegrationEvents.TryAdd(@event);
        }

        private bool TryTakeRaisedIntegrationEvent(out IEvent @event)
        {
            return raisedIntegrationEvents.TryTake(out @event);
        }

        public void DispatchIntegrationEvents() 
        {
            IEvent @event;

            while(TryTakeRaisedIntegrationEvent(out @event)) 
            {
                eventBus.Publish(@event);
            }
        }

        public void Dispose()
        {
            raisedIntegrationEvents?.Dispose();
        }
    }
}