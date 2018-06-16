using Matrix.Agent.Directory.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace Matrix.Agent.Directory.Database
{
    public class DirectoryDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<UserRole> UserRoles { get; set; }

        public DbSet<UserGroup> UserGroups { get; set; }

        public DirectoryDbContext(DbContextOptions options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder o)
        {
            o.Entity<User>().Property(i => i.Application).IsRequired();
            o.Entity<User>().Property(i => i.Username).IsRequired().HasMaxLength(256);
            o.Entity<User>().Property(i => i.Password).IsRequired().HasMaxLength(1024);
            o.Entity<User>().Property(i => i.FirstName).IsRequired().HasMaxLength(128);
            o.Entity<User>().Property(i => i.LastName).IsRequired().HasMaxLength(128);
            o.Entity<User>().Property(i => i.Email).IsRequired().HasMaxLength(256);
            o.Entity<User>().Property(i => i.Phone).HasMaxLength(16);

            o.Entity<UserGroup>().Property(i => i.Application).IsRequired();
            o.Entity<UserGroup>().Property(i => i.Name).IsRequired().HasMaxLength(256);
            o.Entity<UserGroup>().Property(i => i.Description).IsRequired().HasMaxLength(1024);

            o.Entity<UserRole>().Property(i => i.Application).IsRequired();
            o.Entity<UserRole>().Property(i => i.Name).IsRequired().HasMaxLength(256);
            o.Entity<UserRole>().Property(i => i.Description).IsRequired().HasMaxLength(1024);

            o.Entity<UserRoleMapping>().HasKey(i => new { i.UserId, i.RoleId });
            o.Entity<UserGroupMapping>().HasKey(i => new { i.UserId, i.GroupId });
        }
    }

    // used only for ef migrations
    public class SqlServerDirectoryDbContext : DirectoryDbContext
    {
        public SqlServerDirectoryDbContext(DbContextOptions options)
            : base(options)
        {
        }
    }

    // used only for ef migrations
    public class SqliteDirectoryDbContext : DirectoryDbContext
    {
        public SqliteDirectoryDbContext(DbContextOptions options)
            : base(options)
        {
        }
    }
}