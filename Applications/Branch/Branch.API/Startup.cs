using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Branch.Infrastructure;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using AutoMapper.Attributes;
using CrossCutting.Extensions;
using Branch.Domain.SeedWork;

namespace Product.API
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_3_0);
            services.AddEntityFrameworkNpgsql()
                .AddDbContext<BranchContext>(option => option.UseNpgsql(Configuration["ConnectionStrings:SampleDB"]));
            services.AddRepositoryDependencies(typeof(IRepository<>));
            services.AddMediatorHandlers();
            services.AddCustomSwagger();

            services.AddAuthentication(options =>{
                options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = OpenIdConnectDefaults.AuthenticationScheme;
            })
            .AddCookie()
            .AddOpenIdConnect(o => {
                o.ClientId = "UserAPI";
                o.ClientSecret = "abcdef";
                o.Authority= "http://localhost:5000";
            });       

            AutoMapper.Mapper.Initialize(config => {
                typeof(Program).Assembly.MapTypes(config);  
            });
        }

        [System.Obsolete]
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
        }
    }
}
