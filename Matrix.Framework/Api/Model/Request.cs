using System;
using System.ComponentModel.DataAnnotations;

namespace Matrix.Framework.Api.Model
{
    public class Request
    {
        [Required]
        public Guid Application { get; set; }
    }
}