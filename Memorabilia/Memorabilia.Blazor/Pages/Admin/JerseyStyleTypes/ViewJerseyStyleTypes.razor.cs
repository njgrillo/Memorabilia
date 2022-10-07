#nullable disable

namespace Memorabilia.Blazor.Pages.Admin.JerseyStyleTypes;

public partial class ViewJerseyStyleTypes : ComponentBase//, IDeleteDomainItem, IEditDomainItem
{
    [Inject]
    public CommandRouter CommandRouter { get; set; }

    [Inject]
    public QueryRouter QueryRouter { get; set; }

    private JerseyStyleTypesViewModel ViewModel;

    public async Task OnDelete(SaveDomainViewModel viewModel)
    {
        await CommandRouter.Send(new SaveJerseyStyleType.Command(viewModel)).ConfigureAwait(false);
    }

    public async Task OnLoad()
    {
        ViewModel = await QueryRouter.Send(new GetJerseyStyleTypes.Query()).ConfigureAwait(false);
    }
}
