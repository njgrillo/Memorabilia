namespace Memorabilia.Domain.Entities;

public class Champion : Framework.Library.Domain.Entity.DomainEntity
{
    public Champion() { }

    public Champion(int championTypeId, int teamId, int year)
    {
        ChampionTypeId = championTypeId;
        TeamId = teamId;
        Year = year;
    }

    public int ChampionTypeId { get; private set; }

    public virtual Team Team { get; private set; }

    public int TeamId { get; private set; }

    public int Year { get; private set; }

    public void Set(int year)
    {
        Year = year;
    }
}
