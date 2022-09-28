#nullable disable

namespace Memorabilia.Blazor.Pages.Tools.Baseball
{
    public partial class ViewAwards : ComponentBase
    {
        [Inject]
        public QueryRouter QueryRouter { get; set; }

        private AwardsViewModel _viewModel = new();

        private async Task OnInputChange(int awardTypeId)
        {
            _viewModel = await QueryRouter.Send(new GetAwards.Query(awardTypeId)).ConfigureAwait(false);
        }
    }
}
