using System;
using System.ComponentModel.DataAnnotations;

namespace Matrix.Agent.Registry.Model
{
    public class DeleteApplicationRequest
    {
        [Required]
        public Guid Id { get; set; }
    }
}