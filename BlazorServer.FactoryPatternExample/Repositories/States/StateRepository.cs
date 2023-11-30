using BlazorServer.FactoryPatternExample.Domain.models;
using BlazorServer.FactoryPatternExample.Infrastructure;

namespace BlazorServer.FactoryPatternExample.Repositories.States
{
    public class StateRepository : RepositoryBase<State, FactoryPatternExampleContext>, IStateRepository
    {
        public StateRepository(FactoryPatternExampleContext context) : base(context)
        {
        }
    }
}
