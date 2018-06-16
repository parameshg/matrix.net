using Matrix.Agent.Configurator.Business.Services;
using Matrix.Agent.Configurator.Database.Repositories;
using Matrix.Framework.Business;
using Matrix.Framework.Database;
using Microsoft.Extensions.DependencyInjection;

namespace Matrix.Agent.Configurator.Configuration
{
    public static class Extensions
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddTransient<IRepositoryContext, RepositoryContext>();
            services.AddTransient<IHealthRepository, HealthRepository>();
            services.AddTransient<IConfigurationRepository, ConfigurationRepository>();

            return services;
        }

        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddTransient<IServiceContext, ServiceContext>();
            services.AddTransient<IHealthService, HealthService>();
            services.AddTransient<IConfigurationService, ConfigurationService>();

            return services;
        }
    }
}