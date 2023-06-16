namespace Memorabilia.Blazor.Pages.Admin.GameStyleTypes;

public partial class ViewGameStyleTypes 
    : ViewDomainItem<GameStyleTypesModel>
{
    public async Task OnDelete(DomainEditModel editModel)
    {
        await CommandRouter.Send(new SaveGameStyleType(editModel));
    }

    protected override async Task OnInitializedAsync()
    {
        Model = new GameStyleTypesModel(await QueryRouter.Send(new GetGameStyleTypes()));
    }
}
