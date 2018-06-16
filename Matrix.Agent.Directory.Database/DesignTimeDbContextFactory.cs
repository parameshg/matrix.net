using Matrix.Framework.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Matrix.Agent.Directory.Database
{
    public class DesignTimeSqlServerDbContextFactory : IDesignTimeDbContextFactory<SqlServerDirectoryDbContext>
    {
        public GlobalConfiguration Configuration { get; set; }

        public DesignTimeSqlServerDbContextFactory()
        {
            var configuration = new ConfigurationBuilder()
                        .SetBasePath(System.IO.Directory.GetCurrentDirectory())
                        .AddJsonFile("appsettings.json")
                        .Build();

            Configuration = configuration.GetSection(GlobalConfiguration.Root).Get<GlobalConfiguration>();
        }

        public SqlServerDirectoryDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<SqlServerDirectoryDbContext>();

            builder.UseSqlServer(Configuration.Agent.Database.Connection);

            return new SqlServerDirectoryDbContext(builder.Options);
        }
    }

    public class DesignTimeSqliteDbContextFactory : IDesignTimeDbContextFactory<SqliteDirectoryDbContext>
    {
        public GlobalConfiguration Configuration { get; set; }

        public DesignTimeSqliteDbContextFactory()
        {
            var configuration = new ConfigurationBuilder()
                        .SetBasePath(System.IO.Directory.GetCurrentDirectory())
                        .AddJsonFile("appsettings.json")
                        .Build();

            Configuration = configuration.GetSection(GlobalConfiguration.Root).Get<GlobalConfiguration>();
        }

        public SqliteDirectoryDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<SqliteDirectoryDbContext>();

            builder.UseSqlite(Configuration.Agent.Database.Connection);

            return new SqliteDirectoryDbContext(builder.Options);
        }
    }
}