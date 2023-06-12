namespace Memorabilia.Blazor.Pages.Admin.ChampionTypes;

public partial class ViewChampionTypes : ViewDomainItem<ChampionTypesModel>, IDeleteDomainItem, IViewDomainItem
{
    public async Task OnDelete(DomainEditModel viewModel)
    {
        await CommandRouter.Send(new SaveChampionType(viewModel));
    }

    public async Task OnLoad()
    {
        ViewModel = new ChampionTypesModel(await QueryRouter.Send(new GetChampionTypes()));
    }
}
