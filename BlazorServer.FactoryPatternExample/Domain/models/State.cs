using System.ComponentModel.DataAnnotations;

namespace BlazorServer.FactoryPatternExample.Domain.models
{
    public class State : BaseModel
    {
        [Required]
        [StringLength(2)]
        public string? Abbreviation { get; set; }
    }
}
