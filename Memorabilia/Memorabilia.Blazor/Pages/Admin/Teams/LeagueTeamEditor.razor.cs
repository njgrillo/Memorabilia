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
        Entity.TeamLeague[] leagues = await QueryRouter.Send(new GetTeamLeagues(TeamId));

        EditModel = new(TeamId, leagues.ToEditModelList())
        {
            SportLeagueLevel = SportLeagueLevel.Find(SportLeagueLevelId)
        };
    }    
}
