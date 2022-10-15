#nullable disable

namespace Memorabilia.Blazor.Pages.Tools.Baseball;

public partial class ViewAccomplishments : ComponentBase
{
    [Inject]
    public QueryRouter QueryRouter { get; set; }

    private AccomplishmentsViewModel _viewModel = new();

    private async Task OnInputChange(int accomplishmentTypeId)
    {
        _viewModel = await QueryRouter.Send(new GetAccomplishments.Query(accomplishmentTypeId));
    }
}
