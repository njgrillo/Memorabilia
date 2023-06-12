namespace Memorabilia.Blazor.Pages.Admin.FootballTypes;

public partial class ViewFootballTypes 
    : ViewDomainItem<FootballTypesModel>, IDeleteDomainItem, IViewDomainItem
{
    public async Task OnDelete(DomainEditModel editModel)
    {
        await CommandRouter.Send(new SaveFootballType(editModel));
    }

    public async Task OnLoad()
    {
        Model = new FootballTypesModel(await QueryRouter.Send(new GetFootballTypes()));
    }
}
