namespace Memorabilia.Blazor.Pages.Admin.GameStyleTypes;

public partial class ViewGameStyleTypes 
    : ViewDomainItem<GameStyleTypesModel>, IDeleteDomainItem, IViewDomainItem
{
    public async Task OnDelete(DomainEditModel editModel)
    {
        await CommandRouter.Send(new SaveGameStyleType(editModel));
    }

    public async Task OnLoad()
    {
        Model = new GameStyleTypesModel(await QueryRouter.Send(new GetGameStyleTypes()));
    }
}
