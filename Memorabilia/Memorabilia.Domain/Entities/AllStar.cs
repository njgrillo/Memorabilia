namespace Memorabilia.Domain.Entities;

public class AllStar : Framework.Library.Domain.Entity.DomainEntity
{
    public AllStar() { }

    public AllStar(int personId, int sportId, int year)
    {
        PersonId = personId;
        Year = year;
        SportId = sportId;
    }

    public virtual Person Person { get; private set; }

    public int PersonId { get; private set; }

    public int SportId { get; private set; }

    public int Year { get; private set; }

    public void Set(int sportId, int year)
    {
        SportId = sportId;
        Year = year;
    }
}
