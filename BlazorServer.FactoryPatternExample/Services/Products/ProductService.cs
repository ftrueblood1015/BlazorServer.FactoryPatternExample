using BlazorServer.FactoryPatternExample.Domain.models;
using BlazorServer.FactoryPatternExample.Repositories.Products;

namespace BlazorServer.FactoryPatternExample.Services.Products
{
    public class ProductService : ServiceBase<Product, IProductRepository>, IProductService
    {
        public ProductService(IProductRepository repo) : base(repo)
        {
        }
    }
}
