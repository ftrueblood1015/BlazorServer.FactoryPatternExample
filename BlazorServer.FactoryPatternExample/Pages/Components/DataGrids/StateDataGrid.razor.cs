using BlazorServer.FactoryPatternExample.Domain.models;
using BlazorServer.FactoryPatternExample.Services.States;
using Microsoft.AspNetCore.Components;

namespace BlazorServer.FactoryPatternExample.Pages.Components.DataGrids
{
    public partial class StateDataGrid
    {
        [Inject]
        private IStateService? StateService { get; set; }
        private List<State>? StateList { get; set; }
        private string? _searchString { get; set; }

        protected override async Task OnInitializedAsync()
        {
            if (StateService == null)
            {
                throw new ArgumentException(nameof(StateService));
            }

            var StateResponse = await StateService.GetAll();
            StateList = StateResponse != null ? StateResponse.ToList() : new List<State>();
        }

        private Func<State, bool> QuickFilter => x =>
        {
            if (string.IsNullOrWhiteSpace(_searchString))
                return true;

            if (x.Name!.Contains(_searchString, StringComparison.OrdinalIgnoreCase))
                return true;

            if (x.Abbreviation!.Contains(_searchString, StringComparison.OrdinalIgnoreCase))
                return true;

            return false;
        };
    }
}
