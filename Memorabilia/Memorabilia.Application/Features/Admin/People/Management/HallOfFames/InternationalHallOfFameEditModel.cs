namespace Memorabilia.Application.Features.Admin.People.Management.HallOfFames;

public class InternationalHallOfFameEditModel : EditModel
{
    public InternationalHallOfFameEditModel() { }

    public InternationalHallOfFameEditModel(Entity.InternationalHallOfFame hallOfFame)
    {
        Id = hallOfFame.Id;
        InternationalHallOfFameTypeId = hallOfFame.InternationalHallOfFameTypeId;
        Person = new PersonModel(hallOfFame.Person);
        Year = hallOfFame.InductionYear;
    }

    public InternationalHallOfFameEditModel(
        int personId,
        int internationalHallOfFameTypeId,
        int? year)
    {
        InternationalHallOfFameTypeId = internationalHallOfFameTypeId;
        PersonId = personId;
        Year = year;
    }

    public Constant.InternationalHallOfFameType InternationalHallOfFameType
        => Constant.InternationalHallOfFameType.Find(InternationalHallOfFameTypeId);

    public int InternationalHallOfFameTypeId { get; set; }

    public string InternationalHallOfFameTypeName
        => InternationalHallOfFameType?.Name;

    public PersonModel Person { get; set; }
        = new();

    public int PersonId { get; set; }

    public Guid? TemporaryId { get; set; }

    public int? Year { get; set; }

    public int GetPersonId()
    {
        return Person?.Id > 0 ? Person.Id : PersonId;
    }

    public bool Search(string search)
    {
        bool isNumber = int.TryParse(search, out var number);

        return search.IsNullOrEmpty() ||
               (isNumber && Year == number) ||
               Person.LegalName.Contains(search, StringComparison.OrdinalIgnoreCase) ||
               Person.ProfileName.Contains(search, StringComparison.OrdinalIgnoreCase) ||
               Person.DisplayName.Contains(search, StringComparison.OrdinalIgnoreCase) ||
               Person.Nicknames.Any(x => x.Nickname.Contains(search, StringComparison.OrdinalIgnoreCase));
    }
}
