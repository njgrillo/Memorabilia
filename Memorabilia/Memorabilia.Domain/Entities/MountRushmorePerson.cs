namespace Memorabilia.Domain.Entities;

public class MountRushmorePerson : Entity
{
    public MountRushmorePerson() { }

    public MountRushmorePerson(
        int mountRushmoreId,
        int personId,
        int positionId)
    {
        MountRushmoreId = mountRushmoreId;
        PersonId = personId;
        PositionId = positionId;
    }

    public int MountRushmoreId { get; private set; }

    public virtual Person Person { get; private set; }

    public int PersonId { get; private set; }

    public int PositionId { get; private set; }

    public void Set(int personId, int positionId)
    {
        PersonId = personId;
        PositionId = positionId;
    }
}
