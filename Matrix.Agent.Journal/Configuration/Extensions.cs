using Matrix.Agent.Journal.Business.Services;
using Matrix.Agent.Journal.Database;
using Matrix.Agent.Journal.Database.Repositories;
using Matrix.Framework.Business;
using Matrix.Framework.Configuration;
using Matrix.Framework.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Matrix.Agent.Journal.Configuration
{
    public static class Extensions
    {
        public static IServiceCollection AddDbContext(this IServiceCollection services, GlobalConfiguration configuration)
        {
            if (configuration.Agent.Database.Type.Equals(DatabaseType.Memory.ToString()))
                services.AddDbContext<JournalDbContext>(o => o.UseInMemoryDatabase(configuration.Agent.Database.Connection));

            if (configuration.Agent.Database.Type.Equals(DatabaseType.SqlServer.ToString()))
                services.AddDbContext<JournalDbContext>(o => o.UseSqlServer(configuration.Agent.Database.Connection));

            if (configuration.Agent.Database.Type.Equals(DatabaseType.Sqlite.ToString()))
                services.AddDbContext<JournalDbContext>(o => o.UseSqlite(configuration.Agent.Database.Connection));

            return services;
        }

        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddTransient<IRepositoryContext, RepositoryContext>();
            services.AddTransient<IHealthRepository, HealthRepository>();
            services.AddTransient<ILogRepository, LogRepository>();

            return services;
        }

        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddTransient<IServiceContext, ServiceContext>();
            services.AddTransient<IHealthService, HealthService>();
            services.AddTransient<ILogService, LogService>();

            return services;
        }
    }
}