namespace Memorabilia.Blazor.Pages.Admin.GameStyleTypes;

public partial class ViewGameStyleTypes 
    : ViewDomainItem<GameStyleTypesModel>, IDeleteDomainItem, IViewDomainItem
{
    public async Task OnDelete(DomainEditModel viewModel)
    {
        await CommandRouter.Send(new SaveGameStyleType(viewModel));
    }

    public async Task OnLoad()
    {
        ViewModel = new GameStyleTypesModel(await QueryRouter.Send(new GetGameStyleTypes()));
    }
}
