namespace Memorabilia.Blazor.Pages.Admin.TeamRoleTypes;

public partial class TeamRoleTypeEditor : EditDomainItem<TeamRoleType>, IEditDomainItem
{
    public async Task OnLoad()
    {
        await OnLoad(new GetTeamRoleType.Query(Id));
    }

    public async Task OnSave()
    {
        await OnSave(new SaveTeamRoleType.Command(ViewModel));
    }
}
