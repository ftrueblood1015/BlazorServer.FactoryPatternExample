namespace BlazorServer.FactoryPatternExample.Factories.ShippingCost
{
    public class DefaultOrderFactory : IOrderFactory
    {
        IShippingCostsService IOrderFactory.CreateShippingCostService()
        {
            return new DefaultShippingCostsService();
        }
    }
}
