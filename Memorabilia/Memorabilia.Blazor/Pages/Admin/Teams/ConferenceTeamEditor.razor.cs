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
        Initialize();

        Entity.TeamConference[] teamConferences 
            = await QueryRouter.Send(new GetTeamConferences(TeamId));

        EditModel.Conferences = teamConferences.ToEditModelList();

        EditModel.SportLeagueLevel = SportLeagueLevel.Find(SportLeagueLevelId);           
    }    
}
