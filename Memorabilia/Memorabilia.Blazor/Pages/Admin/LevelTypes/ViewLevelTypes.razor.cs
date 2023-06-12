namespace Memorabilia.Blazor.Pages.Admin.LevelTypes;

public partial class ViewLevelTypes 
    : ViewDomainItem<LevelTypesModel>, IDeleteDomainItem, IViewDomainItem
{
    public async Task OnDelete(DomainEditModel editModel)
    {
        await OnDelete(new SaveLevelType(editModel));
    }

    public async Task OnLoad()
    {
        Model = new LevelTypesModel(await QueryRouter.Send(new GetLevelTypes()));
    }
}
