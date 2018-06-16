using System;

namespace Matrix.Agent.Postman.Database.Entities
{
    public class PhoneNumber
    {
        public PhoneMessage PhoneMessage { get; set; }

        public Guid PhoneMessageId { get; set; }

        public string Number { get; set; }
    }
}