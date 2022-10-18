using Memorabilia.Application.Features.Admin.Divisions;

namespace Memorabilia.Web.Pages.Admin.Divisions
{
    public partial class EditDivision : ComponentBase
    {
        [Inject]
        public CommandRouter CommandRouter { get; set; }

        [Inject]
        public QueryRouter QueryRouter { get; set; }

        [Parameter]
        public int Id { get; set; }

        private SaveDivisionViewModel _viewModel = new ();

        protected async Task HandleValidSubmit()
        {
            await CommandRouter.Send(new SaveDivision(_viewModel));
        }

        protected async Task OnLoad()
        {
            if (Id == 0)
                return;

            _viewModel = new SaveDivisionViewModel(await QueryRouter.Send(new GetDivision(Id)));
        }
    }
}
