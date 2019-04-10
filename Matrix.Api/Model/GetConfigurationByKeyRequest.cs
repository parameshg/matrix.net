using System.ComponentModel.DataAnnotations;
using Matrix.Framework.Api.Model;

namespace Matrix.Api.Model
{
    public class GetConfigurationByKeyRequest : Request
    {
        [Required]
        public string Key { get; set; }
    }
}