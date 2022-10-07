namespace Memorabilia.Application.Features.Admin.Teams;

public class SaveTeamConferenceViewModel : SaveViewModel
{
    public SaveTeamConferenceViewModel() { }

    public SaveTeamConferenceViewModel(TeamConferenceViewModel teamConference)
    {
        Id = teamConference.Id;
        ConferenceId = teamConference.ConferenceId;
        TeamId = teamConference.TeamId;
        BeginYear = teamConference.BeginYear;
        EndYear = teamConference.EndYear;
    }

    public int? BeginYear { get; set; }

    public int ConferenceId { get; set; }

    public string ConferenceName => Domain.Constants.Conference.Find(ConferenceId)?.Name;

    public int? EndYear { get; set; }        

    public int TeamId { get; set; }
}
