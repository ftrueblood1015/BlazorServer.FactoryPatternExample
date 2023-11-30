using System.ComponentModel.DataAnnotations;

namespace BlazorServer.FactoryPatternExample.Domain.models
{
    public class Product : BaseModel
    {
        [Required]
        public double? Cost { get; set; }
    }
}
