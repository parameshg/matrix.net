using System.ComponentModel.DataAnnotations;

namespace Matrix.Agent.Registry.Model
{
    public class CreateApplicationRequest
    {
        [Required]
        [StringLength(256)]
        public string Name { get; set; }

        [StringLength(1024)]
        public string Description { get; set; }
    }
}