using Memorabilia.Application.Features.Admin.People;

namespace Memorabilia.Web.Pages.Admin.People
{
    public partial class EditPersonTeam : ComponentBase
    {
        [Inject]
        public CommandRouter CommandRouter { get; set; }

        [Inject]
        public QueryRouter QueryRouter { get; set; }

        [Parameter]
        public int PersonId { get; set; }

        private SavePersonTeamsViewModel _viewModel = new();        

        protected async Task OnLoad()
        {
            _viewModel = new SavePersonTeamsViewModel(await QueryRouter.Send(new GetPersonTeams(PersonId)));
        }

        protected async Task OnSave()
        {
            await CommandRouter.Send(new SavePersonTeam.Command(PersonId, _viewModel.Teams));
        }
    }
}
