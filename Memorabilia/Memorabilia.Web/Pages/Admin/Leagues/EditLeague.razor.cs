using Memorabilia.Application.Features.Admin.Leagues;

namespace Memorabilia.Web.Pages.Admin.Leagues
{
    public partial class EditLeague : ComponentBase
    {
        [Inject]
        public CommandRouter CommandRouter { get; set; }

        [Inject]
        public QueryRouter QueryRouter { get; set; }

        [Parameter]
        public int Id { get; set; }

        private SaveLeagueViewModel _viewModel = new ();

        protected async Task HandleValidSubmit()
        {
            await CommandRouter.Send(new SaveLeague(_viewModel));
        }

        protected async Task OnLoad()
        {
            if (Id == 0)
                return;

            _viewModel = new SaveLeagueViewModel(await QueryRouter.Send(new GetLeague(Id)));
        }
    }
}
