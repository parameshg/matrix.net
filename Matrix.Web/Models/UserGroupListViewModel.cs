using System;
using System.Collections.Generic;
using Matrix.Agent.Directory.Model;
using Matrix.Agent.Registry.Model;

namespace Matrix.Web.Models
{
    public class UserGroupListViewModel
    {
        public Guid Application { get; set; }

        public IList<Application> Applications { get; set; }

        public IList<UserGroup> UserGroups { get; set; }
    }
}