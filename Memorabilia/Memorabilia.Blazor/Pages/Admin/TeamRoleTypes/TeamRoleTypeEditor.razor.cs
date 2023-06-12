namespace Memorabilia.Blazor.Pages.Admin.TeamRoleTypes;

public partial class TeamRoleTypeEditor 
    : EditDomainItem<TeamRoleType>, IEditDomainItem
{
    public async Task OnLoad()
    {
        await OnLoad(new GetTeamRoleType(Id));
    }

    public async Task OnSave()
    {
        await OnSave(new SaveTeamRoleType(Model));
    }
}
