using Matrix.Agent.Registry.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace Matrix.Agent.Registry.Database
{
    public class RegistryDbContext : DbContext
    {
        public DbSet<Application> Applications { get; set; }

        public RegistryDbContext(DbContextOptions options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder o)
        {
            o.Entity<Application>().Property(i => i.Name).IsRequired().HasMaxLength(256);
            o.Entity<Application>().Property(i => i.Description).HasMaxLength(1024);
        }
    }

    // used only for ef migrations
    public class SqlServerRegistryDbContext : RegistryDbContext
    {
        public SqlServerRegistryDbContext(DbContextOptions options)
            : base(options)
        {
        }
    }

    // used only for ef migrations
    public class SqliteRegistryDbContext : RegistryDbContext
    {
        public SqliteRegistryDbContext(DbContextOptions options)
            : base(options)
        {
        }
    }
}