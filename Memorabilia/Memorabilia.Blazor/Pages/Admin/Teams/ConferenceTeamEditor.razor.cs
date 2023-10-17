namespace Memorabilia.Blazor.Pages.Admin.Teams;

public partial class ConferenceTeamEditor 
    : EditTeamItem<TeamConferencesEditModel, TeamConferenceModel>
{  
    protected override async Task OnInitializedAsync()
    {
        Entity.TeamConference[] teamConferences 
            = await Mediator.Send(new GetTeamConferences(TeamId));

        EditModel = new(TeamId, teamConferences.ToEditModelList())
        {
            SportLeagueLevel = SportLeagueLevel.Find(SportLeagueLevelId)
        };
    }

    protected async Task Save()
    {
        await Save(new SaveTeamConference.Command(TeamId, EditModel.Conferences));
    }
}
