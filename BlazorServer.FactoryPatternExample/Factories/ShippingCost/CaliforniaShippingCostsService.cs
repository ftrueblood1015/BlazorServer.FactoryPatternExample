namespace BlazorServer.FactoryPatternExample.Factories.ShippingCost
{
    public class CaliforniaShippingCostsService : IShippingCostsService
    {
        public double ShippingCosts => 1000;
    }
}
