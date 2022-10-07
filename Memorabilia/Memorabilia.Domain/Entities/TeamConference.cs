namespace Memorabilia.Domain.Entities;

public class TeamConference : Framework.Library.Domain.Entity.DomainEntity
{
    public TeamConference() { }

    public TeamConference(int conferenceId, int teamId, int? beginYear, int? endYear)
    {
        ConferenceId = conferenceId;
        TeamId = teamId;
        BeginYear = beginYear;
        EndYear = endYear;
    }

    public int? BeginYear { get; set; }

    public int ConferenceId { get; set; }

    public string ConferenceName => Constants.Conference.Find(ConferenceId)?.Name;

    public int? EndYear { get; set; }

    public virtual Team Team { get; set; }

    public int TeamId { get; set; }

    public void Set(int conferenceId, int teamId, int? beginYear, int? endYear)
    {
        ConferenceId = conferenceId;
        TeamId = teamId;
        BeginYear = beginYear;
        EndYear = endYear;
    }
}
