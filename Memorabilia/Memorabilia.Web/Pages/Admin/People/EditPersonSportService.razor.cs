using Memorabilia.Application.Features.Admin.People;

namespace Memorabilia.Web.Pages.Admin.People
{
    public partial class EditPersonSportService : ComponentBase
    {
        [Inject]
        public CommandRouter CommandRouter { get; set; }

        [Inject]
        public QueryRouter QueryRouter { get; set; }

        [Parameter]
        public int PersonId { get; set; }

        private SavePersonSportServiceViewModel _viewModel = new();

        protected async Task OnLoad()
        {
            _viewModel = new SavePersonSportServiceViewModel(PersonId, 
                                                             await QueryRouter.Send(new GetPersonSportService(PersonId)));
        }

        protected async Task OnSave()
        {
            await CommandRouter.Send(new SavePersonSportService.Command(PersonId, _viewModel));
        }
    }
}
