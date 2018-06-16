using Matrix.Agent.Journal.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace Matrix.Agent.Journal.Database
{
    public class JournalDbContext : DbContext
    {
        public DbSet<LogEntry> Logs { get; set; }

        public JournalDbContext(DbContextOptions options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder o)
        {
            o.Entity<LogEntry>().Property(i => i.Id).ValueGeneratedOnAdd();
            o.Entity<LogEntry>().Property(i => i.Application).IsRequired();
            o.Entity<LogEntry>().Property(i => i.Timestamp).IsRequired();
            o.Entity<LogEntry>().Property(i => i.Source).IsRequired().HasMaxLength(256);
            o.Entity<LogEntry>().Property(i => i.Message).IsRequired().HasMaxLength(4096);

            o.Entity<LogProperty>().Property(i => i.Id).ValueGeneratedOnAdd();
            o.Entity<LogProperty>().Property(i => i.Key).IsRequired().HasMaxLength(256);
            o.Entity<LogProperty>().Property(i => i.Value).IsRequired().HasMaxLength(1024);

            o.Entity<LogTag>().Property(i => i.Id).ValueGeneratedOnAdd();
            o.Entity<LogTag>().Property(i => i.Value).IsRequired().HasMaxLength(256);
        }
    }

    // used only for ef migrations
    public class SqlServerJournalDbContext : JournalDbContext
    {
        public SqlServerJournalDbContext(DbContextOptions options)
            : base(options)
        {
        }
    }

    // used only for ef migrations
    public class SqliteJournalDbContext : JournalDbContext
    {
        public SqliteJournalDbContext(DbContextOptions options)
            : base(options)
        {
        }
    }
}