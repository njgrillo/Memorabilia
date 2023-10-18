namespace Memorabilia.Domain.Entities;

public class InternationalHallOfFame : Entity
{
    public InternationalHallOfFame() { }

    public InternationalHallOfFame(int personId, int internationalHallOfFameTypeId, int? inductionYear)
    {            
        PersonId = personId;
        InternationalHallOfFameTypeId = internationalHallOfFameTypeId;
        InductionYear = inductionYear;
    }

    public int? InductionYear { get; private set; }

    public Constants.InternationalHallOfFameType InternationalHallOfFameType => Constants.InternationalHallOfFameType.Find(InternationalHallOfFameTypeId);   

    public int InternationalHallOfFameTypeId { get; private set; }

    public virtual Person Person { get; private set; }

    public int PersonId { get; private set; }

    public void Set(int internationalHallOfFameTypeId, int? inductionYear)
    {
        InternationalHallOfFameTypeId = internationalHallOfFameTypeId;
        InductionYear = inductionYear;
    }
}
