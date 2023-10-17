namespace Memorabilia.Blazor.Pages.Admin.TeamRoleTypes;

public partial class ViewTeamRoleTypes 
    : ViewDomainItem<TeamRoleTypesModel>
{
    public async Task OnDelete(DomainEditModel editModel)
    {
        await OnDelete(new SaveTeamRoleType(editModel));
    }

    protected override async Task OnInitializedAsync()
    {
        Model = new TeamRoleTypesModel(await Mediator.Send(new GetTeamRoleTypes()));
    }
}
