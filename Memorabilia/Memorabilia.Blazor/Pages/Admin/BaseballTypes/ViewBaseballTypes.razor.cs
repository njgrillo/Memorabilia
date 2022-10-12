#nullable disable

namespace Memorabilia.Blazor.Pages.Admin.BaseballTypes;

public partial class ViewBaseballTypes : ViewDomainItem<BaseballTypesViewModel>, IDeleteDomainItem, IViewDomainItem
{
    public async Task OnDelete(SaveDomainViewModel viewModel)
    {
        await CommandRouter.Send(new SaveBaseballType.Command(viewModel));
    }

    public async Task OnLoad()
    {
        ViewModel = await QueryRouter.Send(new GetBaseballTypes.Query());
    }
}
