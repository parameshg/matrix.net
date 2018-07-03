using System;

namespace Matrix.Agent.Postman.Model
{
    public class PhoneMessageMetadata
    {
        public Guid Id { get; set; }

        public DateTime Timestamp { get; set; }

        public string To { get; set; }

        public string Hash { get; set; }

        public int Status { get; set; }

        public string Error { get; set; }
    }
}