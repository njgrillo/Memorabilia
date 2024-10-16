namespace Memorabilia.Domain.Entities;

public class RetiredNumber : Entity
{
    public RetiredNumber() { }

    public RetiredNumber(int personId, int franchiseId, string playerNumber)
    {
        PersonId = personId;
        FranchiseId = franchiseId;
        PlayerNumber = playerNumber;
    }

    public virtual Franchise Franchise { get; private set; }

    public int FranchiseId { get; private set; }

    public virtual Person Person { get; private set; }

    public int PersonId { get; private set; }

    public string PlayerNumber { get; private set; }

    public void Set(int franchiseId, string playerNumber)
    {
        FranchiseId = franchiseId;
        PlayerNumber = playerNumber;
    }

    public void SetByPerson(int personId, string playerNumber)
    {
        PersonId = personId;
        PlayerNumber = playerNumber;
    }
}
