namespace Memorabilia.Application.Features.Admin.People;

public class PersonInternationalHallOfFameEditModel : EditModel
{
    public PersonInternationalHallOfFameEditModel() { }

    public PersonInternationalHallOfFameEditModel(Entity.InternationalHallOfFame hof)
    {
        Id = hof.Id;
        InternationalHallOfFameTypeId = hof.InternationalHallOfFameTypeId;
        PersonId = hof.PersonId;
        Year = hof.InductionYear;
    }

    public int InternationalHallOfFameTypeId { get; set; }

    public string InternationalHallOfFameTypeName 
        => Constant.InternationalHallOfFameType.Find(InternationalHallOfFameTypeId)?.Name;

    public int PersonId { get; set; }

    public int? Year { get; set; }
}
