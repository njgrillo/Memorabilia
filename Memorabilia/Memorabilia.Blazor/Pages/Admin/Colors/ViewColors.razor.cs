#nullable disable

namespace Memorabilia.Blazor.Pages.Admin.Colors;

public partial class ViewColors : IViewDomainItem, IDeleteDomainItem
{
    [Inject]
    public CommandRouter CommandRouter { get; set; }

    [Inject]
    public QueryRouter QueryRouter { get; set; }

    private ColorsViewModel ViewModel;

    public async Task OnDelete(SaveDomainViewModel viewModel)
    {
        await CommandRouter.Send(new SaveColor.Command(viewModel)).ConfigureAwait(false);
    }

    public async Task OnLoad()
    {
        ViewModel = await QueryRouter.Send(new GetColors.Query()).ConfigureAwait(false);
    }
}
