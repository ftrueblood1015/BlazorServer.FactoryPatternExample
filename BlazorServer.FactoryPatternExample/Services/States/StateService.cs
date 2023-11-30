using BlazorServer.FactoryPatternExample.Domain.models;
using BlazorServer.FactoryPatternExample.Repositories.States;

namespace BlazorServer.FactoryPatternExample.Services.States
{
    public class StateService : ServiceBase<State, IStateRepository>, IStateService
    {
        public StateService(IStateRepository repo) : base(repo)
        {
        }
    }
}
