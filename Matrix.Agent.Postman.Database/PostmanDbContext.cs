using Matrix.Agent.Postman.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace Matrix.Agent.Postman.Database
{
    public class PostmanDbContext : DbContext
    {
        public DbSet<Email> Emails { get; set; }

        public DbSet<PhoneMessage> PhoneMessages { get; set; }

        public PostmanDbContext(DbContextOptions options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder model)
        {
            model.Entity<Email>().Property(i => i.Application).IsRequired();
            model.Entity<Email>().Property(i => i.From).IsRequired().HasMaxLength(256);
            model.Entity<Email>().Property(i => i.Subject).IsRequired().HasMaxLength(1024);
            model.Entity<Email>().Property(i => i.Body).IsRequired().HasMaxLength(4096);
            model.Entity<Email>().Property(i => i.HTML).IsRequired();
            model.Entity<Email>().Property(i => i.Status).IsRequired();

            model.Entity<EmailAddress>().HasKey(i => new { i.EmailId, i.Address });
            model.Entity<EmailAddress>().Property(i => i.Address).HasMaxLength(256);

            model.Entity<PhoneNumber>().HasKey(i => new { i.PhoneMessageId, i.Number });
            model.Entity<PhoneNumber>().Property(i => i.Number).HasMaxLength(256);
        }
    }

    // used only for ef migrations
    public class SqlServerPostmanDbContext : PostmanDbContext
    {
        public SqlServerPostmanDbContext(DbContextOptions options)
            : base(options)
        {
        }
    }

    // used only for ef migrations
    public class SqlitePostmanDbContext : PostmanDbContext
    {
        public SqlitePostmanDbContext(DbContextOptions options)
            : base(options)
        {
        }
    }
}