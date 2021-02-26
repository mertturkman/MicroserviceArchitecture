using CrossCutting.EventBus.Abstractions;
using MassTransit;

namespace CrossCutting.EventBus {
    public class IntegrationEventBus : EventBus, IIntegrationEventBus
    {
        public IntegrationEventBus(IBusControl busControl) : base(busControl)
        {
        }
    }
}