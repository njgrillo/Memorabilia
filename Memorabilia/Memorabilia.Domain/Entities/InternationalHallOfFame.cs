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

    public Constant.InternationalHallOfFameType InternationalHallOfFameType 
        => Constant.InternationalHallOfFameType.Find(InternationalHallOfFameTypeId);   

    public int InternationalHallOfFameTypeId { get; private set; }

    public virtual Person Person { get; private set; }

    public int PersonId { get; private set; }

    public bool Filter(string search)
    {
        bool isNumeric = int.TryParse(search, out int year);

        return search.IsNullOrEmpty() ||
               (isNumeric && InductionYear.HasValue && InductionYear.Value == year) ||
               InternationalHallOfFameType.Name.Contains(search, StringComparison.OrdinalIgnoreCase) ||
               (Person is not null && Person.LegalName.Contains(search, StringComparison.OrdinalIgnoreCase)) ||
               (Person is not null && Person.Name.Contains(search, StringComparison.OrdinalIgnoreCase));
    }

    public void Set(int internationalHallOfFameTypeId, int? inductionYear)
    {
        InternationalHallOfFameTypeId = internationalHallOfFameTypeId;
        InductionYear = inductionYear;
    }
}
