namespace BlazorServer.FactoryPatternExample.Factories.ShippingCost
{
    public class NewYorkShippingCostsService : IShippingCostsService
    {
        public double ShippingCosts => 5000;
    }
}
