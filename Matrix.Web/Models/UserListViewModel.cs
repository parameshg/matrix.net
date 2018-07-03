using System;
using System.Collections.Generic;
using Matrix.Agent.Directory.Model;
using Matrix.Agent.Registry.Model;

namespace Matrix.Web.Models
{
    public class UserListViewModel
    {
        public Guid Application { get; set; }

        public IList<Application> Applications { get; set; }

        public IList<User> Users { get; set; }
    }
}