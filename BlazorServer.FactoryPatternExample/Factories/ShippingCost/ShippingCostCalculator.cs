using BlazorServer.FactoryPatternExample.Domain.models;

namespace BlazorServer.FactoryPatternExample.Factories.ShippingCost
{
    public class ShippingCostCalculator
    {
        private Order Order { get; set; }
        public ShippingCostCalculator(Order order)
        { 
            Order = order;
        }

        private IOrderFactory GetFactory()
        {
            switch (Order.State!.Abbreviation)
            {
                case "CA":
                    return new CaliforniaOrderFactory();
                case "AZ":
                    return new ArizonaOrderFactory();
                case "NY":
                    return new NewYorkOrderFactory();
                default:
                    return new DefaultOrderFactory();
            }
        }

        public double GetShippingCost()
        {
            IOrderFactory factory = GetFactory();
            IShippingCostsService service = factory.CreateShippingCostService();
            return service.ShippingCosts;
        }
    }
}
