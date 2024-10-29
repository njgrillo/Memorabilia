namespace Memorabilia.Application.Features.Admin.People.Management.HallOfFames;

public class CollegeHallOfFameEditModel : EditModel
{
    public CollegeHallOfFameEditModel() { }

    public CollegeHallOfFameEditModel(Entity.CollegeHallOfFame hallOfFame)
    {
        CollegeId = hallOfFame.CollegeId;
        Id = hallOfFame.Id;
        Person = new PersonModel(hallOfFame.Person);
        Sport = Constant.Sport.Find(hallOfFame.SportId);
        SportId = hallOfFame.SportId;
        Year = hallOfFame.Year;
    }

    public CollegeHallOfFameEditModel(
        int collegeId,
        int personId,
        int? sportId,
        int? year)
    {
        CollegeId = collegeId;
        PersonId = personId;
        Sport = Constant.Sport.Find(sportId ?? 0);
        SportId = sportId;
        Year = year;
    }

    public Constant.College College
        => Constant.College.Find(CollegeId);

    public int CollegeId { get; set; }

    public string CollegeName
        => College?.Name;    

    public PersonModel Person { get; set; }
        = new();

    public int PersonId { get; set; }

    public Constant.Sport Sport { get; set; }

    public int? SportId { get; set; }

    public string SportName
        => Sport?.Name;

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
