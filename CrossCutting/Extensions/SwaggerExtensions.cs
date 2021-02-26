using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace CrossCutting.Extensions
{
    public static class SwaggerExtensions
    {
        public static IServiceCollection AddCustomSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Identity HTTP API",
                    Version = "v1",
                    Description = "The Identity Service HTTP API",
                });
            });

            return services;
        }        
    }
}