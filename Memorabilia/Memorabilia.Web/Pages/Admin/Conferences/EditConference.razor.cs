using Memorabilia.Application.Features.Admin.Conferences;

namespace Memorabilia.Web.Pages.Admin.Conferences
{
    public partial class EditConference : ComponentBase
    {
        [Inject]
        public CommandRouter CommandRouter { get; set; }

        [Inject]
        public QueryRouter QueryRouter { get; set; }

        [Parameter]
        public int Id { get; set; }

        private SaveConferenceViewModel _viewModel = new ();

        protected async Task HandleValidSubmit()
        {
            await CommandRouter.Send(new SaveConference(_viewModel));
        }

        protected async Task OnLoad()
        {
            if (Id == 0)
                return;

            _viewModel = new SaveConferenceViewModel(await QueryRouter.Send(new GetConference(Id)));
        }
    }
}
