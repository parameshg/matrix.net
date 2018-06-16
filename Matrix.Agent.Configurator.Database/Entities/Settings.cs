using System;

namespace Matrix.Agent.Configurator.Database.Entities
{
    public class Settings
    {
        public Guid Id { get; set; }

        public Guid Application { get; set; }

        public string Key { get; set; }

        public string Value { get; set; }
    }
}