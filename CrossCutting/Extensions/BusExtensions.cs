using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using MassTransit;
using MassTransit.RabbitMqTransport;
using CrossCutting.EventBus.Settings;
using GreenPipes;
using RabbitMQ.Client;

namespace CrossCutting.Extensions
{
    public static class BusExtensions
    {
        public static IRabbitMqBusFactoryConfigurator CustomReceiveEndPoint<TEvent,TConsumer>(this IRabbitMqBusFactoryConfigurator z, ReceiverEndpoint receiverEndpoint,
            IBusRegistrationContext y) where TEvent : class where TConsumer : class, IConsumer<TEvent>
        {
            z.ReceiveEndpoint(receiverEndpoint.QueueName, l =>
            {
                l.PrefetchCount = receiverEndpoint.PrefetchCount;
                if (!receiverEndpoint.RetryCount.Equals(default))
                {
                    l.UseMessageRetry(r =>
                        r.Interval(receiverEndpoint.RetryCount,
                            receiverEndpoint.RetryInterval));
                }

                l.UseConcurrencyLimit(receiverEndpoint.ConcurrencyLimit);
                l.ConfigureConsumeTopology = false;
                l.Bind<TEvent>(m =>
                {
                    m.ExchangeType = ExchangeType.Topic;
                    m.RoutingKey = receiverEndpoint.RoutingKeys[0];
                });

                l.ConfigureConsumer<TConsumer>(y);
            });

            return z;
        }
    }
}