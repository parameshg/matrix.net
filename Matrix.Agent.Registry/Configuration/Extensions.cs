using Matrix.Agent.Registry.Business.Services;
using Matrix.Agent.Registry.Database.Repositories;
using Matrix.Framework.Business;
using Matrix.Framework.Database;
using Microsoft.Extensions.DependencyInjection;

namespace Matrix.Agent.Registry.Configuration
{
    public static class Extensions
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddTransient<IRepositoryContext, RepositoryContext>();
            services.AddTransient<IHealthRepository, HealthRepository>();
            services.AddTransient<IApplicationRepository, ApplicationRepository>();

            return services;
        }

        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddTransient<IServiceContext, ServiceContext>();
            services.AddTransient<IHealthService, HealthService>();
            services.AddTransient<IApplicationService, ApplicationService>();

            return services;
        }
    }
}