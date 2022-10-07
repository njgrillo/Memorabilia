namespace Memorabilia.Domain.Entities;

public class PersonAward : Framework.Library.Domain.Entity.DomainEntity
{
    public PersonAward() { }

    public PersonAward(int personId, int awardTypeId, int year)
    {
        PersonId = personId;
        AwardTypeId = awardTypeId;
        Year = year;
    }

    public int AwardTypeId { get; private set; }

    public virtual Person Person { get; private set; }

    public int PersonId { get; private set; }

    public int Year { get; private set; }

    public void Set(int awardTypeId, int year)
    {
        AwardTypeId = awardTypeId;
        Year = year;
    }
}
