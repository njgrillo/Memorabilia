namespace Memorabilia.Blazor.Pages.Admin.LevelTypes;

public partial class ViewLevelTypes 
    : ViewDomainItem<LevelTypesModel>, IDeleteDomainItem, IViewDomainItem
{
    public async Task OnDelete(DomainEditModel viewModel)
    {
        await OnDelete(new SaveLevelType(viewModel));
    }

    public async Task OnLoad()
    {
        ViewModel = new LevelTypesModel(await QueryRouter.Send(new GetLevelTypes()));
    }
}
