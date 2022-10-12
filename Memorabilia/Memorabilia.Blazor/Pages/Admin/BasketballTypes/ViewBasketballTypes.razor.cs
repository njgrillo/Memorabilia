#nullable disable

namespace Memorabilia.Blazor.Pages.Admin.BasketballTypes;

public partial class ViewBasketballTypes : ViewDomainItem<BasketballTypesViewModel>, IDeleteDomainItem, IViewDomainItem
{
    public async Task OnDelete(SaveDomainViewModel viewModel)
    {
        await CommandRouter.Send(new SaveBasketballType.Command(viewModel));
    }

    public async Task OnLoad()
    {
        ViewModel = await QueryRouter.Send(new GetBasketballTypes.Query());
    }
}
