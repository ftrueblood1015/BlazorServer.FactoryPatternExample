using BlazorServer.FactoryPatternExample.Domain.Entities;
using BlazorServer.FactoryPatternExample.Services;
using Moq;

namespace BlazorServer.FactoryPatternExample.Tests.ServiceTests
{
    public static class MockServices
    {
        public static Mock<TService> MockService<TService, T>()
            where TService : class, IServicebase<T>
            where T : class, IEntityBase
        {
            var mock = new Mock<TService>();

            mock.Setup(x => x.Add(It.IsAny<T>())).Returns((T x) => x);

            return mock;
        }
    }
}
