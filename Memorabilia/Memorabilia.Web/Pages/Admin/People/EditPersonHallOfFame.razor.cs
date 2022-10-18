using Memorabilia.Application.Features.Admin.People;

namespace Memorabilia.Web.Pages.Admin.People
{
    public partial class EditPersonHallOfFame : ComponentBase
    {
        [Inject]
        public CommandRouter CommandRouter { get; set; }

        [Inject]
        public QueryRouter QueryRouter { get; set; }

        [Parameter]
        public int PersonId { get; set; }

        private SavePersonHallOfFamesViewModel _viewModel = new ();        

        protected async Task OnLoad()
        {
            _viewModel = new SavePersonHallOfFamesViewModel(PersonId, await QueryRouter.Send(new GetPersonHallOfFames(PersonId)));
        }

        protected async Task OnSave()
        {
            await CommandRouter.Send(new SavePersonHallOfFame.Command(PersonId, _viewModel));
        }
    }
}
