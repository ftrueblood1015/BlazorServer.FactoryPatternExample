using BlazorServer.FactoryPatternExample.Repositories;
using System.Linq.Expressions;

namespace BlazorServer.FactoryPatternExample.Services
{
    public abstract class ServiceBase<T, TRepo> : IServicebase<T>
        where T : class
        where TRepo : class, IRepository<T>
    {
        public ServiceBase(TRepo repo)
        {
            Repo = repo;
        }

        public TRepo Repo { get; private set; }

        public T Add(T entity)
        {
            Repo.Add(entity);
            return entity;
        }

        void IServicebase<T>.AddRange(IEnumerable<T> entities)
        {
            Repo.AddRange(entities);
        }

        IEnumerable<T> IServicebase<T>.Find(Expression<Func<T, bool>> expression)
        {
            return Repo.Find(expression);
        }

        Task<List<T>> IServicebase<T>.GetAll()
        {
            return Repo.GetAll();
        }

        T IServicebase<T>.GetById(int id)
        {
            return Repo.GetById(id);
        }

        void IServicebase<T>.Remove(T entity)
        {
            Repo.Remove(entity);
        }

        void IServicebase<T>.RemoveRange(IEnumerable<T> entities)
        {
            Repo.RemoveRange(entities);
        }
    }
}
