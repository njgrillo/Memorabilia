namespace Memorabilia.Blazor.Pages.Admin.LevelTypes;

public partial class ViewLevelTypes 
    : ViewDomainItem<LevelTypesModel>
{
    public async Task OnDelete(DomainEditModel editModel)
    {
        await OnDelete(new SaveLevelType(editModel));
    }

    protected override async Task OnInitializedAsync()
    {
        Model = new LevelTypesModel(await QueryRouter.Send(new GetLevelTypes()));
    }
}
