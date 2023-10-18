namespace Memorabilia.Domain.Entities;

public class CollegeRetiredNumber : Entity
{
    public CollegeRetiredNumber() { }

    public CollegeRetiredNumber(int personId, int collegeId, int playerNumber)
    {
        PersonId = personId;
        CollegeId = collegeId;
        PlayerNumber = playerNumber;
    }

    public virtual College College { get; private set; }

    public int CollegeId { get; private set; }

    public virtual Person Person { get; private set; }

    public int PersonId { get; private set; }

    public int PlayerNumber { get; private set; }

    public void Set(int collegeId, int playerNumber)
    {
        CollegeId = collegeId;
        PlayerNumber = playerNumber;
    }
}
