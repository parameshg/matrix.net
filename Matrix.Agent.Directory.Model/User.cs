using System;
using System.Collections.Generic;

namespace Matrix.Agent.Directory.Model
{
    public class User
    {
        public class Role
        {
            public Guid Id { get; set; }

            public string Name { get; set; }

            public string Description { get; set; }
        }

        public class Group
        {
            public Guid Id { get; set; }

            public string Name { get; set; }

            public string Description { get; set; }
        }

        public Guid Id { get; set; }

        public Guid Application { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public List<Role> Roles { get; set; }

        public List<Group> Groups { get; set; }

        public User()
        {
            Roles = new List<Role>();

            Groups = new List<Group>();
        }
    }
}