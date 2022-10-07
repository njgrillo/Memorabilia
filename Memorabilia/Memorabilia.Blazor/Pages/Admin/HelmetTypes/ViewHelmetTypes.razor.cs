#nullable disable

namespace Memorabilia.Blazor.Pages.Admin.HelmetTypes;

public partial class ViewHelmetTypes : ComponentBase, IViewDomainItem, IDeleteDomainItem
{
    [Inject]
    public CommandRouter CommandRouter { get; set; }

    [Inject]
    public QueryRouter QueryRouter { get; set; }

    private HelmetTypesViewModel ViewModel;

    public async Task OnDelete(SaveDomainViewModel viewModel)
    {
        await CommandRouter.Send(new SaveHelmetType.Command(viewModel)).ConfigureAwait(false);
    }

    public async Task OnLoad()
    {
        ViewModel = await QueryRouter.Send(new GetHelmetTypes.Query()).ConfigureAwait(false);
    }
}
