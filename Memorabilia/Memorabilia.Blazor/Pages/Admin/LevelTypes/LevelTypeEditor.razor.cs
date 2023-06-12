namespace Memorabilia.Blazor.Pages.Admin.LevelTypes;

public partial class LevelTypeEditor : EditDomainItem<LevelType>, IEditDomainItem
{
    public async Task OnLoad()
    {
        await OnLoad(new GetLevelType(Id));
    }

    public async Task OnSave()
    {
        await OnSave(new SaveLevelType(Model));
    }
}
