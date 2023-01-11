namespace Memorabilia.Domain.Entities;

public class PersonOccupation : Framework.Library.Domain.Entity.DomainEntity
{
    public PersonOccupation() { }

    public PersonOccupation(int occupationId, int occupationTypeId, int personId)
    {
        OccupationId = occupationId;
        OccupationTypeId = occupationTypeId;
        PersonId = personId;
    }

    public int OccupationId { get; private set; }

    public string OccupationName => Constants.Occupation.Find(OccupationId)?.Name;

    public int OccupationTypeId { get; private set; }

    public virtual Person Person { get; private set; }

    public int PersonId { get; private set; }

    public override string ToString()
        => $"{OccupationName} {Constants.OccupationType.Find(OccupationTypeId)?.Name}";

    public void Set(int occupationId, int occupationTypeId)
    {
        OccupationId = occupationId;
        OccupationTypeId = occupationTypeId;
    }
}
