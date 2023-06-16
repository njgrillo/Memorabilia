namespace Memorabilia.Blazor.Pages.Admin.Teams;

public partial class LeagueTeamEditor 
    : EditTeamItem<TeamLeaguesModel, TeamLeagueModel>
{
    protected async Task HandleValidSubmit()
    {
        await HandleValidSubmit(new SaveTeamLeague.Command(TeamId, EditModel.Leagues));
    }

    protected override async Task OnInitializedAsync()
    {
        Initialize();

        Entity.TeamLeague[] leagues = await QueryRouter.Send(new GetTeamLeagues(TeamId));

        EditModel.Leagues = leagues.ToEditModelList();

        EditModel.SportLeagueLevel = SportLeagueLevel.Find(SportLeagueLevelId);
    }    
}
