using System;
using System.Collections.Generic;
using Matrix.Agent.Directory.Model;
using Matrix.Agent.Registry.Model;

namespace Matrix.Web.Models
{
    public class UserRoleListViewModel
    {
        public Guid Application { get; set; }

        public IList<Application> Applications { get; set; }

        public IList<UserRole> UserRoles { get; set; }
    }
}