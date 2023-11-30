using System.ComponentModel.DataAnnotations;

namespace BlazorServer.FactoryPatternExample.Domain.models
{
    public class BaseModel
    {
        [Required]
        public int? Id { get; set; }

        [Required]
        public string? Comment { get; set; }

        [Required]
        public string? Description { get; set; }

        [Required]
        public string? Name { get; set; }
    }
}
