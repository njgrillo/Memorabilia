namespace Memorabilia.Domain.Entities;

public class PersonSport : Framework.Library.Domain.Entity.DomainEntity
{
    public PersonSport() { }

    public PersonSport(int personId, int sportId, bool isPrimary)
    {
        PersonId = personId;
        SportId = sportId;
        IsPrimary = isPrimary;
    }

    public bool IsPrimary { get; private set; }

    public int PersonId { get; private set; }

    public virtual Sport Sport { get; private set; }

    public int SportId { get; private set; }

    public override string ToString()
        => $"{Sport?.Name}";

    public void Set(int sportId, bool isPrimary)
    {
        SportId = sportId;
        IsPrimary = isPrimary;
    }    
}
