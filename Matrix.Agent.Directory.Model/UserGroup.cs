using System;

namespace Matrix.Agent.Directory.Model
{
    public class UserGroup
    {
        public Guid Id { get; set; }

        public Guid Application { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
    }
}