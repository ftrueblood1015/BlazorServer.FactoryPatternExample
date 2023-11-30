using BlazorServer.FactoryPatternExample.Domain.models;
using BlazorServer.FactoryPatternExample.Repositories;
using Moq;
using System.Linq.Expressions;
using System.Text;

namespace BlazorServer.FactoryPatternExample.Tests.ServiceTests
{
    public static class MockRepos
    {
        public static Mock<TRepo> MockRepo<TRepo, T>(IEnumerable<T> list)
            where TRepo : class, IRepository<T>
            where T : BaseModel
        {
            var mock = new Mock<TRepo>();

            mock.Setup(x => x.Find(It.IsAny<Expression<Func<T, bool>>>())).Returns((Expression<Func<T, bool>> x) => { return list.AsQueryable().Where(x); });

            mock.Setup(x => x.Add(It.IsAny<T>())).Returns((T x) => {
                x.Id = list.Count() + 1;
                list.Append(x);
                return x;
            });

            mock.Setup(x => x.GetById(It.IsAny<int>())).Returns((int x) => list.FirstOrDefault(y => y.Id == x));

            return mock;
        }
    }
}
