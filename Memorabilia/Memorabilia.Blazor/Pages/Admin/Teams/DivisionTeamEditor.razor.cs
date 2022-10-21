namespace Memorabilia.Blazor.Pages.Admin.Teams;

public partial class DivisionTeamEditor : EditTeamItem<SaveTeamDivisionsViewModel, TeamDivisionViewModel>
{
    protected async Task HandleValidSubmit()
    {
        await HandleValidSubmit(new SaveTeamDivision.Command(TeamId, ViewModel.Divisions));
    }

    protected async Task OnLoad()
    {
        Initialize();

        var divisions = (await QueryRouter.Send(new GetTeamDivisions(TeamId)))
                            .Select(teamDivision => new SaveTeamDivisionViewModel(teamDivision))
                            .ToList();

        ViewModel.Divisions = divisions;
        ViewModel.SportLeagueLevel = SportLeagueLevel.Find(SportLeagueLevelId);
    }    
}
