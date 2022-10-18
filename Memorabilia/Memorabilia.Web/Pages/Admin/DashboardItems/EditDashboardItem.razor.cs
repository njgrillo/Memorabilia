using Memorabilia.Application.Features.Admin.DashboardItems;

namespace Memorabilia.Web.Pages.Admin.DashboardItems
{
    public partial class EditDashboardItem : ComponentBase
    {
        [Inject]
        public CommandRouter CommandRouter { get; set; }

        [Inject]
        public QueryRouter QueryRouter { get; set; }

        [Parameter]
        public int Id { get; set; }

        private SaveDashboardItemViewModel _viewModel = new ();

        protected async Task HandleValidSubmit()
        {
            await CommandRouter.Send(new SaveDashboardItem(_viewModel));
        }

        protected async Task OnLoad()
        {
            if (Id == 0)
                return;

            _viewModel = new SaveDashboardItemViewModel(await QueryRouter.Send(new GetDashboardItem(Id)));
        }
    }
}
