namespace BlazorServer.FactoryPatternExample.Factories.ShippingCost
{
    public class ArizonaOrderFactory : IOrderFactory
    {
        IShippingCostsService IOrderFactory.CreateShippingCostService()
        {
            return new ArizonaShippingCostsService();
        }
    }
}
