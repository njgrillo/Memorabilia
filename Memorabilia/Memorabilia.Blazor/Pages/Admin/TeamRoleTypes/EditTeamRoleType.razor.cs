namespace Memorabilia.Blazor.Pages.Admin.TeamRoleTypes;

public partial class EditTeamRoleType
    : EditDomainItem<TeamRoleType>
{
    protected override async Task OnInitializedAsync()
    {
        await OnLoad(new GetTeamRoleType(Id));
    }

    public async Task OnSave()
    {
        await OnSave(new SaveTeamRoleType(EditModel));
    }
}
