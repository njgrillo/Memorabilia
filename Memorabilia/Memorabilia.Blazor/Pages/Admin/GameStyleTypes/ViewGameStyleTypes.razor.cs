namespace Memorabilia.Blazor.Pages.Admin.GameStyleTypes;

public partial class ViewGameStyleTypes 
    : ViewDomainItem<GameStyleTypesModel>
{
    public async Task OnDelete(DomainEditModel editModel)
    {
        await Mediator.Send(new SaveGameStyleType(editModel));
    }

    protected override async Task OnInitializedAsync()
    {
        Model = new GameStyleTypesModel(await Mediator.Send(new GetGameStyleTypes()));
    }
}
