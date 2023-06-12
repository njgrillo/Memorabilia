namespace Memorabilia.Blazor.Pages.Admin.FootballTypes;

public partial class ViewFootballTypes 
    : ViewDomainItem<FootballTypesModel>, IDeleteDomainItem, IViewDomainItem
{
    public async Task OnDelete(DomainEditModel viewModel)
    {
        await CommandRouter.Send(new SaveFootballType(viewModel));
    }

    public async Task OnLoad()
    {
        ViewModel = new FootballTypesModel(await QueryRouter.Send(new GetFootballTypes()));
    }
}
