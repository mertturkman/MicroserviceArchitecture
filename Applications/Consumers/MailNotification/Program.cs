using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using MassTransit;
using MailNotification.Consumers;
using Microsoft.Extensions.Options;
using MailNotification.Consumers.Settings;
using CrossCutting.Extensions;
using MailNotification.Infrastructure;
using MailNotification.Infrastructure.Repositories;
using MailNotification.Infrastructure.Service;
using MailNotification.Settings;
using Microsoft.EntityFrameworkCore;
using IHost = Microsoft.Extensions.Hosting.IHost;

namespace MailNotification
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            await CreateHostBuilder(args).Build().RunAsync();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>{               
                    BootstrapConsumers(services, hostContext);
                });

        private static void BootstrapConsumers(IServiceCollection services, HostBuilderContext hostContext)
        {
            services.Configure<IntegrationBusReceiverSettings>(hostContext.Configuration.GetSection("IntegrationBusReceiverSettings"));
            services.Configure<MailKitMailSenderSettings>(hostContext.Configuration.GetSection("MailKitMailSenderSettings"));

            services.AddEntityFrameworkNpgsql()
                    .AddDbContext<MailNotificationContext>(
                    option => {
                        option.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
                        option.UseNpgsql(hostContext.Configuration.GetSection("ConnectionStrings:MailNotificationDB").Value);
                    });

            services.AddScoped<IRepository, Repository>();
            services.AddScoped<IService, Service>();
            
            services.AddMassTransit(x =>
            {
                x.AddConsumer<RegisterConsumer>();
                x.AddConsumer<ForgetPasswordConsumer>();

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
                    cfg.CustomReceiveEndPoint<CrossCutting.Events.User.ForgetPassword, ForgetPasswordConsumer>(settings.ForgetPasswordReceiverEndpoint, busRegisterContext);
                });
            });
            services.AddMassTransitHostedService();
        }
    }
}
