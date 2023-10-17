namespace Memorabilia.Blazor.Pages.Admin.Teams;

public partial class LeagueTeamEditor 
    : EditTeamItem<TeamLeaguesModel, TeamLeagueModel>
{
    protected override async Task OnInitializedAsync()
    {
        Entity.TeamLeague[] leagues 
            = await Mediator.Send(new GetTeamLeagues(TeamId));

        EditModel = new(TeamId, leagues.ToEditModelList())
        {
            SportLeagueLevel = SportLeagueLevel.Find(SportLeagueLevelId)
        };
    }

    protected async Task Save()
    {
        await Save(new SaveTeamLeague.Command(TeamId, EditModel.Leagues));
    }
}
