

namespace Memorabilia.Blazor.Pages.MemorabiliaItems
{
    public partial class ViewDashboard : ComponentBase
    {
        [Inject]
        public QueryRouter QueryRouter { get; set; }

        [Parameter]
        public int UserId { get; set; }

        private DashboardViewModel _viewModel = new();

        protected async Task OnLoad()
        {
            _viewModel = await QueryRouter.Send(new GetDashboard(UserId));
        }
    }
}
