#nullable disable

namespace Memorabilia.Blazor.Pages.Admin.BasketballTypes;

public partial class ViewBasketballTypes : IViewDomainItem, IDeleteDomainItem
{
    [Inject]
    public CommandRouter CommandRouter { get; set; }

    [Inject]
    public QueryRouter QueryRouter { get; set; }

    private BasketballTypesViewModel ViewModel;

    public async Task OnDelete(SaveDomainViewModel viewModel)
    {
        await CommandRouter.Send(new SaveBasketballType.Command(viewModel)).ConfigureAwait(false);
    }

    public async Task OnLoad()
    {
        ViewModel = await QueryRouter.Send(new GetBasketballTypes.Query()).ConfigureAwait(false);
    }
}
