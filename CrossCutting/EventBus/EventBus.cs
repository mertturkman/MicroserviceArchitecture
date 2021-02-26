using System.Collections.Generic;
using System.Threading.Tasks;
using MassTransit;

namespace CrossCutting.EventBus
{
    public class EventBus
    {
        private readonly IBusControl bus;

        protected EventBus(IBusControl bus)
        {
            this.bus = bus;
        }

        public async Task Publish(object values, Dictionary<string, object> headers = null)
        {
            await this.bus.Publish(values,
                publishPipe =>
                {
                    if (headers != null)
                    {
                        foreach (var header in headers)
                        {
                            publishPipe.Headers.Set(header.Key, header.Value);
                        }
                    }
                });
        }
    }
}

