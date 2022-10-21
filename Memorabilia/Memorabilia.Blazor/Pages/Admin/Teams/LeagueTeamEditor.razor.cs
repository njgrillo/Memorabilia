namespace Memorabilia.Blazor.Pages.Admin.Teams;

public partial class LeagueTeamEditor : EditTeamItem<SaveTeamLeaguesViewModel, TeamLeagueViewModel>
{
    protected async Task HandleValidSubmit()
    {
        await HandleValidSubmit(new SaveTeamLeague.Command(TeamId, ViewModel.Leagues));
    }

    protected async Task OnLoad()
    {
        Initialize();

        var leagues = (await QueryRouter.Send(new GetTeamLeagues(TeamId)))
                        .Select(teamLeague => new SaveTeamLeagueViewModel(teamLeague))
                        .ToList();

        ViewModel.Leagues = leagues;
        ViewModel.SportLeagueLevel = SportLeagueLevel.Find(SportLeagueLevelId);
    }    
}
