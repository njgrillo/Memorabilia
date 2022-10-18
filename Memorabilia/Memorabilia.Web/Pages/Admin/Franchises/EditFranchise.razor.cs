using Memorabilia.Application.Features.Admin.Franchises;

namespace Memorabilia.Web.Pages.Admin.Franchises
{
    public partial class EditFranchise : ComponentBase
    {
        [Inject]
        public CommandRouter CommandRouter { get; set; }

        [Inject]
        public QueryRouter QueryRouter { get; set; }

        [Parameter]
        public int Id { get; set; }

        private bool _displaySportLeagueLevel;
        private SaveFranchiseViewModel _viewModel = new ();

        protected async Task HandleValidSubmit()
        {
            await CommandRouter.Send(new SaveFranchise(_viewModel));
        }

        protected async Task OnLoad()
        {
            if (Id == 0)
            {
                _displaySportLeagueLevel = true;
                return;
            }

            _viewModel = new SaveFranchiseViewModel(await QueryRouter.Send(new GetFranchise(Id)));
        }
    }
}
