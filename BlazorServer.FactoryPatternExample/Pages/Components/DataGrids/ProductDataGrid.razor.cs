using BlazorServer.FactoryPatternExample.Domain.models;
using BlazorServer.FactoryPatternExample.Services.Products;
using Microsoft.AspNetCore.Components;

namespace BlazorServer.FactoryPatternExample.Pages.Components.DataGrids
{
    public partial class ProductDataGrid
    {
        [Inject]
        private IProductService? ProductService { get; set; }
        private List<Product>? ProductList { get; set; }
        private string? _searchString { get; set; }

        protected override async Task OnInitializedAsync()
        {
            if (ProductService == null)
            {
                throw new ArgumentException(nameof(ProductService));
            }

            var ProductResponse = await ProductService.GetAll();
            ProductList = ProductResponse != null ? ProductResponse.ToList() : new List<Product>();
        }

        private Func<Product, bool> QuickFilter => x =>
        {
            if (string.IsNullOrWhiteSpace(_searchString))
                return true;

            if (x.Name!.Contains(_searchString, StringComparison.OrdinalIgnoreCase))
                return true;

            if (x.Description!.Contains(_searchString, StringComparison.OrdinalIgnoreCase))
                return true;

            if ($"{x.Cost}".Contains(_searchString))
                return true;

            return false;
        };
    }
}
