using System;
using CrossCutting.EventBus.Abstractions;

namespace Crosscutting.EventContext
{
    public interface IEventContext : IDisposable
    {
        void AddRaisedIntegrationEvent(IEvent @event);
        
        void DispatchIntegrationEvents();
    }
}