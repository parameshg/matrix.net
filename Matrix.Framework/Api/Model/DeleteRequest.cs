using System;
using System.ComponentModel.DataAnnotations;

namespace Matrix.Framework.Api.Model
{
    public class DeleteRequest : Request
    {
        [Required]
        public Guid Id { get; set; }
    }
}