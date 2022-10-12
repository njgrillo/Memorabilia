namespace Memorabilia.Blazor.Pages.Admin.GameStyleTypes;

public partial class GameStyleTypeEditor : EditDomainItem<GameStyleType>, IEditDomainItem
{
    public async Task OnLoad()
    {
        await OnLoad(new GetGameStyleType.Query(Id));
    }

    public async Task OnSave()
    {
        await OnSave(new SaveGameStyleType.Command(ViewModel));
    }
}
