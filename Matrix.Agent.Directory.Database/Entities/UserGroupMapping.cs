using System;

namespace Matrix.Agent.Directory.Database.Entities
{
    public class UserGroupMapping
    {
        public Guid UserId { get; set; }

        public User User { get; set; }

        public Guid GroupId { get; set; }

        public UserGroup Group { get; set; }
    }
}