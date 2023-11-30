using BlazorServer.FactoryPatternExample.Domain.models;
using BlazorServer.FactoryPatternExample.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace BlazorServer.FactoryPatternExample.Repositories.Orders
{
    public class OrderRepository : RepositoryBase<Order, FactoryPatternExampleContext>, IOrderRepository
    {
        public OrderRepository(FactoryPatternExampleContext context) : base(context)
        {
        }

        public async Task<List<Order>> GetAll()
        {
            return await _context.Set<Order>().Include(p => p.Product).Include(s => s.State).ToListAsync();
        }
    }
}
