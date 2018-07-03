using System;
using System.Collections.Generic;
using Matrix.Agent.Journal.Model;
using Matrix.Agent.Registry.Model;

namespace Matrix.Web.Models
{
    public class LogListViewModel
    {
        public int Page { get; set; }

        public int Count { get; set; }

        public string Search { get; set; }

        public Guid Application { get; set; }

        public IList<Application> Applications { get; set; }

        public IList<LogEntry> Logs { get; set; }
    }
}