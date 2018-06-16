using System;
using System.Collections.Generic;

namespace Matrix.Agent.Postman.Database.Entities
{
    public class PhoneMessage
    {
        public Guid Id { get; set; }

        public Guid Application { get; set; }

        public string From { get; set; }

        public List<PhoneNumber> To { get; set; }

        public string Message { get; set; }

        public int Status { get; set; }
    }
}