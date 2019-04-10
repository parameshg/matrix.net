using System;
using System.Collections.Generic;

namespace Matrix.Agent.Postman.Database.Entities
{
    public class Email
    {
        public Guid Id { get; set; }

        public Guid Application { get; set; }

        public string From { get; set; }

        public List<EmailAddress> To { get; set; }

        public string Subject { get; set; }

        public string Body { get; set; }

        public bool HTML { get; set; }

        public int Status { get; set; }

        public Email()
        {
            To = new List<EmailAddress>();
        }
    }
}