using System.IO;
using Matrix.Framework.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Matrix.Agent.Registry.Database
{
    public class DesignTimeSqlServerDbContextFactory : IDesignTimeDbContextFactory<SqlServerRegistryDbContext>
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

        public SqlServerRegistryDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<SqlServerRegistryDbContext>();

            builder.UseSqlServer(Configuration.Agent.Database.Connection);

            return new SqlServerRegistryDbContext(builder.Options);
        }
    }

    public class DesignTimeSqliteDbContextFactory : IDesignTimeDbContextFactory<SqliteRegistryDbContext>
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

        public SqliteRegistryDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<SqliteRegistryDbContext>();

            builder.UseSqlite(Configuration.Agent.Database.Connection);

            return new SqliteRegistryDbContext(builder.Options);
        }
    }
}