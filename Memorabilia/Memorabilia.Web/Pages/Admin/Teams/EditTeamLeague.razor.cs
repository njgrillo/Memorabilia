using Demo.Framework.Web;
using Memorabilia.Application.Features.Admin.Teams;
using Memorabilia.Domain.Constants;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using System.Linq;
using System.Threading.Tasks;

namespace Memorabilia.Web.Pages.Admin.Teams
{
    public partial class EditTeamLeague : ComponentBase
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

        private SaveTeamLeaguesViewModel _viewModel = new();

        protected async Task OnLoad()
        {
            _viewModel = new SaveTeamLeaguesViewModel(TeamId);

            var leagues = (await QueryRouter.Send(new GetTeamLeagues.Query(TeamId))
                                            .ConfigureAwait(false)).Select(teamLeague => new SaveTeamLeagueViewModel(teamLeague))
                                                                   .ToList();

            _viewModel.Leagues = leagues;
            _viewModel.SportLeagueLevel = SportLeagueLevel.Find(SportLeagueLevelId);
        }

        protected async Task OnSave()
        {
            await CommandRouter.Send(new SaveTeamLeague.Command(TeamId, _viewModel.Leagues)).ConfigureAwait(false);
        }
    }
}
