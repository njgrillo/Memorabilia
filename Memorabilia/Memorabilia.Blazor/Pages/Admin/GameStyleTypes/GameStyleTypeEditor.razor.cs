namespace Memorabilia.Blazor.Pages.Admin.GameStyleTypes;

public partial class GameStyleTypeEditor 
    : EditDomainItem<GameStyleType>
{
    protected override async Task OnInitializedAsync()
    {
        await OnLoad(new GetGameStyleType(Id));
    }

    public async Task OnSave()
    {
        await OnSave(new SaveGameStyleType(EditModel));
    }
}
