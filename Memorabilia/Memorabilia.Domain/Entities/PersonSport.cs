namespace Memorabilia.Domain.Entities;

public class PersonSport : Framework.Library.Domain.Entity.DomainEntity
{
    public PersonSport() { }

    public PersonSport(int personId, int sportId)
    {
        PersonId = personId;
        SportId = sportId;
    }

    public int PersonId { get; private set; }

    public virtual Sport Sport { get; private set; }

    public int SportId { get; private set; }

    public void Set(int sportId)
    {
        SportId = sportId;
    }
}
