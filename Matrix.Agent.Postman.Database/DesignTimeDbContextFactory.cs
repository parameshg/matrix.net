using System.IO;
using Matrix.Framework.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Matrix.Agent.Postman.Database
{
    public class DesignTimeSqlServerDbContextFactory : IDesignTimeDbContextFactory<SqlServerPostmanDbContext>
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

        public SqlServerPostmanDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<SqlServerPostmanDbContext>();

            builder.UseSqlServer(Configuration.Agent.Database.Connection);

            return new SqlServerPostmanDbContext(builder.Options);
        }
    }

    public class DesignTimeSqliteDbContextFactory : IDesignTimeDbContextFactory<SqlitePostmanDbContext>
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

        public SqlitePostmanDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<SqlitePostmanDbContext>();

            builder.UseSqlite(Configuration.Agent.Database.Connection);

            return new SqlitePostmanDbContext(builder.Options);
        }
    }
}