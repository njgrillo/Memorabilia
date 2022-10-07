#nullable disable

namespace Memorabilia.Blazor.Pages.Admin.HelmetQualityTypes;

public partial class ViewHelmetQualityTypes : ComponentBase, IViewDomainItem, IDeleteDomainItem
{
    [Inject]
    public CommandRouter CommandRouter { get; set; }

    [Inject]
    public QueryRouter QueryRouter { get; set; }

    private HelmetQualityTypesViewModel ViewModel;

    public async Task OnDelete(SaveDomainViewModel viewModel)
    {
        await CommandRouter.Send(new SaveHelmetQualityType.Command(viewModel)).ConfigureAwait(false);
    }

    public async Task OnLoad()
    {
        ViewModel = await QueryRouter.Send(new GetHelmetQualityTypes.Query()).ConfigureAwait(false);
    }
}
