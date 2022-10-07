#nullable disable

namespace Memorabilia.Blazor.Pages.Admin.JerseyTypes;

public partial class ViewJerseyTypes : ComponentBase, IDeleteDomainItem, IViewDomainItem
{
    [Inject]
    public CommandRouter CommandRouter { get; set; }

    [Inject]
    public QueryRouter QueryRouter { get; set; }

    private JerseyTypesViewModel ViewModel;

    public async Task OnDelete(SaveDomainViewModel viewModel)
    {
        await CommandRouter.Send(new SaveJerseyType.Command(viewModel)).ConfigureAwait(false);
    }

    public async Task OnLoad()
    {
        ViewModel = await QueryRouter.Send(new GetJerseyTypes.Query()).ConfigureAwait(false);
    }
}
