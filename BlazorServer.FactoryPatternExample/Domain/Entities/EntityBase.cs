using System.ComponentModel.DataAnnotations;

namespace BlazorServer.FactoryPatternExample.Domain.Entities
{
    public class EntityBase : IEntityBase
    {
        public int? Id { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "The {0} value cannot exceed {1} characters.")]
        public string? Name { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} value cannot exceed {1} characters.")]
        public string? Description { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} value cannot exceed {1} characters.")]
        public string? Comment { get; set; }


        public override string ToString()
        {
            return Name ?? "";
        }
    }
}
