namespace Memorabilia.Domain.Entities;

public class CollegeRetiredNumber : Entity
{
    public CollegeRetiredNumber() { }

    public CollegeRetiredNumber(int personId, int collegeId, string playerNumber)
    {
        PersonId = personId;
        CollegeId = collegeId;
        PlayerNumber = playerNumber;
    }

    public virtual College College { get; private set; }

    public int CollegeId { get; private set; }

    public virtual Person Person { get; private set; }

    public int PersonId { get; private set; }

    public string PlayerNumber { get; private set; }

    public void Set(int collegeId, string playerNumber)
    {
        CollegeId = collegeId;
        PlayerNumber = playerNumber;
    }

    public void SetByPerson(int personId, string playerNumber)
    {
        PersonId = personId;
        PlayerNumber = playerNumber;
    }
}
