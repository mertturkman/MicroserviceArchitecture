using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using User.Domain.AggregatesModel.UserAggregate;
using User.Identity.Utility;
using User.Infrastructure;
using User.Infrastructure.Repository;

namespace User.Identity
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
            services.AddEntityFrameworkNpgsql()
                .AddDbContext<UserContext>(
                    option => option.UseNpgsql(Configuration.GetSection("ConnectionStrings:UserDB").Value, 
                        b => b.MigrationsAssembly("User.API")),
                    ServiceLifetime.Scoped);           

            services.AddMvcCore()
                .AddAuthorization()
                .SetCompatibilityVersion(CompatibilityVersion.Latest);

            services.AddScoped<IUserRepository, UserRepository>();
            
            IIdentityServerBuilder builder = services.AddIdentityServer()
                .AddInMemoryIdentityResources(Config.GetIdentityResources())
                .AddInMemoryApiResources(Config.GetApis())
                .AddInMemoryClients(Config.GetClients())
                .AddJwtBearerClientAuthentication()
                .AddOperationalStore(options =>
                {
                    options.RedisConnectionString = Configuration.GetSection("ConnectionStrings:UserCache").Value;
                })
                .AddRedisCaching(options =>
                {
                    options.RedisConnectionString = Configuration.GetSection("ConnectionStrings:UserCache").Value;
                })
                .AddResourceOwnerValidator<ResourceOwnerPasswordValidator>();

            builder.AddDeveloperSigningCredential();
        }
        
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //app.UseHttpsRedirection();
            app.UseRouting();

            app.UseIdentityServer();
            app.UseAuthentication();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
