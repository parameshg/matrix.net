using System;
using System.Collections.Generic;

namespace Matrix.Agent.Directory.Database.Entities
{
    public class UserRole
    {
        public Guid Id { get; set; }

        public Guid Application { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public List<UserRoleMapping> UserRoleMappings { get; set; }
    }
}