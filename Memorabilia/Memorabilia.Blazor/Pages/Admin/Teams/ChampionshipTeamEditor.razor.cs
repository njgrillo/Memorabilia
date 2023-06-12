namespace Memorabilia.Blazor.Pages.Admin.Teams;

public partial class ChampionshipTeamEditor 
    : EditTeamItem<TeamChampionshipsEditModel, TeamChampionshipModel>
{
    protected async Task HandleValidSubmit()
    {
        await HandleValidSubmit(new SaveTeamChampionship.Command(TeamId, EditModel.Championships));
    }

    protected async Task OnLoad()
    {
        Initialize();

        Entity.Champion[] champions = await QueryRouter.Send(new GetTeamChampionships(TeamId));

        EditModel.Championships 
            = champions.Select(teamChampionship => new TeamChampionshipEditModel(new TeamChampionshipModel(teamChampionship)))
                       .ToList();

        EditModel.SportLeagueLevel = SportLeagueLevel.Find(SportLeagueLevelId);
    }    
}
