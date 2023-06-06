namespace Memorabilia.Blazor.Pages.Admin.FootballTypes;

public partial class ViewFootballTypes : ViewDomainItem<FootballTypesViewModel>, IDeleteDomainItem, IViewDomainItem
{
    public async Task OnDelete(DomainEditModel viewModel)
    {
        await CommandRouter.Send(new SaveFootballType(viewModel));
    }

    public async Task OnLoad()
    {
        ViewModel = await QueryRouter.Send(new GetFootballTypes());
    }
}
