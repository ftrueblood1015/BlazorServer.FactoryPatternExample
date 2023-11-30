using BlazorServer.FactoryPatternExample.Domain.models;
using BlazorServer.FactoryPatternExample.Services.Orders;
using Microsoft.AspNetCore.Components;

namespace BlazorServer.FactoryPatternExample.Pages.Components.DataGrids
{
    public partial class OrderDataGrid
    {
        [Inject]
        private NavigationManager? NavManager { get; set; }
        [Inject]
        private IOrderService? OrderService { get; set; }
        private List<Order>? OrderList { get; set; }
        private string? _searchString { get; set; }

        protected override async Task OnInitializedAsync()
        {
            if (OrderService == null)
            {
                throw new ArgumentException(nameof(OrderService));
            }

            var OrderResponse = await OrderService.GetAll();
            OrderList = OrderResponse != null ? OrderResponse.ToList() : new List<Order>();
        }

        private Func<Order, bool> QuickFilter => x =>
        {
            if (string.IsNullOrWhiteSpace(_searchString))
                return true;

            if (x.Product?.Name != null && x.Product.Name.Contains(_searchString, StringComparison.OrdinalIgnoreCase))
                return true;

            if (x.State?.Name != null && x.State.Name.Contains(_searchString, StringComparison.OrdinalIgnoreCase))
                return true;

            if ($"{x.AmountOrder}".Contains(_searchString))
                return true;

            if ($"{x.ShippingCost}".Contains(_searchString))
                return true;

            if ($"{x.Total}".Contains(_searchString))
                return true;

            return false;
        };

        public void CreateOrder()
        {
            if (NavManager == null)
            {
                throw new Exception(nameof(NavManager));
            }
            NavManager.NavigateTo("/orderentry");
        }
    }
}
