namespace Memorabilia.Domain.Entities;

public class Leader : Framework.Library.Domain.Entity.DomainEntity
{
    public Leader() { }

    public Leader(int personId, int leaderTypeId, int year)
    {
        PersonId = personId;
        LeaderTypeId = leaderTypeId;
        Year = year;
    }

    public int LeaderTypeId { get; private set; }

    public virtual Person Person { get; private set; }

    public int PersonId { get; private set; }

    public int Year { get; private set; }

    public void Set(int leaderTypeId, int year)
    {
        LeaderTypeId = leaderTypeId;
        Year = year;
    }
}
