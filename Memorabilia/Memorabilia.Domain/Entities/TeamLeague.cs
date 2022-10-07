namespace Memorabilia.Domain.Entities;

public class TeamLeague : Framework.Library.Domain.Entity.DomainEntity
{
    public TeamLeague() { }

    public TeamLeague(int leagueId, int teamId, int? beginYear, int? endYear)
    {
        LeagueId = leagueId;
        TeamId = teamId;
        BeginYear = beginYear;
        EndYear = endYear;
    }

    public int? BeginYear { get; set; }

    public int LeagueId { get; set; }

    public string LeagueName => Constants.League.Find(LeagueId)?.Name;

    public int? EndYear { get; set; }

    public virtual Team Team { get; set; }

    public int TeamId { get; set; }

    public void Set(int leagueId, int teamId, int? beginYear, int? endYear)
    {
        LeagueId = leagueId;
        TeamId = teamId;
        BeginYear = beginYear;
        EndYear = endYear;
    }
}
