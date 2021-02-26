using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using User.Infrastructure;
using Microsoft.EntityFrameworkCore;
using AutoMapper.Attributes;
using CrossCutting.Extensions;
using User.Domain.SeedWork;
using Microsoft.Extensions.Options;
using System;
using Crosscutting.EventContext;
using MassTransit;
using RabbitMQ.Client;
using CrossCutting.EventBus.Abstractions;
using CrossCutting.EventBus;
using User.API.Settings;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Linq;
using User.Application.Abstractions.Command;
using User.Application.Abstractions.Query;
using User.API.Filters;
using User.Application.Utility;
using FluentValidation.AspNetCore;

namespace User.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(options =>
            {
                options.Filters.Add(new ValidationFilter());
            })
            .AddFluentValidation(options =>
            {
                options.RegisterValidatorsFromAssemblyContaining<PasswordHasher>();
            });

            services.AddEntityFrameworkNpgsql()
                .AddDbContext<UserContext>(
                    option => {
                        option.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
                        option.UseNpgsql(Configuration.GetSection("ConnectionStrings:UserDB").Value);
                    }, ServiceLifetime.Scoped);
            
            services.AddRepositoryDependencies(typeof(IRepository<>))
                .AddCustomSwagger();

            AddCommandQueryHandlers(services, typeof(ICommandHandler<>));
            AddCommandQueryHandlers(services, typeof(IQueryHandler<,>));

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.Authority = "http://localhost:9000";
                options.Audience = "user_api";
                options.RequireHttpsMetadata = false;
                options.SaveToken = true;
            });

            services.Configure<IntegrationBusSenderSettings>(Configuration.GetSection("IntegrationBusSenderSettings"));
     
            services.AddSingleton(serviceProvider =>
            {
                var settings = serviceProvider.GetService<IOptions<IntegrationBusSenderSettings>>().Value;

                Uri UriBuilder(string server, string vHost)
                {
                    return new Uri($"rabbitmq://{server}/{vHost}");
                }

                return Bus.Factory.CreateUsingRabbitMq(cfg =>
                {
                    cfg.Host(UriBuilder(settings.ClusterName, settings.VirtualHost), h =>
                    {
                        h.Username(settings.UserName);
                        h.Password(settings.Password);
                        h.UseCluster(x =>
                        {
                            foreach (var settingsServer in settings.Servers)
                            {
                                x.Node(settingsServer);
                            }
                        });
                    });

                    cfg.Send<CrossCutting.Events.User.Register>(x =>
                    {
                        x.UseRoutingKeyFormatter(c => settings.RegisterRoutingKey);
                    });

                    cfg.Publish<CrossCutting.Events.User.Register>(x => x.ExchangeType = ExchangeType.Topic);
                });            
            }).AddScoped<IIntegrationEventBus, IntegrationEventBus>()
              .AddScoped<IEventContext, EventContext>();

            services.AddScoped<ICommandDispatcher, CommandDispatcher>()
                .AddScoped<IQueryDispatcher, QueryDispatcher>();

            AutoMapper.Mapper.Initialize(config => {
                typeof(Program).Assembly.MapTypes(config);  
            });
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => 
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "User Server")
                );
            }
            else
            {
                app.UseHsts();               
            }

            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private void AddCommandQueryHandlers(IServiceCollection services, Type handlerInterface)
        {
            var handlers = typeof(PasswordHasher).Assembly.GetTypes()
                .Where(t => t.GetInterfaces().Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == handlerInterface)
            );

            foreach (var handler in handlers)
            {
                services.AddScoped(handler.GetInterfaces().First(i => i.IsGenericType && i.GetGenericTypeDefinition() == handlerInterface), handler);
            }
        }
    }
}
