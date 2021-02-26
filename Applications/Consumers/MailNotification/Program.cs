using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using MassTransit;
using MailNotification.Consumers;
using Microsoft.Extensions.Options;
using MailNotification.Consumers.Settings;
using CrossCutting.Extensions;

namespace MailNotification
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>{               
                    services.Configure<IntegrationBusReceiverSettings>(hostContext.Configuration.GetSection("IntegrationBusReceiverSettings"));
                    BootstrapConsumers(services);
                });

            await builder.Build().RunAsync();
        }

        private static void BootstrapConsumers(IServiceCollection services)
        {
            services.AddMassTransit(x =>
            {
                x.AddConsumer<RegisterConsumer>();

                x.UsingRabbitMq((busRegisterContext, cfg) =>
                {
                    var settings = busRegisterContext.GetRequiredService<IOptions<IntegrationBusReceiverSettings>>().Value;

                    Uri UriBuilder(string server, string vHost)
                    {
                        return new Uri($"rabbitmq://{server}/{vHost}");
                    }

                    cfg.Host(UriBuilder(settings.ClusterName, settings.VirtualHost), h =>
                    {
                        h.Username(settings.UserName);
                        h.Password(settings.Password);
                        h.UseCluster(c =>
                        {
                            foreach (var settingsServer in settings.Servers)
                            {
                                c.Node(settingsServer);
                            }
                        });
                    });

                    cfg.CustomReceiveEndPoint<CrossCutting.Events.User.Register, RegisterConsumer>(settings.RegisterReceiverEndpoint, busRegisterContext);
                });
            });
            services.AddMassTransitHostedService();
        }
    }
}
