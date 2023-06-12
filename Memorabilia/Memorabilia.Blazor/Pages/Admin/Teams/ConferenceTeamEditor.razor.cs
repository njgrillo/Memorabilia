namespace Memorabilia.Blazor.Pages.Admin.Teams;

public partial class ConferenceTeamEditor 
    : EditTeamItem<TeamConferencesEditModel, TeamConferenceModel>
{
    protected async Task HandleValidSubmit()
    {
        await HandleValidSubmit(new SaveTeamConference.Command(TeamId, EditModel.Conferences));
    }

    protected async Task OnLoad()
    {
        Initialize();

        Entity.TeamConference[] teamConferences 
            = await QueryRouter.Send(new GetTeamConferences(TeamId));

        EditModel.Conferences 
            = teamConferences.Select(teamConference => new TeamConferenceEditModel(new TeamConferenceModel(teamConference)))
                             .ToList();

        EditModel.SportLeagueLevel = SportLeagueLevel.Find(SportLeagueLevelId);           
    }    
}
