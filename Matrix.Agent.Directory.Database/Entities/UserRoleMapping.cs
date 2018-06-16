using System;

namespace Matrix.Agent.Directory.Database.Entities
{
    public class UserRoleMapping
    {
        public Guid UserId { get; set; }

        public User User { get; set; }

        public Guid RoleId { get; set; }

        public UserRole Role { get; set; }
    }
}