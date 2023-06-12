namespace Memorabilia.Blazor.Pages.Admin.Teams;

public partial class ChampionshipTeamEditor 
    : EditTeamItem<TeamChampionshipsEditModel, TeamChampionshipModel>
{
    protected async Task HandleValidSubmit()
    {
        await HandleValidSubmit(new SaveTeamChampionship.Command(TeamId, ViewModel.Championships));
    }

    protected async Task OnLoad()
    {
        Initialize();

        Entity.Champion[] champions = await QueryRouter.Send(new GetTeamChampionships(TeamId));

        ViewModel.Championships 
            = champions.Select(teamChampionship => new TeamChampionshipEditModel(new TeamChampionshipModel(teamChampionship)))
                       .ToList();

        ViewModel.SportLeagueLevel = SportLeagueLevel.Find(SportLeagueLevelId);
    }    
}
