#nullable disable

namespace Memorabilia.Blazor.Pages.Admin.BaseballTypes;

public partial class ViewBaseballTypes : IViewDomainItem, IDeleteDomainItem
{
    [Inject]
    public CommandRouter CommandRouter { get; set; }

    [Inject]
    public QueryRouter QueryRouter { get; set; }

    private BaseballTypesViewModel ViewModel;

    public async Task OnDelete(SaveDomainViewModel viewModel)
    {
        await CommandRouter.Send(new SaveBaseballType.Command(viewModel)).ConfigureAwait(false);
    }

    public async Task OnLoad()
    {
        ViewModel = await QueryRouter.Send(new GetBaseballTypes.Query()).ConfigureAwait(false);
    }
}
