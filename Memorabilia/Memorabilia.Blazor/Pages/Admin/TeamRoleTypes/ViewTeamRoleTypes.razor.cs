namespace Memorabilia.Blazor.Pages.Admin.TeamRoleTypes;

public partial class ViewTeamRoleTypes : ViewDomainItem<TeamRoleTypesViewModel>, IDeleteDomainItem, IViewDomainItem
{
    public async Task OnDelete(SaveDomainViewModel viewModel)
    {
        await OnDelete(new SaveTeamRoleType.Command(viewModel));
    }

    public async Task OnLoad()
    {
        await OnLoad(new GetTeamRoleTypes.Query());
    }
}
