namespace Memorabilia.Blazor.Pages.Admin.Teams;

public partial class DivisionTeamEditor : EditTeamItem<TeamDivisionsEditModel, TeamDivisionModel>
{
    protected async Task HandleValidSubmit()
    {
        await HandleValidSubmit(new SaveTeamDivision.Command(TeamId, ViewModel.Divisions));
    }

    protected async Task OnLoad()
    {
        Initialize();

        Entity.TeamDivision[] divisions = await QueryRouter.Send(new GetTeamDivisions(TeamId));

        ViewModel.Divisions 
            = divisions.Select(teamDivision => new TeamDivisionEditModel(new TeamDivisionModel(teamDivision)))
                       .ToList();

        ViewModel.SportLeagueLevel = SportLeagueLevel.Find(SportLeagueLevelId);
    }    
}
