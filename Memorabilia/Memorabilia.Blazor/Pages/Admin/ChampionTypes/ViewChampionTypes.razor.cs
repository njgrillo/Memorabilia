namespace Memorabilia.Blazor.Pages.Admin.ChampionTypes;

public partial class ViewChampionTypes 
    : ViewDomainItem<ChampionTypesModel>
{
    public async Task OnDelete(DomainEditModel editModel)
    {
        await CommandRouter.Send(new SaveChampionType(editModel));
    }

    protected override async Task OnInitializedAsync()
    {
        Model = new ChampionTypesModel(await QueryRouter.Send(new GetChampionTypes()));
    }
}
