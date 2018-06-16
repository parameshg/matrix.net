using System.IO;
using Matrix.Framework.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Matrix.Agent.Journal.Database
{
    public class DesignTimeSqlServerDbContextFactory : IDesignTimeDbContextFactory<SqlServerJournalDbContext>
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

        public SqlServerJournalDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<SqlServerJournalDbContext>();

            builder.UseSqlServer(Configuration.Agent.Database.Connection);

            return new SqlServerJournalDbContext(builder.Options);
        }
    }

    public class DesignTimeSqliteDbContextFactory : IDesignTimeDbContextFactory<SqliteJournalDbContext>
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

        public SqliteJournalDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<SqliteJournalDbContext>();

            builder.UseSqlite(Configuration.Agent.Database.Connection);

            return new SqliteJournalDbContext(builder.Options);
        }
    }
}