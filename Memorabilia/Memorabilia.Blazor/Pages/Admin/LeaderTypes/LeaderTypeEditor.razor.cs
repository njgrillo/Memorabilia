namespace Memorabilia.Blazor.Pages.Admin.LeaderTypes;

public partial class LeaderTypeEditor : EditDomainItem<LeaderType>, IEditDomainItem
{
    public async Task OnLoad()
    {
        await OnLoad(new GetLeaderType(Id));
    }

    public async Task OnSave()
    {
        await OnSave(new SaveLeaderType(ViewModel));
    }
}
