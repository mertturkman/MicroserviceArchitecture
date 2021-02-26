using Microsoft.Extensions.DependencyInjection;

namespace Product.API.Extensions
{
    public static class SwaggerExtensions
    {
    public static IServiceCollection AddCustomSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                options.DescribeAllEnumsAsStrings();
                options.SwaggerDoc("v1", new Swashbuckle.AspNetCore.Swagger.Info
                {
                    Title = "Identity HTTP API",
                    Version = "v1",
                    Description = "The Identity Service HTTP API",
                    TermsOfService = "Terms Of Service"
                });
            });

            return services;
        }        
    }
}