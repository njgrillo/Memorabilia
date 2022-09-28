#nullable disable

namespace Memorabilia.Blazor.Controls.DropDowns
{
    public partial class TeamDropDown : ComponentBase
    {
        [Inject]
        public QueryRouter QueryRouter { get; set; }

        [Parameter]
        public Franchise Franchise { get; set; }

        [Parameter]
        public int SelectedValue { get; set; }

        [Parameter]
        public SportLeagueLevel SportLeagueLevel { get; set; }

        [Parameter]
        public int Value { get; set; }

        private IEnumerable<TeamViewModel> _teams = Enumerable.Empty<TeamViewModel>();

        [Parameter]
        public EventCallback<int> ValueChanged { get; set; }

        protected override async Task OnInitializedAsync()
        {
            await Load().ConfigureAwait(false);
        }

        private async Task Load()
        {
            _teams = (await QueryRouter.Send(new GetTeams.Query(Franchise.Id, SportLeagueLevel.Id)).ConfigureAwait(false)).Teams;
        }

        private async Task OnInputChange(int value)
        {
            await ValueChanged.InvokeAsync(value).ConfigureAwait(false);
        }

        protected override async Task OnParametersSetAsync()
        {
            if (Franchise != null)
                await Load().ConfigureAwait(false);
        }
    }
}
