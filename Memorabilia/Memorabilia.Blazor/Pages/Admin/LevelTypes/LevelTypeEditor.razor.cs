namespace Memorabilia.Blazor.Pages.Admin.LevelTypes;

public partial class LevelTypeEditor 
    : EditDomainItem<LevelType>
{
    protected override async Task OnInitializedAsync()
    {
        await OnLoad(new GetLevelType(Id));
    }

    public async Task OnSave()
    {
        await OnSave(new SaveLevelType(EditModel));
    }
}
