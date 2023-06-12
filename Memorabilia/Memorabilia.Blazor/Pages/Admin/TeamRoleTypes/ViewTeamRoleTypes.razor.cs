namespace Memorabilia.Blazor.Pages.Admin.TeamRoleTypes;

public partial class ViewTeamRoleTypes 
    : ViewDomainItem<TeamRoleTypesModel>, IDeleteDomainItem, IViewDomainItem
{
    public async Task OnDelete(DomainEditModel viewModel)
    {
        await OnDelete(new SaveTeamRoleType(viewModel));
    }

    public async Task OnLoad()
    {
        ViewModel = new TeamRoleTypesModel(await QueryRouter.Send(new GetTeamRoleTypes()));
    }
}
