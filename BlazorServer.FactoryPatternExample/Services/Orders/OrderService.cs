using BlazorServer.FactoryPatternExample.Domain.models;
using BlazorServer.FactoryPatternExample.Factories.ShippingCost;
using BlazorServer.FactoryPatternExample.Repositories.Orders;

namespace BlazorServer.FactoryPatternExample.Services.Orders
{
    public class OrderService : ServiceBase<Order, IOrderRepository>, IOrderService
    {
        public OrderService(IOrderRepository repo) : base(repo)
        {

        }

        public new Order Add(Order order)
        {
            ShippingCostCalculator ShippingCostCalculator = new ShippingCostCalculator(order);
            order.ShippingCost = ShippingCostCalculator.GetShippingCost() * order.AmountOrder;
            order.Total = (order.AmountOrder * order.Product!.Cost) + order.ShippingCost;
            Repo.Add(order);
            return order;
        }
    }
}
