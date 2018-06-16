using System.ComponentModel.DataAnnotations;
using Matrix.Framework.Api.Model;

namespace Matrix.Agent.Configurator.Controllers.Model
{
    public class CreateConfigurationRequest : PostRequest
    {
        [Required]
        [StringLength(256)]
        public string Key { get; set; }

        [Required]
        [StringLength(1024)]
        public string Value { get; set; }
    }
}