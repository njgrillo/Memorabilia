namespace Memorabilia.Domain.Entities;

public class FranchiseHallOfFame : Framework.Library.Domain.Entity.DomainEntity
{
    public FranchiseHallOfFame() { }

    public FranchiseHallOfFame(int personId, int franchiseId, int? year)
    {
        PersonId = personId;
        FranchiseId = franchiseId;
        Year = year;
    }

    public virtual Franchise Franchise { get; private set; }

    public int FranchiseId { get; private set; }

    public virtual Person Person { get; private set; }

    public int PersonId { get; private set; }

    public int? Year { get; private set; }

    public void Set(int franchiseId, int? year)
    {
        FranchiseId = franchiseId;
        Year = year;
    }
}
