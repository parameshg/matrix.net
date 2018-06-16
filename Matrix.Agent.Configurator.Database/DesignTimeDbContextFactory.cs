using System.IO;
using Matrix.Framework.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Matrix.Agent.Configurator.Database
{
    public class DesignTimeSqlServerDbContextFactory : IDesignTimeDbContextFactory<SqlServerConfiguratorDbContext>
    {
        public GlobalConfiguration Configuration { get; set; }

        public DesignTimeSqlServerDbContextFactory()
        {
            var configuration = new ConfigurationBuilder()
                        .SetBasePath(Directory.GetCurrentDirectory())
                        .AddJsonFile("appsettings.json")
                        .Build();

            Configuration = configuration.GetSection(GlobalConfiguration.Root).Get<GlobalConfiguration>();
        }

        public SqlServerConfiguratorDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<SqlServerConfiguratorDbContext>();

            builder.UseSqlServer(Configuration.Agent.Database.Connection);

            return new SqlServerConfiguratorDbContext(builder.Options);
        }
    }

    public class DesignTimeSqliteDbContextFactory : IDesignTimeDbContextFactory<SqliteConfiguratorDbContext>
    {
        public GlobalConfiguration Configuration { get; set; }

        public DesignTimeSqliteDbContextFactory()
        {
            var configuration = new ConfigurationBuilder()
                        .SetBasePath(Directory.GetCurrentDirectory())
                        .AddJsonFile("appsettings.json")
                        .Build();

            Configuration = configuration.GetSection(GlobalConfiguration.Root).Get<GlobalConfiguration>();
        }

        public SqliteConfiguratorDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<SqliteConfiguratorDbContext>();

            builder.UseSqlite(Configuration.Agent.Database.Connection);

            return new SqliteConfiguratorDbContext(builder.Options);
        }
    }
}