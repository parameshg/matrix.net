using System;

namespace Matrix.Agent.Registry.Database.Entities
{
    public class Application
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
    }
}