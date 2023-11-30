using BlazorServer.FactoryPatternExample.Domain.models;
using BlazorServer.FactoryPatternExample.Services.Orders;
using BlazorServer.FactoryPatternExample.Services.Products;
using BlazorServer.FactoryPatternExample.Services.States;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace BlazorServer.FactoryPatternExample.Pages
{
    public partial class OrderEntry
    {
        [Inject]
        private NavigationManager? NavManager {  get; set; }
        [Inject]
        private IOrderService? OrderService { get; set; }
        [Inject]
        private IProductService? ProductService { get; set; }
        [Inject]
        private IStateService? StateService { get; set; }
        private List<State>? StateList { get; set; }
        private List<Product>? ProductList { get; set; }
        private Order? NewOrder { get; set; } = new Order();
        bool success;
        string[] errors = { };
        MudForm? Form;

        protected override async Task OnInitializedAsync()
        {
            if (StateService == null)
            {
                throw new ArgumentException(nameof(StateService));
            }

            var StateResponse = await StateService.GetAll();
            StateList = StateResponse != null ? StateResponse.OrderBy(s => s.Name).ToList() : new List<State>();

            if (ProductService == null)
            {
                throw new ArgumentException(nameof(ProductService));
            }

            var ProductResponse = await ProductService.GetAll();
            ProductList = ProductResponse != null ? ProductResponse.OrderBy(p => p.Name).ToList() : new List<Product>();
        }

        private void CancelClick()
        {
            if (NavManager != null)
            {
                NavManager.NavigateTo("/orders");
            }
        }

        private void Save()
        {
            Form!.Validate();
            if (OrderService == null)
            {
                throw new ArgumentException(nameof(OrderService));
            }
            if (NewOrder == null)
            {
                throw new ArgumentException(nameof(NewOrder));
            }
            if (Form.IsValid)
            {
                try
                {
                    OrderService.Add(NewOrder);
                    CancelClick();
                }
                catch(Exception ex)
                {
                    throw new Exception(ex.ToString());
                }
            }
        }

        private void StateValueChange(int? id)
        {
            NewOrder!.StateId = id;
            NewOrder!.State = StateList?.Find(x => x.Id == NewOrder.StateId);
        }

        private void ProductValueChange(int? id)
        {
            NewOrder!.ProductId = id;
            NewOrder!.Product = ProductList?.Find(x => x.Id == NewOrder.ProductId);
        }
    }
}
