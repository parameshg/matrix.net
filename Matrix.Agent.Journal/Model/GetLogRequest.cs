using System;
using System.ComponentModel.DataAnnotations;

namespace Matrix.Agent.Journal.Model
{
    public class GetLogRequest
    {
        [Required]
        public Guid Application { get; set; }

        [Required]
        public DateTime DateFrom { get; set; }

        [Required]
        public DateTime DateTo { get; set; }

        public int Page { get; set; }

        public int Count { get; set; }
    }
}