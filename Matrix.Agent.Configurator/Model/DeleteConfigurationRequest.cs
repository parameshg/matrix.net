using System.ComponentModel.DataAnnotations;
using Matrix.Framework.Api.Model;

namespace Matrix.Agent.Configurator.Controllers.Model
{
    public class DeleteConfigurationRequest : Request
    {
        [Required]
        [StringLength(256)]
        public string Key { get; set; }
    }
}