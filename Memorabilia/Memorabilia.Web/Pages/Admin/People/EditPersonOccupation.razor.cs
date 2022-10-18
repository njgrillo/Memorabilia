using Memorabilia.Application.Features.Admin.People;

namespace Memorabilia.Web.Pages.Admin.People
{
    public partial class EditPersonOccupation : ComponentBase
    {
        [Inject]
        public CommandRouter CommandRouter { get; set; }

        [Inject]
        public QueryRouter QueryRouter { get; set; }

        [Parameter]
        public int PersonId { get; set; }

        private SavePersonOccupationsViewModel _viewModel = new();

        protected async Task OnLoad()
        {
            _viewModel = new SavePersonOccupationsViewModel(PersonId, await QueryRouter.Send(new GetPersonOccupations(PersonId)));
        }

        protected async Task OnSave()
        {
            await CommandRouter.Send(new SavePersonOccupation.Command(PersonId, _viewModel));
        }
    }
}
