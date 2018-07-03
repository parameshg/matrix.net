using System;

namespace Matrix.Agent.Postman.Model
{
    public class EmailMetadata
    {
        public Guid Id { get; set; }

        public DateTime Timestamp { get; set; }

        public string To { get; set; }

        public string Subject { get; set; }

        public string BodyHash { get; set; }

        public bool HTML { get; set; }

        public int Status { get; set; }

        public string Error { get; set; }
    }
}