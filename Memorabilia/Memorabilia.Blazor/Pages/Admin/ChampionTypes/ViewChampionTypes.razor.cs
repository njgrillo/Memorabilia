namespace Memorabilia.Blazor.Pages.Admin.ChampionTypes;

public partial class ViewChampionTypes 
    : ViewDomainItem<ChampionTypesModel>, IDeleteDomainItem, IViewDomainItem
{
    public async Task OnDelete(DomainEditModel editModel)
    {
        await CommandRouter.Send(new SaveChampionType(editModel));
    }

    public async Task OnLoad()
    {
        Model = new ChampionTypesModel(await QueryRouter.Send(new GetChampionTypes()));
    }
}
