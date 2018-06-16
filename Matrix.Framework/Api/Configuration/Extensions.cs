using Matrix.Framework.Api.Response;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Matrix.Framework.Api.Configuration
{
    public static class Extensions
    {
        public static IServiceCollection AddResponseFactory(this IServiceCollection services, IConfiguration configuration)
        {
            if (configuration["ASPNETCORE_ENVIRONMENT"].Equals("Development"))
                services.AddTransient<IResponseFactory, DevelopmentResponseFactory>();
            else
                services.AddTransient<IResponseFactory, ProductionResponseFactory>();

            return services;
        }
    }
}