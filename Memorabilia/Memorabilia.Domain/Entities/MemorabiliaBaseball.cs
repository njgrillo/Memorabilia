namespace Memorabilia.Domain.Entities;

public class MemorabiliaBaseball : Framework.Library.Domain.Entity.DomainEntity
{
    public MemorabiliaBaseball() { }

    public MemorabiliaBaseball(int memorabiliaId, int baseballTypeId, int? leaguePresidentId, int? year, string anniversary)
    {
        MemorabiliaId = memorabiliaId;
        BaseballTypeId = baseballTypeId;
        LeaguePresidentId = leaguePresidentId;
        Year = year;
        Anniversary = anniversary;
    }

    public string Anniversary { get; private set; }

    public int BaseballTypeId { get; private set; }

    public int? LeaguePresidentId { get; private set; }

    public int MemorabiliaId { get; private set; }

    public int? Year {get; private set;}

    public void Set(int baseballTypeId, int? leaguePresidentId, int? year, string anniversary)
    {
        BaseballTypeId = baseballTypeId;
        LeaguePresidentId = leaguePresidentId;
        Year = year;
        Anniversary = anniversary;
    }
}
