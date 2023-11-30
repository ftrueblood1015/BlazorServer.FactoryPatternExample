namespace BlazorServer.FactoryPatternExample.Factories.ShippingCost
{
    public class NewYorkOrderFactory : IOrderFactory
    {
        IShippingCostsService IOrderFactory.CreateShippingCostService()
        {
            return new NewYorkShippingCostsService();
        }
    }
}
