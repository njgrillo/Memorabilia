using Memorabilia.Application.Features.Admin.Teams;

namespace Memorabilia.Web.Pages.Admin.Teams
{
    public partial class EditTeam : ComponentBase
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
        public int Id { get; set; }

        private SaveTeamViewModel _viewModel = new ();        

        protected async Task OnLoad()
        {
            if (Id == 0)
                return;

            _viewModel = new SaveTeamViewModel(await QueryRouter.Send(new GetTeam(Id)));
        }

        protected async Task OnSave()
        {
            var command = new SaveTeam.Command(_viewModel);

            await CommandRouter.Send(command);

            _viewModel.Id = command.Id;
        }
    }
}
