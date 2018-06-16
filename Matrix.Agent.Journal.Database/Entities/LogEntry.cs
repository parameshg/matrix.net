using System;
using System.Collections.Generic;

namespace Matrix.Agent.Journal.Database.Entities
{
    public class LogEntry
    {
        public Guid Id { get; set; }

        public Guid Application { get; set; }

        public DateTime Timestamp { get; set; }

        public string Source { get; set; }

        public int Level { get; set; }

        public int Event { get; set; }

        public string Message { get; set; }

        public List<LogProperty> Properties { get; set; }

        public List<LogTag> Tags { get; set; }
    }
}