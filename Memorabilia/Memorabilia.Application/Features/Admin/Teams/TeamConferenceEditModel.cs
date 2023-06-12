namespace Memorabilia.Application.Features.Admin.Teams;

public class TeamConferenceEditModel : EditModel
{
    public TeamConferenceEditModel() { }

    public TeamConferenceEditModel(TeamConferenceModel teamConference)
    {
        Id = teamConference.Id;
        ConferenceId = teamConference.ConferenceId;
        TeamId = teamConference.TeamId;
        BeginYear = teamConference.BeginYear;
        EndYear = teamConference.EndYear;
    }

    public int? BeginYear { get; set; }

    public int ConferenceId { get; set; }

    public string ConferenceName 
        => Constant.Conference.Find(ConferenceId)?.Name;

    public int? EndYear { get; set; }        

    public int TeamId { get; set; }
}
