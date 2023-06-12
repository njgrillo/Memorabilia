namespace Memorabilia.Blazor.Pages.Admin.TeamRoleTypes;

public partial class ViewTeamRoleTypes 
    : ViewDomainItem<TeamRoleTypesModel>, IDeleteDomainItem, IViewDomainItem
{
    public async Task OnDelete(DomainEditModel editModel)
    {
        await OnDelete(new SaveTeamRoleType(editModel));
    }

    public async Task OnLoad()
    {
        Model = new TeamRoleTypesModel(await QueryRouter.Send(new GetTeamRoleTypes()));
    }
}
