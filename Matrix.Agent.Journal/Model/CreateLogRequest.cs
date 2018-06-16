using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Matrix.Framework.Api.Model;

namespace Matrix.Agent.Journal.Model
{
    public class CreateLogRequest : PostRequest
    {
        public DateTime Timestamp { get; set; }

        public string Source { get; set; }

        public int Level { get; set; }

        public int Event { get; set; }

        [Required]
        [StringLength(4096)]
        public string Message { get; set; }

        public Dictionary<string, string> Properties { get; set; }

        public List<string> Tags { get; set; }

        public CreateLogRequest()
        {
            Properties = new Dictionary<string, string>();

            Tags = new List<string>();
        }
    }
}