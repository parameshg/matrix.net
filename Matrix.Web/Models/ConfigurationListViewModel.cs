using System;
using System.Collections.Generic;
using Matrix.Agent.Registry.Model;

namespace Matrix.Web.Models
{
    public class ConfigurationListViewModel
    {
        public Guid Application { get; set; }

        public IList<Application> Applications { get; set; }

        public IList<KeyValuePair<string, string>> Settings { get; set; }
    }
}