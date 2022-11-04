namespace Memorabilia.Domain.Entities;

public class AllStar : Framework.Library.Domain.Entity.DomainEntity
{
    public AllStar() { }

    public AllStar(int personId, int year)
    {
        PersonId = personId;
        Year = year;
    }

    public virtual Person Person { get; private set; }

    public int PersonId { get; private set; }

    public int Year { get; private set; }

    public void Set(int year)
    {
        Year = year;
    }
}
