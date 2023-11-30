namespace BlazorServer.FactoryPatternExample.Factories.ShippingCost
{
    public interface IOrderFactory
    {
        IShippingCostsService CreateShippingCostService();
    }
}
