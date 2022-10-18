using Memorabilia.Application.Features.Admin.Teams;

namespace Memorabilia.Web.Pages.Admin.Teams
{
    public partial class EditTeamChampionship : ComponentBase
    {
        [Inject]
        public CommandRouter CommandRouter { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Inject]
        public QueryRouter QueryRouter { get; set; }

        [Inject]
        public ISnackbar Snackbar { get; set; }

        [Parameter]
        public int SportLeagueLevelId { get; set; }

        [Parameter]
        public int TeamId { get; set; }

        private SaveTeamChampionshipsViewModel _viewModel = new();

        protected async Task OnLoad()
        {
            _viewModel = new SaveTeamChampionshipsViewModel(TeamId);

            var championships = (await QueryRouter.Send(new GetTeamChampionships(TeamId))
                                                  .ConfigureAwait(false))
                                                  .Select(teamChampionship => new SaveTeamChampionshipViewModel(teamChampionship))
                                                  .ToList();

            _viewModel.Championships = championships;
            _viewModel.SportLeagueLevel = SportLeagueLevel.Find(SportLeagueLevelId);
        }

        protected async Task OnSave()
        {
            await CommandRouter.Send(new SaveTeamChampionship.Command(TeamId, _viewModel.Championships));
        }
    }
}
