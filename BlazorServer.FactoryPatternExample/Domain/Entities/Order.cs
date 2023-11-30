using BlazorServer.FactoryPatternExample.Domain.models;
using System.ComponentModel.DataAnnotations;

namespace BlazorServer.FactoryPatternExample.Domain.Entities
{
    public class Order : EntityBase
    {
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Must be greater than 0")]
        public int? AmountOrder { get; set; }

        public double? ShippingCost { get; set; }

        public double? Total { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Must be greater than 0")]
        public int? StateId { get; set; }
        public State? State { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Must be greater than 0")]
        public int? ProductId { get; set; }
        public Product? Product { get; set; }
    }
}
