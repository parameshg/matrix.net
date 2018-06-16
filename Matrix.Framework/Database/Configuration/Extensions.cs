using Matrix.Framework.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Matrix.Framework.Database.Configuration
{
    public static class Extensions
    {
        public static IServiceCollection AddDatabase<TContext>(this IServiceCollection services, GlobalConfiguration configuration) where TContext : DbContext
        {
            if (configuration.Agent.Database.Type.Equals(DatabaseType.Memory.ToString()))
            {
                services.AddDbContext<TContext>(o =>
                {
                    o.UseInMemoryDatabase(configuration.Agent.Database.Connection);
                    o.UseLoggerFactory(new SqlLoggerFactory());
                    o.EnableSensitiveDataLogging();
                });
            }

            if (configuration.Agent.Database.Type.Equals(DatabaseType.SqlServer.ToString()))
            {
                services.AddDbContext<TContext>(o =>
                {
                    o.UseSqlServer(configuration.Agent.Database.Connection);
                    o.UseLoggerFactory(new SqlLoggerFactory());
                    o.EnableSensitiveDataLogging();
                });
            }

            if (configuration.Agent.Database.Type.Equals(DatabaseType.Sqlite.ToString()))
            {
                services.AddDbContext<TContext>(o =>
                {
                    o.UseSqlite(configuration.Agent.Database.Connection);
                    o.UseLoggerFactory(new SqlLoggerFactory());
                    o.EnableSensitiveDataLogging();
                });
            }

            return services;
        }
    }
}