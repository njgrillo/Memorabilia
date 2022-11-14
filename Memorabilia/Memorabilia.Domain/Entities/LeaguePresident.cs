namespace Memorabilia.Domain.Entities;

public class LeaguePresident : Framework.Library.Domain.Entity.DomainEntity
{
    public LeaguePresident() { }

    public LeaguePresident(int sportLeagueLevelId, int leagueId, int personId, int? beginYear, int? endYear)
    {
        SportLeagueLevelId = sportLeagueLevelId;
        LeagueId = leagueId;    
        PersonId = personId;
        BeginYear = beginYear;
        EndYear = endYear;
    }

    public int? BeginYear { get; private set; }

    public int? EndYear { get; private set; }

    public int LeagueId { get; private set; }

    public virtual Person Person { get; set; }

    public int PersonId { get; private set; }

    public int SportLeagueLevelId { get; private set; }

    public string SportLeagueLevelName => Constants.SportLeagueLevel.Find(SportLeagueLevelId)?.Name;

    public void Set(int? beginYear, int? endYear)
    {
        BeginYear = beginYear;
        EndYear = endYear;
    }
}
