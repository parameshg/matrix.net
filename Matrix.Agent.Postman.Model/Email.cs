using System;
using System.Collections.Generic;

namespace Matrix.Agent.Postman.Model
{
    public class Email
    {
        public Guid Id { get; set; }

        public string From { get; set; }

        public List<string> To { get; set; }

        public List<string> Cc { get; set; }

        public List<string> Bcc { get; set; }

        public string Subject { get; set; }

        public string Body { get; set; }

        public bool HTML { get; set; }
    }
}