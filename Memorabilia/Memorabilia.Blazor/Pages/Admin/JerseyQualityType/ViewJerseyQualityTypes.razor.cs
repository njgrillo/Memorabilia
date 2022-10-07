#nullable disable

namespace Memorabilia.Blazor.Pages.Admin.JerseyQualityType;

public partial class ViewJerseyQualityTypes : ComponentBase, IDeleteDomainItem, IViewDomainItem
{
    [Inject]
    public CommandRouter CommandRouter { get; set; }

    [Inject]
    public QueryRouter QueryRouter { get; set; }

    private JerseyQualityTypesViewModel ViewModel;

    public async Task OnDelete(SaveDomainViewModel viewModel)
    {
        await CommandRouter.Send(new SaveJerseyQualityType.Command(viewModel)).ConfigureAwait(false);
    }

    public async Task OnLoad()
    {
        ViewModel = await QueryRouter.Send(new GetJerseyQualityTypes.Query()).ConfigureAwait(false);
    }
}
