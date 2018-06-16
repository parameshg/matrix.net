using System;
using System.Collections.Generic;

namespace Matrix.Agent.Directory.Database.Entities
{
    public class User
    {
        public Guid Id { get; set; }

        public Guid Application { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public List<UserRoleMapping> UserRoleMappings { get; set; }

        public List<UserGroupMapping> UserGroupMappings { get; set; }
    }
}