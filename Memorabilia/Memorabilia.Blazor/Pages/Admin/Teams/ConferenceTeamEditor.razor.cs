namespace Memorabilia.Blazor.Pages.Admin.Teams;

public partial class ConferenceTeamEditor : EditTeamItem<SaveTeamConferencesViewModel, TeamConferenceViewModel>
{
    protected async Task HandleValidSubmit()
    {
        await HandleValidSubmit(new SaveTeamConference.Command(TeamId, ViewModel.Conferences));
    }

    protected async Task OnLoad()
    {
        Initialize();

        var conferences = (await QueryRouter.Send(new GetTeamConferences(TeamId)))
                            .Select(teamConference => new SaveTeamConferenceViewModel(teamConference))
                            .ToList();

        ViewModel.Conferences = conferences;
        ViewModel.SportLeagueLevel = SportLeagueLevel.Find(SportLeagueLevelId);           
    }    
}
