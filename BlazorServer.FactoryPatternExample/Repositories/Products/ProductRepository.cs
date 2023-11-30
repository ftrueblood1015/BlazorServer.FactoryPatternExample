using BlazorServer.FactoryPatternExample.Domain.models;
using BlazorServer.FactoryPatternExample.Infrastructure;

namespace BlazorServer.FactoryPatternExample.Repositories.Products
{
    public class ProductRepository : RepositoryBase<Product, FactoryPatternExampleContext>, IProductRepository
    {
        public ProductRepository(FactoryPatternExampleContext context) : base(context)
        {
        }
    }
}
