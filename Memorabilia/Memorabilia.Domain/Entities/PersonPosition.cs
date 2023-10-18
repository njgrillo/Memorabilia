namespace Memorabilia.Domain.Entities;

public class PersonPosition : Entity
{
    public PersonPosition() { }

    public PersonPosition(int personId, int positionId, PositionType positionType)
    {
        PersonId = personId;
        PositionId = positionId;
        IsPrimary = positionType == PositionType.Primary;    
    }

    public bool IsPrimary { get; private set; }

    public int PersonId { get; private set; }

    public virtual Position Position { get; private set; }

    public int PositionId { get; private set; }

    public override string ToString()
        => $"{Position?.Name} {(IsPrimary ? "Primary" : "Secondary")}";

    public void Set(int positionId, PositionType positionType)
    {
        PositionId = positionId;
        IsPrimary = positionType == PositionType.Primary;
    }    
}
