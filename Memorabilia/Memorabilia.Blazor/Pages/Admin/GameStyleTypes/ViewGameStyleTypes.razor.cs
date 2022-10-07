#nullable disable

namespace Memorabilia.Blazor.Pages.Admin.GameStyleTypes;

public partial class ViewGameStyleTypes : ComponentBase, IViewDomainItem, IDeleteDomainItem
{
    [Inject]
    public CommandRouter CommandRouter { get; set; }

    [Inject]
    public QueryRouter QueryRouter { get; set; }

    private GameStyleTypesViewModel ViewModel;

    public async Task OnDelete(SaveDomainViewModel viewModel)
    {
        await CommandRouter.Send(new SaveGameStyleType.Command(viewModel)).ConfigureAwait(false);
    }

    public async Task OnLoad()
    {
        ViewModel = await QueryRouter.Send(new GetGameStyleTypes.Query()).ConfigureAwait(false);
    }
}
