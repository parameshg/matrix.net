using System;
using System.ComponentModel.DataAnnotations;
using Matrix.Framework.Api.Model;

namespace Matrix.Agent.Directory.Model
{
    public class GetUserByIdRequest : GetRequest
    {
        [Required]
        public Guid Id { get; set; }
    }
}