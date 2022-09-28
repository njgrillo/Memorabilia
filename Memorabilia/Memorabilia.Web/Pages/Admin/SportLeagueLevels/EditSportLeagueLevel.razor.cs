
using Memorabilia.Application.Features.Admin.SportLeagueLevel;
using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;

namespace Memorabilia.Web.Pages.Admin.SportLeagueLevels
{
    public partial class EditSportLeagueLevel : ComponentBase
    {
        [Inject]
        public CommandRouter CommandRouter { get; set; }

        [Inject]
        public QueryRouter QueryRouter { get; set; }

        [Parameter]
        public int Id { get; set; }

        private SaveSportLeagueLevelViewModel _viewModel = new ();

        protected async Task HandleValidSubmit()
        {
            await CommandRouter.Send(new SaveSportLeagueLevel.Command(_viewModel)).ConfigureAwait(false);
        }

        protected async Task OnLoad()
        {
            if (Id == 0)
                return;

            _viewModel = new SaveSportLeagueLevelViewModel(await QueryRouter.Send(new GetSportLeagueLevel.Query(Id)).ConfigureAwait(false));
        }
    }
}
