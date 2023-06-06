namespace Memorabilia.Blazor.Pages.Admin.BaseballTypes;

public partial class ViewBaseballTypes : ViewDomainItem<BaseballTypesViewModel>, IDeleteDomainItem, IViewDomainItem
{
    public async Task OnDelete(DomainEditModel viewModel)
    {
        await CommandRouter.Send(new SaveBaseballType(viewModel));
    }

    public async Task OnLoad()
    {
        ViewModel = await QueryRouter.Send(new GetBaseballTypes());
    }
}
