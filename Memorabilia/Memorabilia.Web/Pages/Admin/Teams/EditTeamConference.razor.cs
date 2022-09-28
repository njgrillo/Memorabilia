
using Memorabilia.Application.Features.Admin.Teams;
using Memorabilia.Domain.Constants;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using System.Linq;
using System.Threading.Tasks;

namespace Memorabilia.Web.Pages.Admin.Teams
{
    public partial class EditTeamConference : ComponentBase
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

        private SaveTeamConferencesViewModel _viewModel = new ();       

        protected async Task OnLoad()
        {
            _viewModel = new SaveTeamConferencesViewModel(TeamId);

            var conferences = (await QueryRouter.Send(new GetTeamConferences.Query(TeamId))
                                                .ConfigureAwait(false)).Select(teamConference => new SaveTeamConferenceViewModel(teamConference))
                                                                       .ToList();

            _viewModel.Conferences = conferences;
            _viewModel.SportLeagueLevel = SportLeagueLevel.Find(SportLeagueLevelId);           
        }

        protected async Task OnSave()
        {
            await CommandRouter.Send(new SaveTeamConference.Command(TeamId, _viewModel.Conferences)).ConfigureAwait(false);
        }
    }
}
