using System.Collections.ObjectModel;
using System.Linq.Expressions;

namespace BlazorServer.FactoryPatternExample.Repositories
{
    public interface IRepository<T> where T : class
    {
        T GetById(int id);
        Task<List<T>> GetAll();
        IEnumerable<T> Find(Expression<Func<T, bool>> expression);
        T Add(T entity);
        void AddRange(IEnumerable<T> entities);
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entities);
    }
}
