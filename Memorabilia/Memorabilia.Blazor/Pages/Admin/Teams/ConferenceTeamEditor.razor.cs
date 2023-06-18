namespace Memorabilia.Blazor.Pages.Admin.Teams;

public partial class ConferenceTeamEditor 
    : EditTeamItem<TeamConferencesEditModel, TeamConferenceModel>
{
    protected async Task HandleValidSubmit()
    {
        await HandleValidSubmit(new SaveTeamConference.Command(TeamId, EditModel.Conferences));
    }

    protected override async Task OnInitializedAsync()
    {
        Entity.TeamConference[] teamConferences 
            = await QueryRouter.Send(new GetTeamConferences(TeamId));

        EditModel = new(TeamId, teamConferences.ToEditModelList())
        {
            SportLeagueLevel = SportLeagueLevel.Find(SportLeagueLevelId)
        };
    }    
}
