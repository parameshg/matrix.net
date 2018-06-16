using System;

namespace Matrix.Agent.Journal.Database.Entities
{
    public class LogProperty
    {
        public Guid Id { get; set; }

        public string Key { get; set; }

        public string Value { get; set; }
    }
}