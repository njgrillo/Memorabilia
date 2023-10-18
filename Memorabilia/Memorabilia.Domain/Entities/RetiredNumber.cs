namespace Memorabilia.Domain.Entities;

public class RetiredNumber : Entity
{
    public RetiredNumber() { }

    public RetiredNumber(int personId, int franchiseId, int playerNumber)
    {
        PersonId = personId;
        FranchiseId = franchiseId;
        PlayerNumber = playerNumber;
    }

    public virtual Franchise Franchise { get; private set; }

    public int FranchiseId { get; private set; }

    public virtual Person Person { get; private set; }

    public int PersonId { get; private set; }

    public int PlayerNumber { get; private set; }

    public void Set(int franchiseId, int playerNumber)
    {
        FranchiseId = franchiseId;
        PlayerNumber = playerNumber;
    }
}
