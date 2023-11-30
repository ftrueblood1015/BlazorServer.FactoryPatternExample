using BlazorServer.FactoryPatternExample.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace BlazorServer.FactoryPatternExample.Repositories
{
    public abstract class RepositoryBase<T, TContext> : IRepository<T>
        where T : class
        where TContext : DbContext
    {
        public RepositoryBase(TContext context)
        {
            _context = context;
        }

        protected readonly TContext _context;

        public T Add(T entity)
        {
            _context.Set<T>().Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public void AddRange(IEnumerable<T> entities)
        {
            _context.Set<T>().AddRange(entities);
            _context.SaveChanges();
        }

        public IEnumerable<T> Find(Expression<Func<T, bool>> expression)
        {
            return _context.Set<T>().Where(expression);
        }
        public async Task<List<T>> GetAll()
        {
            return await _context.Set<T>().ToListAsync();
        }
        public T GetById(int id)
        {
            return _context.Set<T>().Find(id) ?? throw new Exception($"{id} not found");
        }
        public void Remove(T entity)
        {
            _context.Set<T>().Remove(entity);
            _context.SaveChanges();
        }
        public void RemoveRange(IEnumerable<T> entities)
        {
            _context.Set<T>().RemoveRange(entities);
            _context.SaveChanges();
        }
    }
}
