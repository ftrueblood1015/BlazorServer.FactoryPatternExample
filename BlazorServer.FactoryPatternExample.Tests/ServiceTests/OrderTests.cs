using BlazorServer.FactoryPatternExample.Domain.models;
using BlazorServer.FactoryPatternExample.Repositories.Orders;
using BlazorServer.FactoryPatternExample.Services.Orders;
using Shouldly;

namespace BlazorServer.FactoryPatternExample.Tests.ServiceTests
{
    internal class OrderTests
    {
        private readonly OrderService OrderService;

        private readonly State California;
        private readonly State Arizona;
        private readonly State NewYork;
        private readonly State NewMexico;

        private readonly Product Car;

        private readonly Order CaOrder;
        private readonly Order CaOrderQuantity2;
        private readonly Order AzOrder;
        private readonly Order NyOrder;
        private readonly Order NmOrder;

        public OrderTests()
        {
            var repo = MockRepos.MockRepo<IOrderRepository, Order>(new List<Order>()
                {
                    new Order() { Id = 1, AmountOrder = 1, Comment = "None", Description = "None", Name = "Test 1", ProductId = 1, ShippingCost = 500, StateId = 1, Total = 1400.99 }
                }
            );

            OrderService = new OrderService(repo.Object);

            California = new State { Id = 1, Abbreviation = "CA", Name = "California", Comment = "California", Description = "California" };
            Arizona = new State { Id = 2, Abbreviation = "AZ", Name = "Arizona", Comment = "Arizona", Description = "Arizona" };
            NewYork = new State { Id = 3, Abbreviation = "NY", Name = "New York", Comment = "New York", Description = "New York" };
            NewMexico = new State { Id = 4, Abbreviation = "NM", Name = "New Mexico", Comment = "New Mexico", Description = "New Mexico" };

            Car = new Product { Id = 1, Comment = "This is a Car", Cost = 999.99, Description = "Car", Name = "Civic" };

            CaOrder = new Order { Id = 1, AmountOrder = 1, Comment = "Ca Order", Description = "Ca Order", Name = "Ca Order", ShippingCost = 0, Total = 0, ProductId = 1, StateId = 1, Product = Car, State = California };
            AzOrder = new Order { Id = 2, AmountOrder = 1, Comment = "Az Order", Description = "Az Order", Name = "Az Order", ShippingCost = 0, Total = 0, ProductId = 1, StateId = 2, Product = Car, State = Arizona };
            NyOrder = new Order { Id = 3, AmountOrder = 1, Comment = "Ny Order", Description = "Ny Order", Name = "Ny Order", ShippingCost = 0, Total = 0, ProductId = 1, StateId = 3, Product = Car, State = NewYork };
            NmOrder = new Order { Id = 4, AmountOrder = 1, Comment = "Nm Order", Description = "Nm Order", Name = "Nm Order", ShippingCost = 0, Total = 0, ProductId = 1, StateId = 4, Product = Car, State = NewMexico };

            CaOrderQuantity2 = new Order { Id = 1, AmountOrder = 2, Comment = "Ca Order", Description = "Ca Order", Name = "Ca Order", ShippingCost = 0, Total = 0, ProductId = 1, StateId = 1, Product = Car, State = California };
        }

        [Test]
        public void CaShippingCostIsCorrect()
        {
            var result = OrderService.Add(CaOrder);

            result.ShippingCost.ShouldBe(1000);
        }

        [Test]
        public void CaShippingCostQuantity2IsCorrect()
        {
            var result = OrderService.Add(CaOrderQuantity2);

            result.ShippingCost.ShouldBe(2000);
        }

        [Test]
        public void CaShippingCostIsIncorrect()
        {
            var result = OrderService.Add(CaOrder);

            result.ShippingCost.ShouldNotBe(0);
        }

        [Test]
        public void AzShippingCostIsCorrect()
        {
            var result = OrderService.Add(AzOrder);

            result.ShippingCost.ShouldBe(500);
        }

        [Test]
        public void AzShippingCostIsIncorrect()
        {
            var result = OrderService.Add(AzOrder);

            result.ShippingCost.ShouldNotBe(0);
        }

        [Test]
        public void NyShippingCostIsCorrect()
        {
            var result = OrderService.Add(NyOrder);

            result.ShippingCost.ShouldBe(5000);
        }

        [Test]
        public void NyShippingCostIsIncorrect()
        {
            var result = OrderService.Add(NyOrder);

            result.ShippingCost.ShouldNotBe(0);
        }

        [Test]
        public void DefaultShippingCostIsCorrect()
        {
            var result = OrderService.Add(NmOrder);

            result.ShippingCost.ShouldBe(0);
        }

        [Test]
        public void DefaultShippingCostIsAlwaysZero()
        {
            var result = OrderService.Add(NmOrder);

            Assert.That(result.ShippingCost < 1 && result.ShippingCost > -1);
        }
    }
}
