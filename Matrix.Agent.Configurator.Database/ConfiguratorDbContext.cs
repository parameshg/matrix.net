using Matrix.Agent.Configurator.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace Matrix.Agent.Configurator.Database
{
    public class ConfiguratorDbContext : DbContext
    {
        public DbSet<Settings> Settings { get; set; }

        public ConfiguratorDbContext(DbContextOptions options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder o)
        {
            o.Entity<Settings>().ToTable("Configuration");
            o.Entity<Settings>().Property(i => i.Application).IsRequired();
            o.Entity<Settings>().Property(i => i.Key).IsRequired().HasMaxLength(256);
            o.Entity<Settings>().Property(i => i.Value).IsRequired().HasMaxLength(1024);
        }
    }

    // used only for ef migrations
    public class SqlServerConfiguratorDbContext : ConfiguratorDbContext
    {
        public SqlServerConfiguratorDbContext(DbContextOptions options)
            : base(options)
        {
        }
    }

    // used only for ef migrations
    public class SqliteConfiguratorDbContext : ConfiguratorDbContext
    {
        public SqliteConfiguratorDbContext(DbContextOptions options)
            : base(options)
        {
        }
    }
}