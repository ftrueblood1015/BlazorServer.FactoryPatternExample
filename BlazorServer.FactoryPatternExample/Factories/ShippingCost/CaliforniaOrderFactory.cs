namespace BlazorServer.FactoryPatternExample.Factories.ShippingCost
{
    public class CaliforniaOrderFactory : IOrderFactory
    {
        IShippingCostsService IOrderFactory.CreateShippingCostService()
        {
            return new CaliforniaShippingCostsService();
        }
    }
}
