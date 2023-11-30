using System.ComponentModel.DataAnnotations;

namespace BlazorServer.FactoryPatternExample.Domain.models
{
    public class Order : BaseModel
    {
        [Required]
        public int? AmountOrder { get; set; }

        [Required]
        public double? ShippingCost { get; set; }

        [Required]
        public double? Total { get; set; }

        [Required]
        public int? StateId { get; set; }
        public State? State { get; set; }

        [Required]
        public int? ProductId { get; set; }
        public Product? Product { get; set; }
    }
}
