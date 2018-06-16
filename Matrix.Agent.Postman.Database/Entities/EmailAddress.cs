using System;

namespace Matrix.Agent.Postman.Database.Entities
{
    public class EmailAddress
    {
        public Email Email { get; set; }

        public Guid EmailId { get; set; }

        public string Address { get; set; }

        public bool Copy { get; set; }

        public bool Blind { get; set; }
    }
}